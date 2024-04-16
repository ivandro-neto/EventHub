using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class CheckIn
{
    [Key]
    public Guid ID_CheckIn { get; set; }

    public Guid ID_Event { get; set; }

    public Guid ID_Attendee { get; set; }

    public string State { get; set; }

    public DateTime CheckInDateTime { get; set; }

    [ForeignKey("ID_Event")]
    public Event Event { get; set; }

    [ForeignKey("ID_Attendee")]
    public Attendee Attendee { get; set; }
}