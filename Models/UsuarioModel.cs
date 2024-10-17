namespace Api.Models
{
    public class UsuarioModel
    {
        public int UsuarioId { get; set; }

        public string NomeUsuario { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;

    }
}
