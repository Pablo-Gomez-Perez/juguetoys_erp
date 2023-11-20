using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class ProductosXVenta
{
    public int Id { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int FldCantidad { get; set; }

    public decimal FldSubTotal { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
