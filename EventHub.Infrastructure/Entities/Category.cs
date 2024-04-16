using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class Category
{
    [Key]
    public Guid ID_Category { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<EventCategory> EventCategories { get; set; }
}