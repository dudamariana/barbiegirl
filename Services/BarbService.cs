using System.Text.Json;
using barbiegirl.Models;

namespace barbiegirl.Services;
public class BarbService : IBarbService
{
    private readonly IHttpContextAccessor _session;
    private readonly string barbieFile = @"Data\barbies.json";
    private readonly string tiposFile = @"Data\tipos.json";
    public BarbService(IHttpContextAccessor session)
    {
        _session = session;
        PopularSessao();
    }
    public List<Barbie> GetBarbies()
    {
        PopularSessao();
        var barbies = JsonSerializer.Deserialize<List<Barbie>>
        (_session.HttpContext.Session.GetString("Barbies"));
        return barbies;
    }
    public List<Tipo> GetTipos()
    {
        PopularSessao();
        var tipos = JsonSerializer.Deserialize<List<Tipo>>
        (_session.HttpContext.Session.GetString("Tipos"));
        return tipos;
    }
    public Barbie GetBarbie(int Numero)
    {
        var barbies = GetBarbies();
        return barbies.Where(p => p.Numero == Numero).FirstOrDefault();
    }
    public BarbiegirlDto GetBarbiegirlDto()
    {
        var barb = new BarbiegirlDto()
        {
            Barbies = GetBarbies(),
            Tipos = GetTipos()
        };
        return barb;
    }
    public DetailsDto GetDetailedBarbie(int Numero)
    {
        var barbies = GetBarbies();
        var barb = new DetailsDto()
        {
            Current = barbies.Where(p => p.Numero == Numero)
        .FirstOrDefault(),
            Prior = barbies.OrderByDescending(p => p.Numero)
        .FirstOrDefault(p => p.Numero < Numero),
            Next = barbies.OrderBy(p => p.Numero)
        .FirstOrDefault(p => p.Numero > Numero),
        };
        return barb;
    }
    public Tipo GetTipo(string Nome)
    {
        var tipos = GetTipos();
        return tipos.Where(t => t.Nome == Nome).FirstOrDefault();
    }
    private void PopularSessao()
    {
        if (string.IsNullOrEmpty(_session.HttpContext.Session.GetString("Tipos")))
        {
            _session.HttpContext.Session
            .SetString("Barbies", LerArquivo(barbieFile));
            _session.HttpContext.Session
            .SetString("Tipos", LerArquivo(tiposFile));
        }
    }
    private string LerArquivo(string fileName)
    {
        using (StreamReader leitor = new StreamReader(fileName))
        {
            string dados = leitor.ReadToEnd();
            return dados;
        }
    }
}