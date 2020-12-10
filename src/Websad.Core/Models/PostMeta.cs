using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Post_Meta")]
    public class PostMeta
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string MetaKey { get; set; }
        public string MetaValue { get; set; }
        public string Title { get; set; }
        public string Lang { get; set; }
        public EntityStatus Status { get; set; }
        public Post Post { get; set; }
    }
}
