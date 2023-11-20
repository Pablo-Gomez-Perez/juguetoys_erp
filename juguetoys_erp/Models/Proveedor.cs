using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string FldNombre { get; set; } = null!;

    public string FldDireccion { get; set; } = null!;

    public string FldTelefono { get; set; } = null!;

    public bool FldActivo { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
