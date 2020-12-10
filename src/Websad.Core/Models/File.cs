using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Files")]
    public class File
    {
        public File() {
            Posts = new HashSet<PostFile>();
        }

        public Guid Id { get; set; }
        public int UserId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        [Column(name:"FileTypeIndex")]
        public PostFileType FileType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public EntityStatus Status { get; set; }
        public User User { get; set; }
        public ICollection<PostFile> Posts { get; set; }
    }
}
