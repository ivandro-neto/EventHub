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
    [Column("AttendeeID")]
    public Guid AttendeeID { get; set; }

    [Column("AccountID")]
    public Guid AccountID { get; set; }
    public Account Account { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(10)]
    public string Gender { get; set; }

    [Required]
    [MaxLength(255)]
    public string Address { get; set; }

    [MaxLength(255)]
    public string ContactInfo { get; set; }

    [Required]
    [MaxLength(50)]
    public string AccountType { get; set; }
}

