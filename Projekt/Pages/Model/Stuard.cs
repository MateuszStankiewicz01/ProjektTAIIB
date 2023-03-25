using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class Stuard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public String Name { get; set; }
        public ICollection<Event> Event { get; set; }
    }
}
