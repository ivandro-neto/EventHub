using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventHub.Infrastructure.Entities;



public class Event
{
    [Key]
    public Guid ID_Event { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    [MaxLength(255)]
    public string Location { get; set; } = string.Empty ;

    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Capacity { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;

    public Guid CreatorID { get; set; }

    [ForeignKey("CreatorID")]
    public Account Creator { get; set; } = new();
    //[InverseProperty("Event")]
    //public ICollection<CheckIn> checkIns{ get; set; }
    //[InverseProperty("Event")]
    //public ICollection<EventCategory> EventCategories { get; set; }

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
