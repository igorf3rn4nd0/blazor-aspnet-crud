namespace SharedModels;
public class ContatoDto
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Cargo { get; set; }
}