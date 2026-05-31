namespace Biblioteca.Web.Data.Models;

public sealed class Categoria : BaseModel
{
    private Categoria() { }
    public Categoria(Guid id, 
                     string? nome)
    {
        Id = id;
        Nome = nome;
    }

    public Guid Id { get; private set; }
    public string? Nome { get; private set; }

    public void AtualizarNome(string? nome)
    {
        Nome = nome;
        AtualizadoEm = DateTime.UtcNow;
    }
}
