using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventHub.Infrastructure.Entities;

public class Event
{
    [Key]
    [Column("EventID")]
    public Guid EventID { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDateTime { get; set; }

    [Required]
    [MaxLength(255)]
    public string Location { get; set; }

    [Required]
    [MaxLength(50)]
    public string Type { get; set; }

    public decimal Price { get; set; }

    public int Capacity { get; set; }

    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = "Inactive";

    [Column("CreatorID")]
    public Guid CreatorID { get; set; }
  

    public List<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
    public List<Attendee> Attendees { get; set; } = new List<Attendee>();


public void Update(string name, string description, DateTime startDate, DateTime endDate, string location, string type, decimal price, int capacity, string status)
    {
        Name = name;
        Description = description;
        StartDateTime = startDate;
        EndDateTime = endDate;
        Location = location;
        Type = type;
        Price = price;
        Capacity = capacity;
        Status = status;
    }
}
