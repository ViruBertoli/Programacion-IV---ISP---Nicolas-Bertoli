using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlanCanjeWeb.Models
{
    public class Equipoafectado
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public string Cliente { get; set; } = string.Empty;

        [Required]
        [DisplayName("Modelo del Drive")]
        public string ModeloDrive { get; set; } = string.Empty;

        [Required]
        [DisplayName("Número de Serie")]
        public string NumeroSerie { get; set; } = string.Empty;

        [Required]
        [DisplayName("Fecha de Fabricación")]
        [RegularExpression(@"^\d{2}[A-Za-z]{1}$", ErrorMessage = "La fecha de fabricación debe contener 2 números y 1 letra.")]
        public string FechaFabricacion { get; set; } = string.Empty;

        [Required]
        [DisplayName("Falla Declarada")]
        public string FallaDeclarada { get; set; } = string.Empty;

        [Required]
        [DisplayName("Correo Electrónico")]
        [EmailAddress]
        public string CorreoElectronico { get; set; } = string.Empty;
    }
}
