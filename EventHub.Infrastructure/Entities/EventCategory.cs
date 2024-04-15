using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities;
public class EventCategory
{
    [Key]
    [Column("EventCategoryID")]
    public Guid EventCategoryID { get; set; }

    [Column("EventID")]
    public Guid EventID { get; set; }
    public Event Event { get; set; }

    [Column("CategoryID")]
    public Guid CategoryID { get; set; }
    public Category Category { get; set; }
}