using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class EventSeat
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Taken { get; set; }
        public virtual Seat Seat { get; set; }
        public virtual Event Event { get; set; }
    }
}
