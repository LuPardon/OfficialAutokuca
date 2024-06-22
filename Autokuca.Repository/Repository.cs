using Autokuca.DAL;
using Autokuca.Model;
using Autokuca.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Autokuca.Repository;

public class Repository : IRepository
{
    private readonly AutoKucaContext _context;
    public Repository(AutoKucaContext context)
    {
        _context = context;
    }

    public async Task<bool> AzurirajSalon(Salon Salon)
    {
        try
        {
            var existing = await _context.Saloni.FindAsync(Salon.IdSalona);

            if (existing == null)
            {
                return false;
            }

            existing.NazivSalona = Salon.NazivSalona;


            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> AzurirajVozilo(Vozilo Vozilo)
    {
        try
        {
            var existing = await _context.Vozila.FindAsync(Vozilo.IdVozilo);

            if (existing == null)
            {
                return false;
            }

            existing.IdSalona = Vozilo.IdSalona;
            // existing.SifraVozila = Vozilo.SifraVozila;
            existing.TipVozila = Vozilo.TipVozila;
            existing.Proizvodac = Vozilo.Proizvodac;
            existing.OznakaVozila = Vozilo.OznakaVozila;
            existing.GodProizvodnje = Vozilo.GodProizvodnje;
            existing.SnagaMotora = Vozilo.SnagaMotora;

            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Salon> DohvatiSalon(int id)
    {
        try
        {
            var task = await _context.Saloni.FirstOrDefaultAsync(t => t.IdSalona == id);
            return (task is null) ? null : task;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Vozilo>> DohvatiVozila(
        int? id_salona,
        // string? sifra_vozila,
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
        try
        {
            var query = _context.Vozila.AsQueryable();

            if (id_salona.HasValue)
            {
                query = query.Where(v => v.IdSalona == id_salona);
            }

            if (!string.IsNullOrEmpty(model_vozila))
            {
                query = query.Where(s =>
                s.ModelVozila != null &&
                s.ModelVozila.Contains(model_vozila));
            }

            if (!string.IsNullOrEmpty(snaga_motora))
            {
                query = query.Where(s =>
                s.SnagaMotora != null &&
                s.SnagaMotora.Contains(snaga_motora));
            }

              if (!string.IsNullOrEmpty(vrsta_vozila))
            {
                query = query.Where(s =>
                s.VrstaVozila != null &&
                s.VrstaVozila.Contains(vrsta_vozila));
            }

              if (!string.IsNullOrEmpty(mjenjac))
            {
                query = query.Where(s =>
                s.Mjenjac != null &&
                s.Mjenjac.Contains(mjenjac));
            } 
            
             if (!string.IsNullOrEmpty(gorivo))
            {
                query = query.Where(s =>
                s.Gorivo != null &&
                s.Gorivo.Contains(gorivo));
            }

            if (cijena.HasValue)
            {
                query = query.Where(v => v.Cijena == cijena);
            }

            if (!string.IsNullOrEmpty(tip_vozila))
            {
                query = query.Where(s =>
                s.TipVozila != null &&
                s.TipVozila.Contains(tip_vozila));
            }

            if (!string.IsNullOrEmpty(proizvodac))
            {
                query = query.Where(s =>
                s.Proizvodac != null &&
                s.Proizvodac.Contains(proizvodac));
            }

            if (!string.IsNullOrEmpty(oznaka_vozila))
            {
                query = query.Where(s =>
                s.OznakaVozila != null &&
                s.OznakaVozila.Contains(oznaka_vozila));
            }

            if (god_proizvodnje.HasValue)
            {
                query = query.Where(v => v.GodProizvodnje == god_proizvodnje);
            }

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Vozilo> DohvatiVozilo(int id)
    {
        try
        {
            var vozilo = await _context.Vozila.FirstOrDefaultAsync(t => t.IdVozilo == id);
            return (vozilo is null) ? null : vozilo;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<IEnumerable<Salon>> GetAll(
        string? naziv)
    {
        try
        {
            var query = _context.Saloni.AsQueryable();
            if (!string.IsNullOrEmpty(naziv))
            {
                query = query.Where(s =>
                s.NazivSalona != null &&
                s.NazivSalona.Contains(naziv));
            }

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> IzbrisiSalon(Salon Salon)
    {
        try
        {
            var existing = await _context.Saloni.FindAsync(Salon.IdSalona);

            if (existing is null)
            {
                return false;
            }

            _context.Saloni.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> IzbrisiVozilo(Vozilo Vozilo)
    {
        try
        {
            var existing = await _context.Vozila.FindAsync(Vozilo.IdVozilo);

            if (existing is null)
            {
                return false;
            }

            _context.Vozila.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> NapraviSalon(Salon Salon)
    {
        try
        {
            await _context.Saloni.AddAsync(Salon);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> NapraviVozilo(Vozilo Vozilo)
    {
        try
        {
            await _context.Vozila.AddAsync(Vozilo);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}