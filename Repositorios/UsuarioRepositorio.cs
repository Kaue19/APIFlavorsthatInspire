using Api.Data;
using Api.Models;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Api.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;

        public UsuarioRepositorio(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuario.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int id)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.UsuarioId == id);
        }

        public async Task<UsuarioModel> Login(string email , string password )
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Email == email && x.Senha == password);
        }

        public async Task<UsuarioModel> CadastrarUsuario(UsuarioModel usuario)
        {
            // Verificar se o e-mail já está cadastrado
            var usuarioExistente = await _dbContext.Usuario.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (usuarioExistente != null)
            {
                throw new Exception("E-mail já cadastrado.");
            }

            // Verificar se as senhas coincidem
            if (usuario.Senha != usuario.ConfirmarSenha)
            {
                throw new Exception("As senhas não coincidem.");
            }

            // Criar o usuário no banco de dados (sem fazer hash na senha)
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }


        public async Task<UsuarioModel> InsertUsuario(UsuarioModel usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<UsuarioModel> UpdateUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }
            else
            {
                usuarios.NomeUsuario = usuario.NomeUsuario;
                usuarios.Telefone = usuario.Telefone;
                usuarios.Email = usuario.Email;
                usuarios.Endereco = usuario.Endereco;
                usuarios.ConfirmarSenha = usuario.Senha;
                usuarios.Senha= usuario.Senha;
                _dbContext.Usuario.Update(usuarios);
                await _dbContext.SaveChangesAsync();
            }
            return usuarios;

        }

        public async Task<bool> DeleteUsuario(int id)
        {
            UsuarioModel usuarios = await GetById(id);
            if (usuarios == null)
            {
                throw new Exception("Não encontrado.");
            }

            _dbContext.Usuario.Remove(usuarios);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
