using System.ComponentModel.DataAnnotations;

namespace SharedModels;
public class ContatoDto
{
    public int Id { get; set; }
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "O nome do contato é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome do contato deve ter pelo menos 3 caracteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O email do contato é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email do contato deve estar em um formato válido.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "O telefone do contato deve estar em um formato válido.")]
    public string Telefone { get; set; }

    public string Cargo { get; set; }
}