using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ApiProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nomedo Produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do Produto não pode exceder 100 caracteres.")]
        public required string Nome { get; set; }
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve estar entre 0.01 e 99999.99.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
        public int Quantidade { get; set; } = 0;
    }
}
