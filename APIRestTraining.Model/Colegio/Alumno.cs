using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRestTraining.Model.Colegio
{
    public class Alumno
    {
        public int? IdAlumno {  get; set; }
        public string? Nombre { get; set; }
        public string? apellido { get; set; }
        public DateTime? f_Nacimiento { get; set; }
        public int? IdCarrera { get; set; }
        public string? telefono { get; set; }
    }
}
