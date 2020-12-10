using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Websad.Core.Models
{
    [Table(name: "Post_Likes")]
    public class PostLike
    {
        public long Id { get; set; }
        public int PostId { get; set; }
        public string SessionId { get; set; }
        public int? UserId { get; set; }
        public string IP { get; set; }
        public DateTime CreateDate { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
