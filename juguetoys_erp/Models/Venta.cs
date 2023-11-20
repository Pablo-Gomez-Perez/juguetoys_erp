using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime FldFecha { get; set; }

    public int IdEmpleado { get; set; }

    public int IdCliente { get; set; }

    public decimal FldTotal { get; set; }

    public bool FldActivo { get; set; }

    public virtual PCliente IdClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual ICollection<ProductosXVenta> ProductosXVenta { get; set; } = new List<ProductosXVenta>();
}
