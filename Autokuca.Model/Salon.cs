using System;
using System.Collections.Generic;

namespace Autokuca.Model;
public partial class Salon
{
    public int IdSalona { get; set; }

    public string? NazivSalona { get; set; }

    public virtual ICollection<Vozilo> Vozilos { get; set; } = new List<Vozilo>();
}
