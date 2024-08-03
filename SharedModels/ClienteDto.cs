namespace SharedModels;
public class ClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataFundacao { get; set; }
    public bool Ativo { get; set; }
}