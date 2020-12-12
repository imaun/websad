using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Websad.Core.Enum;

namespace Websad.Core.Models
{
    [Table(name: "Users")]
    public class User
    {
        public User() {
            Posts = new HashSet<Post>();
            Likes = new HashSet<PostLike>();
            Files = new HashSet<File>();
            Comments = new HashSet<Comment>();
            AddedBlocks = new HashSet<Block>();
            AddedPostBlocks = new HashSet<PostBlock>();
        }

        #region Properties

        public int Id { get; set; }
        public UserStatus Status { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public string WebUrl { get; set; }
        public string Phone { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Description { get; set; }
        public string ApiKey { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }

        #endregion

        #region Navigations

        public ICollection<Post> Posts { get; set; }
        public ICollection<PostLike> Likes { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Block> AddedBlocks { get; set; }
        public ICollection<PostBlock> AddedPostBlocks { get; set; }
        #endregion
    }
}

