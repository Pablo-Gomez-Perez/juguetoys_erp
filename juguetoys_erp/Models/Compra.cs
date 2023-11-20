using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public string? FldFolioFactura { get; set; }

    public DateTime FldFecha { get; set; }

    public int IdEmpleado { get; set; }

    public int IdProveedor { get; set; }

    public decimal FldTotal { get; set; }

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
