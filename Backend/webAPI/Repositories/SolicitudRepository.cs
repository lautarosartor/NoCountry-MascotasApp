using Microsoft.EntityFrameworkCore;
using webAPI.Database;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories.Interfaces;

namespace webAPI.Repositories
{
    public class SolicitudRepository(AppDbContext context) : ISolicitudRepository
    {
        // Podemos hacer una query sobre la url -> api/Solicitud/example@gmail.com (obtenemos las solicitudes realizadas por ese usuario)
        // Si no ponemos nada devuelve todas las solicitudes que hayan en la base de datos
        public async Task<IEnumerable<GetSolicitudDTO>> Get(int? idMascota, string? estado, string email = null)
        {
            // Iniciar la consulta con las inclusiones necesarias
            var query = context.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Mascota)
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
                    query = query.Where(s => s.Usuario.Email == email);
                }
            }

            if (idMascota != null)
            {
                var mascota = await context.Mascotas.FirstOrDefaultAsync(u => u.Id == idMascota);

                if (mascota is null)
                {
                    throw new Exception("*Publicación no encontrado*");
                }
                else
                {
                    query = query.Where(s => s.Mascota.Id == idMascota);
                }
            }

            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(s => s.Estado == estado);
            }

            // Proyectar los resultados en el DTO
            var solicitudes = await query
                .Select(s => new GetSolicitudDTO
                {
                    Id = s.Id,
                    NombreUsuario = s.Usuario.Nombre + " " + s.Usuario.Apellido,
                    NombreMascota = s.Mascota.Nombre,
                    IdUsuario = s.Usuario.Id,
                    IdMascota = s.Mascota.Id,
                    Fecha = s.Fecha,
                    Estado = s.Estado
                })
                .OrderByDescending(s => s.Estado == "Pendiente")
                .ToListAsync();

            return solicitudes;
        }

        public async Task<GetSolicitudDTO> LeerUnoAsync(int idSolicitud)
        {
            var solicitud = await context.Solicitudes
                .Where(s => s.Id == idSolicitud)
                .Select(s => new GetSolicitudDTO
                {
                    Id = s.Id,
                    NombreUsuario = s.Usuario.Nombre + " " + s.Usuario.Apellido,
                    NombreMascota = s.Mascota.Nombre,
                    Fecha = s.Fecha,
                    Estado = s.Estado
                })
                .FirstOrDefaultAsync();

            if (solicitud is null)
            {
                throw new Exception("¡Registro no encontrado!");
            }

            return solicitud;
        }

        public async Task CrearAsync(SolicitudDTO solicitudDTO)
        {
            //Buscar el usuario en la BD mediante su ID
            var usuario = context.Usuarios
                .Where(u => !u.Borrado)
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.Email == solicitudDTO.EmailUsuario);

            if (usuario is null)
            {
                throw new Exception("¡Usuario no encontrado!");
            }

            //if (usuario.IdRol != 3) -> asi se haria si no usariamos el "Include" de arriba
            if (usuario.Rol.Nombre != "Cliente")
            {
                throw new Exception($"¡El usuario no puede realizar esta acción!");
            }

            //Buscar la mascota en la BD mediante su ID
            var mascota = context.Mascotas
                .Where(m => !m.Borrado)
                .FirstOrDefault(m => m.Id == solicitudDTO.IdMascota);

            if (mascota is null)
            {
                throw new Exception("¡Mascota no encontrada!");
            }

            if (mascota.Estado != "Disponible")
            {
                throw new Exception($"¡La mascota no esta disponible!");
            }

            //Crear la solicitud
            Solicitud solicitud = new Solicitud
            {
                IdUsuario = usuario.Id,
                IdMascota = mascota.Id,
                //Por default la fecha es la actual
                //Por default el estado va a ser pendiente
            };

            //Automaticamente cuando se solicita la adopcion, la mascota buscada por ID pasa a estar solicitada
            mascota.Estado = "Solicitada";

            context.Solicitudes.Add(solicitud);
            await context.SaveChangesAsync();   //Aplicamos los cambios a la BD
        }

        public async Task ConfirmarCancelarAsync(int idSolicitud, EstadoSolicitudDTO estadoSolicitudDTO)
        {
            var solicitud = context.Solicitudes
                .Where(s => s.Estado == "Pendiente")    //Para no poder alternar estados de otras solicitudes q ya hayan sido aprobada o rechazadas
                .Include(s => s.Mascota)
                .FirstOrDefault(s => s.Id == idSolicitud);

            if (solicitud is null)
            {
                throw new Exception("¡Registro no encontrado!");
            }

            //Editar el estado de la reserva
            if (estadoSolicitudDTO.Estado == "Aprobada")
            {
                solicitud.Estado = estadoSolicitudDTO.Estado;
                solicitud.Mascota.Estado = "Adoptada";
            }
            else if (estadoSolicitudDTO.Estado == "Rechazada")
            {
                solicitud.Estado = estadoSolicitudDTO.Estado;
                solicitud.Mascota.Estado = "Disponible";
            }
            else if (estadoSolicitudDTO.Estado == "Cancelada")
            {
                solicitud.Estado = estadoSolicitudDTO.Estado;
                solicitud.Mascota.Estado = "Disponible";
            }
            else
                throw new Exception("Posibles estados: Aprobada / Rechazada / Cancelada");

            //Aplicamos los cambios a la BD
            await context.SaveChangesAsync();
        }
    }
}
