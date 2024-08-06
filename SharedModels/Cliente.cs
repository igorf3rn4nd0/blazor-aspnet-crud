namespace SharedModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("cliente")]
public class Cliente
{
    [Key]
    [Column("id_cliente")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("cli_nome")]
    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Column("cli_cnpj")]
    [Required]
    [StringLength(14)]
    public string Cnpj { get; set; }

    [Column("cli_data_fundacao")]
    [Required]
    public DateOnly DataFundacao { get; set; }

    [Column("cli_ativo")]
    [Required]
    public bool Ativo { get; set; }
    
    public ICollection<Contato> Contatos { get; set; }
}