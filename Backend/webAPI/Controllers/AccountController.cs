using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("api/Account")]
    public class AccountController(AppDbContext context, IConfiguration configuration) : ControllerBase
    {
        // Endpoint para el registro de usuario
        [HttpPost("register")]
        public ActionResult Register(RegistroUsuarioDTO registroDTO)
        {
            try
            {
                //Validar que el email q se ingresa no este registrado
                var validarEmail = context.Usuarios.FirstOrDefault(u => u.Email == registroDTO.Email);

                if (validarEmail != null)
                {
                    throw new Exception("*El email ya esta en uso*");
                }

                var rol = context.Roles.FirstOrDefault(r => r.Id == registroDTO.IdRol);

                if (rol is null)
                {
                    throw new Exception("¡Rol no encontrado!");
                }

                //var provincia = context.Provincias.FirstOrDefault(p => p.Id == registroDTO.IdProvincia);
                var provincia = context.Provincias.FirstOrDefault(p => p.Nombre == registroDTO.NombreProvincia);

                if (provincia is null)
                {
                    throw new Exception("¡Provincia no encontrada!");
                }

                //var localidad = context.Localidades.FirstOrDefault(l => l.Id == registroDTO.IdLocalidad);
                var localidad = context.Localidades.FirstOrDefault(l => l.Nombre == registroDTO.NombreLocalidad && l.IdProvincia == provincia.Id);

                if (localidad is null)
                {
                    localidad = new Localidad
                    {
                        Nombre = registroDTO.NombreLocalidad,
                        // Asignar la FK a provincia correspondiente
                        IdProvincia = provincia.Id,
                    };

                    // Agregar y guardamos la nueva localidad en la BD
                    context.Localidades.Add(localidad);
                    context.SaveChanges();
                }

                // Creamos el Hash y la Sal de la contraseña
                CreatePasswordHash(registroDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                // Mapeamos el DTO a la entidad
                var usuario = new Usuario
                {
                    Nombre = registroDTO.Nombre,
                    Apellido = registroDTO.Apellido,
                    Email = registroDTO.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IdRol = registroDTO.IdRol,
                    IdProvincia = provincia.Id,
                    IdLocalidad = localidad.Id
                };

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                var autoLogin = new LoginUsuarioDTO
                {
                    Email = registroDTO.Email,
                    Password = registroDTO.Password
                };

                return Login(autoLogin);

                //return Ok("¡Usuario registrado con exito!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        // Endpoint para el inicio de sesion
        [HttpPost("login")]
        public ActionResult Login(LoginUsuarioDTO loginDTO)
        {
            try
            {
                // Buscamos al usuario en la BD por su email
                var usuario = context.Usuarios
                    .Where(u => !u.Borrado && u.Email == loginDTO.Email)
                    .Include(u => u.Rol)
                    .FirstOrDefault();

                // Verificamos si el usuario existe
                if (usuario is null)
                {
                    throw new Exception("*Direccion de email incorrecta*");
                }

                // Verificamos si la contraseña es correcta
                if (!VerifyPasswordHash(loginDTO.Password, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new Exception("*Contraseña incorrecta*");
                }

                // Creamos el token JWT
                var token = new
                {
                    accessToken = CreateToken(usuario)
                };

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPut("{email}")]
        public ActionResult ActualizarAsync(string email, ModificarUsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = context.Usuarios
                .Where(u => !u.Borrado && u.Email == email)
                .FirstOrDefault();

                if (usuario is null)
                {
                    throw new Exception("¡Usuario no encontrado!");
                }

                //var provincia = context.Provincias.FirstOrDefault(p => p.Id == registroDTO.IdProvincia);
                var provincia = context.Provincias.FirstOrDefault(p => p.Nombre == usuarioDTO.NombreProvincia);

                if (provincia is null)
                {
                    throw new Exception("¡Provincia no encontrada!");
                }

                //var localidad = context.Localidades.FirstOrDefault(l => l.Id == registroDTO.IdLocalidad);
                var localidad = context.Localidades.FirstOrDefault(l => l.Nombre == usuarioDTO.NombreLocalidad && l.IdProvincia == provincia.Id);

                if (localidad is null)
                {
                    localidad = new Localidad
                    {
                        Nombre = usuarioDTO.NombreLocalidad,
                        // Asignar la FK a provincia correspondiente
                        IdProvincia = provincia.Id,
                    };

                    // Agregar y guardamos la nueva localidad en la BD
                    context.Localidades.Add(localidad);
                    context.SaveChanges();
                }

                // Hash de password
                CreatePasswordHash(usuarioDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                // Asignamos los nuevos valores a los campos que se pueden modificar
                usuario.Nombre = usuarioDTO.Nombre;
                usuario.Apellido = usuarioDTO.Apellido;
                usuario.Direccion = usuarioDTO.Direccion;
                usuario.Descripcion = usuarioDTO.Descripcion;
                usuario.IdProvincia = provincia.Id;
                usuario.IdLocalidad = localidad.Id;
                //usuario.PasswordHash = passwordHash;
                //usuario.PasswordSalt = passwordSalt;

                // Aplicamos los cambios
                context.SaveChanges();

                return Ok("¡Usuario modificado con exito!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error al procesar la solicitud: {ex.Message}");
            }
        }

        // Metodo para crear el hash y la sal de la contraseña
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;    //Generamos una clave aleatoria de 512 bits
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // Metodo para verificar el hash de la contraseña
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        // Metodo para crear el token JWT
        private string CreateToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim("name", usuario.Nombre + " " + usuario.Apellido),
                new Claim("email", usuario.Email)
            };

            string rol = usuario.Rol.Nombre;

            claims.Add(new Claim("role", rol));

            // Obtenemos la clave secreta desde la configuracion
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value));

            // Creamos las credenciales para firmar el token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Creamos el token JWT con los claims, fecha de expiracion, y credenciales de firma
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            // Escribimos el token en formato JWT y lo devolvemos
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
