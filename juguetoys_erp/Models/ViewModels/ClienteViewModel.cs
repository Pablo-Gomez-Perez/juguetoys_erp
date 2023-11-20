using System.ComponentModel.DataAnnotations;

namespace juguetoys_erp.Models.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int IdCliente { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar el nombre del cliente")]
        public string FldNombre { get; set; } = null!;
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Debe indicar un número de contacto")]
        [MinLength(10,ErrorMessage = "Formato incorrecto")]
        [MaxLength(10, ErrorMessage = "Formato Incorrecto")]
        public string FldTelefono { get; set; } = null!;
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Indique la dirección del cliente")]
        public string FldDireccion { get; set; } = null!;
    }
}
