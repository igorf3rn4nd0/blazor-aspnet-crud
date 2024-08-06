using System.ComponentModel.DataAnnotations;

namespace SharedModels;
public class ClienteDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome do cliente deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    [RegularExpression(@"\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}", ErrorMessage = "O CNPJ deve estar em um formato válido (XX.XXX.XXX/XXXX-XX).")]
    public string Cnpj { get; set; }

    [Required(ErrorMessage = "A data de fundação é obrigatória.")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(ClienteDto), "ValidateDataFundacao")]
    public DateOnly DataFundacao { get; set; }

    public bool Ativo { get; set; }

    public static ValidationResult? ValidateDataFundacao(DateOnly data, ValidationContext context)
    {
        if (data > DateOnly.FromDateTime(DateTime.Today))
        {
            return new ValidationResult("A data de fundação não pode ser no futuro.");
        }
        return ValidationResult.Success;
    }
}