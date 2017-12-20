using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarteleraApi.Models
{
    public class DataNotetation
    {


    }

    public class actoresNotation
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }

    }
    [MetadataType(typeof(actoresNotation))]
    public partial class Actores
    {

    }
}