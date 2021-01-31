using System;
using System.Collections.Generic;
using DNTPersianUtils.Core;
using Websad.Core.Enum;

namespace Websad.Web.ViewModels {

    public class PostViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public PostStatus Status { get; set; }
        public PostBodyType BodyType { get; set; }
        public DateTime? PublishDate { get; set; }

        public string PublishDateDisplay => PublishDate.HasValue
            ? PublishDate.ToPersianDateTextify()
            : string.Empty;

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
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public DateTime ModifyDate { get; set; }
        public string ModifyDateDisplay => ModifyDate.ToPersianDateTextify();
        public int UserId { get; set; }
        public string UserTitle { get; set; }
        public string CategoryTitle { get; set; }
    }

    public class PostViewListViewModel : ListViewBaseViewModel<PostViewItemViewModel> {
        public PostViewListViewModel() : base() { }
        public string PostType { get; set; }
        public string Lang { get; set; }

    }

    public class PostViewItemViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Author { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishDateDisplay => PublishDate
            .ToFriendlyPersianDateTextify();
        public string PublishDateMonth => PublishDate
            .GetPersianMonth()
            .GetPersianMonthName();
        public string PublishDateDay => PublishDate
            .GetPersianDayOfMonth().ToString();
        public string Tags { get; set; }
        public IEnumerable<string> TagList => Tags.Split(';');
    }

    public class OtherPostViewModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AltTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishDateDisplay => PublishDate.ToPersianDateTextify();
    }

    public class PostDetailViewModel {
        public string Author => Post?.UserTitle;
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public string Summary => Post?.Summary;
        public DateTime? PublishDate => Post.PublishDate;
        public string PublishDateDisplay => PublishDate.ToPersianDateTextify();
        public string PublishDateMonth => PublishDate?
            .GetPersianMonth()
            .GetPersianMonthName();
        public string PublishDateDay => PublishDate?
            .GetPersianDayOfMonth().ToString();
        public PostViewModel Post { get; set; }
        public IEnumerable<OtherPostViewModel> RelatedPosts { get; set; }
        public IEnumerable<PostTypeCategoryItemViewModel> Categories { get; set; }
        public IEnumerable<string> Tags => Post?.Tags.Split(';');
    }
}
