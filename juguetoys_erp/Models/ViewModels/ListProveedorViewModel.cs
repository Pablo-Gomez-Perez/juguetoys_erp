using System.ComponentModel.DataAnnotations;

namespace juguetoys_erp.Models.ViewModels
{
    public class ListProveedorViewModel
    {
        [Key]
        public int IdProveedor { get; set; }

        public string FldNombre { get; set; } = null!;

        public string FldTelefono { get; set; } = null!;

        public string FldDireccion { get; set; } = null!;
        //public string FldActivo { get; set; } = null!;
    }
}
