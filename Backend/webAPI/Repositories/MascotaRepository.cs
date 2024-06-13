using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories.Interfaces;

namespace webAPI.Repositories
{
    //Inyectamos el DbContext para que el repositorio tenga acceso
    public class MascotaRepository(AppDbContext context) : IMascotaRepository
    {
        public async Task<IEnumerable<GetMascotaDTO>> Get(string email)
        {
            // Iniciar la consulta con las inclusiones necesarias
            var query = context.Mascotas
                .Include(m => m.Usuario)
                .AsQueryable();

            // Si se proporciona un email, agregar un filtro a la consulta
            if (!string.IsNullOrEmpty(email))
            {
                // Verificamos si el usuario existe
                var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

                if (usuario is null)
                {
                    throw new Exception("*Usuario no encontrado*");
                }
                else
                {
                    query = query.Where(m => m.Usuario.Email == email);
                }
            }

            // Proyectamos los resultados
            var mascotas = await query
                .Where(m => !m.Borrado)
                .Select(m => new GetMascotaDTO
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    NombreUsuario = m.Usuario.Nombre + " " + m.Usuario.Apellido + " - " + m.Usuario.Email,
                    //Meses = m.Meses,
                    //Años = m.Años,
                    //Raza = m.Raza,
                    UrlImagen = m.UrlImagen,
                    Descripcion = m.Descripcion,
                    Estado = m.Estado
                })
                .OrderByDescending(m => m.Estado == "Solicitada")
                .ThenByDescending(m => m.Estado == "Disponible")
                .ToListAsync();

            return mascotas;
        }
        
        public async Task<GetMascotaDTO> LeerUnoAsync(int idMascota)
        {
            var mascota = await context.Mascotas
                .Where(m => !m.Borrado && m.Id == idMascota)    //.Include(u => u.Usuario)
                .Include(m => m.Usuario)
                .Select(m => new GetMascotaDTO
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    NombreUsuario = m.Usuario.Nombre + " " + m.Usuario.Apellido + " - " + m.Usuario.Email,
                    Meses = m.Meses,
                    Años = m.Años,
                    Raza = m.Raza,
                    UrlImagen = m.UrlImagen,
                    Descripcion = m.Descripcion,
                    Estado = m.Estado
                })
                .FirstOrDefaultAsync();

            if (mascota is null)
            {
                throw new Exception("¡Registro no encontrado!");
            }

            return mascota;
        }

        public async Task CrearAsync(MascotaDTO mascotaDTO)
        {
            var usuario = context.Usuarios
                .Where(u => !u.Borrado)
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.Email == mascotaDTO.EmailUsuario);

            if (usuario is null)
            {
                throw new Exception("¡Usuario no encontrado!");
            }

            //if (usuario.IdRol != 2) -> asi se haria si no usariamos el "Include" de arriba
            if (usuario.Rol.Nombre != "Refugio")
            {
                throw new Exception($"¡El usuario no puede realizar esta acción!");
            }

            // Mapeamos el DTO a la entidad Mascota
            var mascota = new Mascota
            {
                Nombre = mascotaDTO.Nombre,
                Meses = mascotaDTO.Meses,
                Años = mascotaDTO.Años,
                Especie = mascotaDTO.Especie,
                Raza = mascotaDTO.Raza,
                UrlImagen = mascotaDTO.UrlImagen,
                IdUsuario = usuario.Id,
                Descripcion = mascotaDTO.Descripcion
            };

            context.Mascotas.Add(mascota);
            await context.SaveChangesAsync();

            //return Ok(mascotaDTO);
        }

        public async Task ActualizarAsync(int idMascota, MascotaDTO mascotaDTO)
        {
            // Buscar el registro por ID
            var mascota = await context.Mascotas
                .Where(m => !m.Borrado && m.Id == idMascota)
                .FirstOrDefaultAsync();

            if (mascota is null)
            {
                throw new Exception("¡Registro no encontrado!");    //Esto se guarda en el Exception.Message
            }

            // Asigna los nuevos valores a los campos que se pueden modificar
            mascota.Nombre = mascotaDTO.Nombre;
            mascota.Meses = mascotaDTO.Meses;
            mascota.Años = mascotaDTO.Años;
            mascota.Especie = mascotaDTO.Especie;
            mascota.Raza = mascotaDTO.Raza;
            mascota.Descripcion = mascotaDTO.Descripcion;
            //IdUsuario -> no se modifica

            // Aplicamos los cambios en la BD
            await context.SaveChangesAsync();

            //return Ok(mascotaDTO);
        }

        public async Task EliminarAsync(int idMascota)
        {
            // Buscar el registro por ID
            var mascota = await context.Mascotas
                .Where(m => !m.Borrado && m.Id == idMascota)
                .FirstOrDefaultAsync();

            if (mascota is null)
            {
                throw new Exception("¡Registro no encontrado!");
            }

            //Damos de baja logica el registro
            mascota.Borrado = true;

            // Aplicamos los cambios en la BD
            await context.SaveChangesAsync();

            //return Ok("¡Registro eliminado con exito!");
        }
    }
}
