using Autokuca.Model;
using System.Threading.Tasks;

namespace Autokuca.Repository.Common
{
    public interface IRepository
    {
        Task<IEnumerable<Salon>> GetAll(string? naziv);
        Task<Salon> DohvatiSalon(int id);

        Task<bool> AzurirajSalon(Salon Salon);

        Task<bool> IzbrisiSalon(Salon Salon);

        Task<bool> NapraviSalon(Salon Salon);

        ////////
        Task<IEnumerable<Vozilo>> DohvatiVozila(
            int? id_salona,
            string? sifra_vozila,
            string? tip_vozila,
            string? proizvodac,
            string? oznaka_vozila,
            int? god_proizvodnje,
            string? snaga_motora
            );
        Task<Vozilo> DohvatiVozilo(int id);

        Task<bool> AzurirajVozilo(Vozilo Vozilo);

        Task<bool> IzbrisiVozilo(Vozilo Vozilo);

        Task<bool> NapraviVozilo(Vozilo Vozilo);
    }
}
