using Autokuca.Model;
using Autokuca.Repository.Common;
using Autokuca.Service.Common;

namespace Autokuca.Service;

public class Service : IService
{
    private readonly IRepository _repository;
    public Service(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Salon>> GetAll(string? naziv)
    {
        return await _repository.GetAll(naziv);
    }
    public async Task<Salon> DohvatiSalon(int id)
    {
        return await _repository.DohvatiSalon(id);
    }

    public async Task<bool> AzurirajSalon(Salon Salon)
    {
        return await _repository.AzurirajSalon(Salon);
    }

    public async Task<bool> IzbrisiSalon(Salon Salon)
    {
        return await _repository.IzbrisiSalon(Salon);
    }

    public async Task<bool> NapraviSalon(Salon Salon)
    {
        return await _repository.NapraviSalon(Salon);
    }

    public async Task<IEnumerable<Vozilo>> DohvatiVozila(
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
        string? gorivo)
        
    {
        return await _repository.DohvatiVozila(
            id_salona: id_salona,
            tip_vozila: tip_vozila,
            proizvodac: proizvodac,
            oznaka_vozila: oznaka_vozila,
            god_proizvodnje: god_proizvodnje,
            snaga_motora: snaga_motora,
            model_vozila: model_vozila,
            cijena: cijena,
            vrsta_vozila: vrsta_vozila,
            mjenjac: mjenjac,
            gorivo: gorivo);
    }

    public async Task<Vozilo> DohvatiVozilo(int id)
    {
        return await _repository.DohvatiVozilo(id);
    }

    public async Task<bool> AzurirajVozilo(Vozilo Vozilo)
    {
        return await _repository.AzurirajVozilo(Vozilo);
    }

    public async Task<bool> IzbrisiVozilo(Vozilo Vozilo)
    {
        return await _repository.IzbrisiVozilo(Vozilo);
    }

    public async Task<bool> NapraviVozilo(Vozilo Vozilo)
    {
        return await _repository.NapraviVozilo(Vozilo);
    }
}
