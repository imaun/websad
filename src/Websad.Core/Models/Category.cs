using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Categories")]
    public class Category
    {
        public Category() {
            Status = EntityStatus.Enabled;
            //Lang = 
            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Lang { get; set; }
        public string PostType { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public EntityStatus Status { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
