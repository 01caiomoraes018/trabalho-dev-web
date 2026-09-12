using System.ComponentModel.DataAnnotations;

namespace Trabalho1DevWebNet.Validation;

public class DataNascimentoValidaAttribute : ValidationAttribute
{
    public DataNascimentoValidaAttribute()
        : base("Informe uma data de nascimento válida, que não esteja no futuro.") { }

    public override bool IsValid(object? value)
    {
        if (value is null) return true;
        return value is DateTime data && data != default && data.Date <= DateTime.Today;
    }
}
