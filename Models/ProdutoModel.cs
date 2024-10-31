using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Models
{
    public class ProdutoModel
    {
        public int ProdutoId { get; set; }

        public string ProdutoNome { get; set; } = string.Empty;

        public string ProdutoFoto { get; set; } = string.Empty;

        public string ProdutoDescricao { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public double ProdutoPreco { get; set; } 
        public double ProdutoDesconto { get; set; }
    }
}
