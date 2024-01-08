using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Registro
    {
        public int ID { get; set; }
        [DisplayName("Nombre del registro")]
        public string NombreRegistro { get; set; }
        public decimal Monto { get; set; }
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        [DisplayName("Fecha")]
        public DateTime FechaRegistro { get; set; }
    }
}
