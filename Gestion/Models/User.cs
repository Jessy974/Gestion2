using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gestion.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        public string Name { get; set; }

        public int ApplicationID { get; set; }
        [ForeignKey("ApplicationID")]
        public Application Applications { get; set; }

        public string Adress { get; set; }

        public string Tel { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

    
    }
}