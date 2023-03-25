using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        [Required]
        [StringLength(40)]
        public string Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Stuard> Stuard { get; set; }
    }
}
