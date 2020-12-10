using System;
using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public EntityStatus Status { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public string Url { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }

        public Post Post { get; set; }
        public User User { get; set; }
    }
}
