using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ObligatorioMVC.Models
{
    public class ResponsableLocal : Usuario
    {
        [Required]
        public double Sueldo { get; set; }
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
