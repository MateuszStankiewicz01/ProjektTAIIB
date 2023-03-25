using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public String Row { get; set; }
        [Required]
        [StringLength(20)]
        public String Column { get; set; }
        [Required]
        [StringLength(20)]
        public String Sector { get; set; }
    }
}
