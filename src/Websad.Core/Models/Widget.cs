using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Widgets")]
    public class Widget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UniqueName { get; set; }
        public string Body { get; set; }
        public string Category { get; set; }
        public string Lang { get; set; }
        public int OrderNumber { get; set; }
        public EntityStatus Status { get; set; }
    }
}
