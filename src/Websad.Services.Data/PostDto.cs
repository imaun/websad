using System;
using System.Collections.Generic;
using System.Text;
using Websad.Core.Enum;
using Websad.Core.Extensions;

namespace Websad.Services.Data {

    public class PostDetailDto {
        public int Id { get; set; }
        public string Author => Post?.UserTitle;
        public int LikesCount => Post?.LikesCount ?? 0;
        public int CommentsCount => Post?.CommentsCount ?? 0;
        public string Summary => Post?.Summary;
        public DateTime? PublishDate => Post.PublishDate;
        public PostResultDto Post { get; set; }
        public IEnumerable<PostViewItemDto> RelatedPosts { get; set; }
        public IEnumerable<PostTypeCategoryItemDto> Categories { get; set; }
    }



    public class PostResultDto
    {
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
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string CategoryTitle { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }
    }

    public class PostCreateDto
    {
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
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }

        /// <summary>
        /// If set to NULL CreateDate will fill automatically by the server
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }

    public class PostUpdateDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public PostBodyType BodyType { get; set; }
        public string Summary { get; set; }
        public PostStatus Status { get; set; }
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
        public string MetaDescription { get; set; }
        public string MetaRobots { get; set; }
        /// <summary>
        /// If set to NULL CreateDate will fill automatically by the server
        /// </summary>
        public DateTime? CreateDate { get; set; }
    }

    public class PostViewItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AltTitle { get; set; }
        public string Slug { get; set; }
        public string Author { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string Tags { get; set; }
        public string CoverPhoto { get; set; }
    }

    public class PostViewListDto: ViewListDto<PostViewItemDto> {
        public PostViewListDto() : base() { }
        public PostViewListDto(ICollection<PostViewItemDto> items): base(items) { }
    }

    public class PostViewListFilter {
        public string PostType { get; set; }
        public string Lang { get; set; }
        public string Title { get; set; }
    }
}
