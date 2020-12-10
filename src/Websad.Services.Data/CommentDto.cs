using System;

namespace Websad.Services.Data
{
    public class CommentResultDto
    {
        public int Id { get; set; }
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
        public string PostTitle { get; set; }
        public string UserTitle { get; set; }
    }

    public class CommentCreateDto
    {
        public string Author { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public int? ParentId { get; set; }
    }
}
