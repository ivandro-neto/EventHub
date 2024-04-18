using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Infrastructure.Entities
{
    public class EventCategory
    {
        [Key]
        public Guid ID_EventCategory { get; set; }

        public Guid ID_Event { get; set; }

        public Guid ID_Category { get; set; }

        [ForeignKey("ID_Event")]
        public Event Event { get; set; } = new Event();

        [ForeignKey("ID_Category")]
        public Category Category { get; set; } = new Category();
    }
}
