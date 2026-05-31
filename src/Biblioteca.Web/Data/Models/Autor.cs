namespace Biblioteca.Web.Data.Models;

public sealed class Autor : BaseModel
{
    private Autor() { }

    public Autor(string? nome,
                 Guid id,
                 string? biografia)
    {
        Nome = nome;
        Id = id;
        Biografia = biografia;
    }

    public string? Nome { get; private set; }
    public Guid Id { get; private set; }
    public string? Biografia { get; private set; }
}