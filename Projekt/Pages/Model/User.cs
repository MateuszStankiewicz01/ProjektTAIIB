using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Pages.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]

        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        [Required]
        [StringLength(11)]
        public string Pesel { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public virtual Karnet? Karnet { get; set; }

        public IEnumerable<Ticket> Ticket { get; set; }
    }
}
