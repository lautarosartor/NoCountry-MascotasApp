using System.Collections.Generic;
using System.Threading.Tasks;
using webAPI.DTOs;
using webAPI.Models;
using webAPI.Repositories;

namespace webAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuariosAsync()
        {
            return await _usuarioRepository.GetUsuariosAsync();
        }
        public async Task<UsuarioDTO> GetUsuarioByIdAsync(int id)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id);
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public async Task<Usuario> UpdateUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.UpdateUsuarioAsync(usuario);
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            return await _usuarioRepository.DeleteUsuarioAsync(id);
        }
    }
}