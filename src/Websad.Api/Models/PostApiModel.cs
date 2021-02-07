using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Websad.Core.Enum;

namespace Websad.Api.Models
{
    public class PostCreateApiModel
    {
        [Required, MaxLength(1000)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(2000)]
        public string Slug { get; set; }
        [MaxLength(4000)]
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        [MaxLength(2000)]
        public string Summary { get; set; }
        public PostStatus Status { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool Commenting { get; set; }
        [Required, MaxLength(100)]
        public string PostType { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Lang { get; set; }
        public int? ParentId { get; set; }
        [MaxLength(2000)]
        public string AltTitle { get; set; }
        public int OrderNumber { get; set; }
        [MaxLength(2000)]
        public string Tags { get; set; } //Sepetared by semicolon ;
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }

        public IFormFile CoverPhotoFile { get; set; }
        public string CoverPhotoUrl { get; set; }

        /// <summary>
        /// If set to NULL CreateDate will fill automatically by the server
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }

    public class PostUpdateApiModel {
        public int Id { get; set; }
        [Required, MaxLength(1000)]
        public string Title { get; set; }
        public int CategoryId { get; set; }
        [Required, MaxLength(2000)]
        public string Slug { get; set; }
        [MaxLength(4000)]
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        [MaxLength(2000)]
        public string Summary { get; set; }
        public PostStatus Status { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool Commenting { get; set; }
        [MaxLength(100)]
        public string PostType { get; set; }
        [MaxLength(25)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string Lang { get; set; }
        public string CoverPhoto { get; set; }
        public int? ParentId { get; set; }
        [MaxLength(2000)]
        public string AltTitle { get; set; }
        public int OrderNumber { get; set; }
        [MaxLength(2000)]
        public string Tags { get; set; } //Sepetared by semicolon ;
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }

        public IFormFile CoverPhotoFile { get; set; }
        public string CoverPhotoUrl { get; set; }
        /// <summary>
        /// If set to NULL CreateDate will fill automatically by the server
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }

    public class PostApiModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Slug { get; set; }
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
        public string UserTitle { get; set; }
        public string CategoryTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
    }
}
