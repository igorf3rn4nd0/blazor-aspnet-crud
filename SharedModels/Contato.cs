namespace SharedModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("contato")]
public class Contato
{
    [Key]
    [Column("id_contato")]
    public int Id { get; set; }

    [Column("id_cliente")]
    public int IdCliente { get; set; }

    [Column("cli_nome")]
    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Column("cli_email")]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Column("cli_telefone")]
    [StringLength(20)]
    public string Telefone { get; set; }

    [Column("cli_cargo")]
    [StringLength(50)]
    public string Cargo { get; set; }

    [ForeignKey("IdCliente")]
    public Cliente Cliente { get; set; }
}