using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class ClienteViewModel
    {
        [Key]       
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="Preencha o campo nome.")]
        [MaxLength(255,ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2,ErrorMessage ="Mínimo de {0} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome.")]
        [MaxLength(255, ErrorMessage = "Máximo de {0} caracteres.")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail.")]
        [MaxLength(255, ErrorMessage = "Máximo de {0} caracteres.")]
        [EmailAddress(ErrorMessage ="Insira um e-mail válido.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        //[ScaffoldColumn(false)]
        //public virtual IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
