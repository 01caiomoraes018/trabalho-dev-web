using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trabalho1DevWebNet.Validation;

namespace Trabalho1DevWebNet.Models;

public class Paciente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(14, MinimumLength = 11, ErrorMessage = "Informe um CPF válido.")]
    [CpfValido]
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "Informe um telefone válido.")]
    [RegularExpression(@"(?:\([1-9][0-9]\) ?|[1-9][0-9] ?)(?:[2-5][0-9]{3}|9[0-9]{4})-?[0-9]{4}", ErrorMessage = "Informe um telefone com DDD, como (18) 99999-1111.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "O endereço deve ter entre 5 e 200 caracteres.")]
    [Display(Name = "Endereço")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    [DataType(DataType.Date)]
    [DataNascimentoValida]
    [Column(TypeName = "date")]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
}
