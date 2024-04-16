using EventHub.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Communication.Responses;
public class EventResponseJson
{
    [Key]
    [Column("EventID")]
    public Guid EventID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Capacity { get; set; }
    public int AttendeesAmount { get; set; }
    public string Status { get; set; } = string.Empty;
    public List<EventCategory> EventCategories { get; set; } // Removi a inicialização aqui
    public Guid CreatorID { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }

    public EventResponseJson()
    {
        // Inicializa a lista no construtor
        EventCategories = new List<EventCategory>();
    }
}
