using System.ComponentModel.DataAnnotations;

namespace juguetoys_erp.Models.ViewModels
{
    public class ListClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }

        public string FldNombre { get; set; } = null!;

        public string FldTelefono { get; set; } = null!;

        public string FldDireccion { get; set; } = null!;
    }
}
