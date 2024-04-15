using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class CheckIn
{
    [Key]
    [Column("CheckInID")]
    public Guid CheckInID { get; set; }

    [Column("EventID")]
    public Guid EventID { get; set; }
    public Event Event { get; set; }

    [Column("AttendeeID")]
    public Guid AttendeeID { get; set; }
    public Attendee Attendee { get; set; }

    [Required]
    [MaxLength(50)]
    public string State { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CheckInDateTime { get; set; }
}