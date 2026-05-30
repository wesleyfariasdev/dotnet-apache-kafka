namespace Biblioteca.Web.Data.Models;

public sealed class Perfil
{
    public Perfil(Guid id,
                 string? nome,
                 int? livrosDoados,
                 int? livrosAdotados,
                 bool perfilAtivo)
    {
        Id = id;
        Nome = nome;
        LivrosDoados = livrosDoados;
        LivrosAdotados = livrosAdotados;
        PerfilAtivo = perfilAtivo;
    }

    public Guid Id { get; private set; }
    public string? Nome { get; private set; }
    public int? LivrosDoados { get; private set; }
    public int? LivrosAdotados { get; private set; }
    public bool PerfilAtivo { get; private set; }

    public void AtivarPerfil() => PerfilAtivo = true;
    public void DesativarPerfil() => PerfilAtivo = false;
    public void AtualizarNome(string? nome) => Nome = nome;
    public void AtualizarLivrosDoados(int? livrosDoados) => LivrosDoados = livrosDoados;
    public void AtualizarLivrosAdotados(int? livrosAdotados) => LivrosAdotados = livrosAdotados;
}
