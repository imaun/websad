using System;
using DNTPersianUtils.Core;
using Websad.Core.Enum;

namespace Websad.Web.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public EntityStatus Status { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateDisplay => CreateDate.ToPersianDateTextify();
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string SessionId { get; set; }
        public string Url { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }
        public string PostTitle { get; set; }
        public string UserTitle { get; set; }
    }
}
