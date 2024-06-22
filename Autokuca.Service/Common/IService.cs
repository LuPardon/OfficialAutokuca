using Autokuca.Model;

namespace Autokuca.Service.Common
{
    public interface IService
    {
        Task<IEnumerable<Salon>> GetAll(string? naziv);
        Task<Salon> DohvatiSalon(int id);

        Task<bool> AzurirajSalon(Salon Salon);

        Task<bool> IzbrisiSalon(Salon Salon);

        Task<bool> NapraviSalon(Salon Salon);

        Task<IEnumerable<Vozilo>> DohvatiVozila(
            int? id_salona,
            string? tip_vozila,
            string? proizvodac,
            string? oznaka_vozila,
            int? god_proizvodnje,
            string? snaga_motora,
        string? model_vozila,
        decimal? cijena,
        string? vrsta_vozila,
        string? mjenjac,
        string? gorivo);
        Task<Vozilo> DohvatiVozilo(int id);

        Task<bool> AzurirajVozilo(Vozilo Vozilo);

        Task<bool> IzbrisiVozilo(Vozilo Vozilo);

        Task<bool> NapraviVozilo(Vozilo Vozilo);
    }
}
