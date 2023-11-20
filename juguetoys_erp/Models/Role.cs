using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string FldNombre { get; set; } = null!;

    public string FldDescripcion { get; set; } = null!;

    public virtual ICollection<PermisosXRol> PermisosXRols { get; set; } = new List<PermisosXRol>();
}
