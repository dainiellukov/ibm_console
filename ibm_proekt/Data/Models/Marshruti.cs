using System;
using System.Collections.Generic;

namespace ibm_proekt.Data.Models;

public partial class Marshruti
{
    public int MarshrutId { get; set; }

    public string ZaminavaOt { get; set; } = null!;

    public string ZaminavaZa { get; set; } = null!;

    public TimeOnly ZaminavaChas { get; set; }

    public TimeOnly PristigaChas { get; set; }
}
