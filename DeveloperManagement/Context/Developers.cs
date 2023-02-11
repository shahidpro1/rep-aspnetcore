using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperManagement.Context
{
    public class Developers
    {
        // lets add some fields
        [Key]
        public int DeveloperId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public String JobTitle { get; set; }

    }
}
