using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class Category
{
    [Key]
    public Guid ID_Category { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    //public virtual List<EventCategory> EventCategories { get; set; } = new List<EventCategory>();
}