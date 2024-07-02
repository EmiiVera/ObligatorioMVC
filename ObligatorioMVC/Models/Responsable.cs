using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class Responsable : Usuario
    {
        [Required]
        public double Sueldo { get; set; }
        public Local? Local { get; set; }
    }
}
