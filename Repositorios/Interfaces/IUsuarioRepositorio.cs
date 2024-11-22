using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> GetAll();

        Task<UsuarioModel> GetById(int id);

        Task<UsuarioModel> Login(string email , string password );

        Task<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);

        Task<UsuarioModel> InsertUsuario(UsuarioModel usuario);

        Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id);

        Task<bool> DeleteUsuario(int id);
    }
}
