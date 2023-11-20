using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string FldCodigo { get; set; } = null!;

    public string FldNombre { get; set; } = null!;

    public decimal FldCosto { get; set; }

    public decimal FldPrecio { get; set; }

    public int FldExistencia { get; set; }

    public bool FldActivo { get; set; }

    public virtual ICollection<ProductosXVenta> ProductosXVenta { get; set; } = new List<ProductosXVenta>();
}
