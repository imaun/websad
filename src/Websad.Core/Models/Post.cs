using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Posts")]
    public class Post
    {
        public Post() {
            Likes = new HashSet<PostLike>();
            Files = new HashSet<PostFile>();
            Meta = new HashSet<PostMeta>();
            Comments = new HashSet<Comment>();
            PostBlocks = new HashSet<PostBlock>();
        }

        #region Properties
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }

        [Column(TypeName = "TEXT")]
        public string Body { get; set; }

        public string Summary { get; set; }
        public PostStatus Status { get; set; }
        public PostBodyType BodyType { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool Commenting { get; set; }
        public string PostType { get; set; }
        public string Password { get; set; }
        public string Lang { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        public string AltTitle { get; set; }
        public int OrderNumber { get; set; }
        public string Tags { get; set; } //Sepetared by semicolon ;
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int UserId { get; set; }

        #endregion

        #region SEO Related

        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }

        #endregion

        #region Navigations

        public ICollection<PostLike> Likes { get; set; }
        public ICollection<PostFile> Files { get; set; }
        public ICollection<PostMeta> Meta { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostBlock> PostBlocks { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

        #endregion
    }
}
