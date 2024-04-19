using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class CheckIn
{
    [Key]
    public Guid ID_CheckIn { get; set; } = Guid.NewGuid();

    public Guid ID_Event { get; set; }

    public Guid ID_Account { get; set; }

    public string State { get; set; } = "Pendent";

    public DateTime CheckInDateTime { get; set; }
    public DateTime RegistedDateTime { get; set; } = DateTime.UtcNow;

    [ForeignKey("ID_Event")]
    public Event Event { get; set; } = new();

    [ForeignKey("ID_Account")]
    public Account Account { get; set; } = new();

    public void DoCheckIn()
    {
        CheckInDateTime = DateTime.UtcNow;
        State = "Active";
    }
}