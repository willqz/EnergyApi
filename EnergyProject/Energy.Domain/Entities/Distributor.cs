using System;
using System.Collections.Generic;

namespace Energy.Domain.Entities;

public partial class Distributor
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime DateCreate { get; set; }
}
