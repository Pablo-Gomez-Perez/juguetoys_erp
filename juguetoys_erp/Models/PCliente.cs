using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class PCliente
{
    public int IdCliente { get; set; }

    public string FldNombre { get; set; } = null!;

    public string FldTelefono { get; set; } = null!;

    public string FldDireccion { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
