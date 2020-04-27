using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TESH2Project.Models
{
    public class Datos
    {
        [Key,Required,DisplayName("Identificador")]
        public int Id { get; set; }
        [Required, Display(Name ="Nombre del empleado")]
        public string Nombre { get; set; }
        [DisplayName("Compañia")]
        public string Compania { get; set; }
        [Required]
        public int Empleados { get; set; }
    }
}