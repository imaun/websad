using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Websad.Core.Models
{
    [Table(name: "Post_Files")]
    public class PostFile
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid FileId { get; set; }
        public Post Post { get; set; }
        public File File { get; set; }
    }
}
