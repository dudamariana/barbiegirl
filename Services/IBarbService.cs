using barbiegirl.Models;
namespace barbiegirl.Services;

public interface IBarbService
{
    List<Barbie> GetBarbies();
    List<Tipo> GetTipos();
    Barbie GetBarbie(int Numero);
    BarbiegirlDto GetBarbiegirlDto();
    DetailsDto GetDetailedBarbie(int Numero);
    Tipo GetTipo(string Nome);
}
    
