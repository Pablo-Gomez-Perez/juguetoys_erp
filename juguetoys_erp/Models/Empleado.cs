using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdRol { get; set; }

    public string FldNombre { get; set; } = null!;

    public string FldTelefono { get; set; } = null!;

    public string FldDireccion { get; set; } = null!;

    public string FldPassword { get; set; } = null!;

    public bool FldActivo { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
