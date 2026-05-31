namespace Biblioteca.Web.Data.Models;

public sealed class Perfil : BaseModel
{
    private Perfil() { }

    public Perfil(Guid id,
                 string? nome,
                 int? livrosDoados,
                 int? livrosAdotados,
                 bool perfilAtivo,
                 Guid userId)
    {
        Id = id;
        Nome = nome;
        LivrosDoados = livrosDoados;
        LivrosAdotados = livrosAdotados;
        PerfilAtivo = perfilAtivo;
        UserId = userId;
        CriadoEm = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }
    public string? Nome { get; private set; }
    public int? LivrosDoados { get; private set; }
    public int? LivrosAdotados { get; private set; }
    public bool PerfilAtivo { get; private set; }
    public Guid UserId { get; private set; }

    public void AtivarPerfil() { PerfilAtivo = true; AtualizadoEm = DateTime.UtcNow; }
    public void DesativarPerfil() { PerfilAtivo = false; AtualizadoEm = DateTime.UtcNow; }
    public void AtualizarNome(string? nome) { Nome = nome; AtualizadoEm = DateTime.UtcNow; }
    public void AtualizarLivrosDoados(int? livrosDoados) { LivrosDoados = livrosDoados; AtualizadoEm = DateTime.UtcNow; }
    public void AtualizarLivrosAdotados(int? livrosAdotados) { LivrosAdotados = livrosAdotados; AtualizadoEm = DateTime.UtcNow; }
}
