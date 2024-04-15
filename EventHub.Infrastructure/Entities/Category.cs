using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class Category
{
    [Key]
    [Column("CategoryID")]
    public Guid CategoryID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public List<EventCategory> EventCategories { get; set; }
}