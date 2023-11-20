using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string FldControlador { get; set; } = null!;

    public string FldAccion { get; set; } = null!;

    public string FldNombre { get; set; } = null!;

    public bool FldActivo { get; set; }

    public virtual ICollection<PermisosXRol> PermisosXRols { get; set; } = new List<PermisosXRol>();
}
