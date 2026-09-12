using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Trabalho1DevWebNet.Validation;

public class CpfValidoAttribute : ValidationAttribute
{
    public CpfValidoAttribute() : base("Informe um CPF válido.") { }

    public override bool IsValid(object? value)
    {
        if (value is null || value is string { Length: 0 }) return true;
        if (value is not string cpf) return false;
        if (!Regex.IsMatch(cpf, @"\A(?:[0-9]{11}|[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2})\z"))
            return false;

        var numeros = cpf.Replace(".", "").Replace("-", "");
        if (numeros.All(numero => numero == numeros[0])) return false;

        // Cada dígito verificador usa os anteriores com pesos decrescentes.
        for (var tamanho = 9; tamanho <= 10; tamanho++)
        {
            var soma = 0;
            for (var i = 0; i < tamanho; i++)
                soma += (numeros[i] - '0') * (tamanho + 1 - i);

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;
            if (numeros[tamanho] - '0' != digito) return false;
        }

        return true;
    }
}
