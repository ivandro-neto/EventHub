using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Communication.Requests
{
    public class AccountCreateRequestJson
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty ;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string ContactInfo { get; set; } = string.Empty;


    }
}
