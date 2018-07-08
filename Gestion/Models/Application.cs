using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gestion.Models
{
    public class Application : BaseModel
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
       
    }
}