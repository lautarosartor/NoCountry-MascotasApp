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
        /*
        private readonly AppDbContext context;

        public MascotaRepository(AppDbContext context)
        {
            this.context = context;
        }
        */
        public async Task<IEnumerable<GetMascotaDTO>> LeerTodoAsync()
        {
            var mascotas = await context.Mascotas
                .Where(m => !m.Borrado)
                .Select(m => new GetMascotaDTO
                {
                    // Si utilizaramos la extension Mapper, a esto lo hace automaticamente
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    NombreUsuario = m.Usuario.Nombre, // Navegamos por usuario hasta el nombre
                    // Estos 4 datos de abajo podriamos no mostrarlos y q se visualicen como "vacios" para no hacer miles de DTOs
                    Edad = m.Edad,
                    Raza = m.Raza,
                    Descripcion = m.Descripcion,
                    Estado = m.Estado
                })
                .ToListAsync();

            return mascotas;
        }

        public async Task<GetMascotaDTO> LeerUnoAsync(int idMascota)
        {
            var mascota = await context.Mascotas
                .Where(m => !m.Borrado && m.Id == idMascota)    //.Include(u => u.Usuario)
                .Select(m => new GetMascotaDTO
                {
                    Id = m.Id,
                    Nombre = m.Nombre,
                    Especie = m.Especie,
                    NombreUsuario = m.Usuario.Nombre, // Navegamos por usuario hasta el nombre
                    Edad = m.Edad,
                    Raza = m.Raza,
                    Descripcion = m.Descripcion,
                    Estado = m.Estado
                })
                .FirstOrDefaultAsync();

            if (mascota is null)
            {
                Results.NotFound("¡Registro no encontrado!");
            }

            return mascota;
        }

        public async Task CrearAsync(MascotaDTO mascotaDTO)
        {
            // Mapeamos el DTO a la entidad Mascota
            var mascota = new Mascota
            {
                Nombre = mascotaDTO.Nombre,
                Edad = mascotaDTO.Edad,
                Especie = mascotaDTO.Especie,
                Raza = mascotaDTO.Raza,
                IdUsuario = mascotaDTO.IdUsuario,
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
                .FirstOrDefaultAsync(m => m.Id == idMascota);

            if (mascota is null)
            {
                Results.NotFound("¡Registro no encontrado!");
            }

            // Asigna los nuevos valores a los campos que se pueden modificar
            mascota.Nombre = mascotaDTO.Nombre;
            mascota.Edad = mascotaDTO.Edad;
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
                .FirstOrDefaultAsync(m => m.Id == idMascota);

            if (mascota is null)
            {
                Results.NotFound("¡Registro no encontrado!");
            }

            // Eliminamos el registro
            context.Mascotas.Remove(mascota);

            // Aplicamos los cambios en la BD
            await context.SaveChangesAsync();

            //return Ok("¡Registro eliminado con exito!");
        }
    }
}
