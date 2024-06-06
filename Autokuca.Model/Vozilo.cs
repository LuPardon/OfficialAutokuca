using System;
using System.Collections.Generic;

namespace Autokuca.Model;
public partial class Vozilo
{
    public int IdVozilo { get; set; }

    public int? IdSalona { get; set; }

    public string? SifraVozila { get; set; }

    public string? TipVozila { get; set; }

    public string? Proizvodac { get; set; }

    public string? OznakaVozila { get; set; }

    public int? GodProizvodnje { get; set; }

    public string? SnagaMotora { get; set; }

    public virtual Salon? IdSalonaNavigation { get; set; }
}
