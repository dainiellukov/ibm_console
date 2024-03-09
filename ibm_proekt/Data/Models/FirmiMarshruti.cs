using System;
using System.Collections.Generic;

namespace ibm_proekt.Data.Models;

public partial class FirmiMarshruti
{
    public int FirmaId { get; set; }

    public int MarshrutId { get; set; }

    public virtual Firmi Firma { get; set; } = null!;

    public virtual Marshruti Marshrut { get; set; } = null!;
}
