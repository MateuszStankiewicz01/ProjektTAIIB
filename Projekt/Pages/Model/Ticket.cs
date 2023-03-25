using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual EventSeat EventSeat { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
