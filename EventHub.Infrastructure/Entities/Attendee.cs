using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Infrastructure.Entities;
public class Attendee
{
    [Key]
    public Guid ID_Attendee { get; set; }

    public Guid ID_Account { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; }

    public string Address { get; set; }

    public string ContactInfo { get; set; }

    public string AccountType { get; set; }

    [ForeignKey("ID_Account")]
    public Account Account { get; set; }
}