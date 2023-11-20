using System;
using System.Collections.Generic;

namespace juguetoys_erp.Models;

public partial class PermisosXRol
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public int IdPermiso { get; set; }

    public virtual Permiso IdPermisoNavigation { get; set; } = null!;

    public virtual Role IdRolNavigation { get; set; } = null!;
}
