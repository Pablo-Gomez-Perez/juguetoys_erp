using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class ProductosXCompra
{
    public int Id { get; set; }

    public int IdCompra { get; set; }

    public int IdProducto { get; set; }

    public int FldCantidad { get; set; }

    public decimal FldSubtotal { get; set; }
}
