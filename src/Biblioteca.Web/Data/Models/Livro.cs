namespace Biblioteca.Web.Data.Models;

public sealed class Livro : BaseModel
{
    private Livro() { }

    public Livro(Guid id,
                 string? titulo,
                 string? descricao,
                 Tipo tipo,
                 Guid autorId,
                 Guid perfilId,
                 bool aprovado,
                 bool disponivel,
                 string? imagemUrl)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Tipo = tipo;
        AutorId = autorId;
        PerfilId = perfilId;
        Aprovado = aprovado;
        Disponivel = disponivel;
        ImagemUrl = imagemUrl;
    }

    public Guid Id { get; private set; }
    public string? Titulo { get; private set; }
    public string? Descricao { get; private set; }
    public Tipo Tipo { get; private set; }
    public Guid AutorId { get; private set; }
    public Guid PerfilId { get; private set; }
    public bool Aprovado { get; private set; }
    public bool Disponivel { get; private set; }
    public string? ImagemUrl { get; private set; }

    public Autor? Autor { get; private set; }
}