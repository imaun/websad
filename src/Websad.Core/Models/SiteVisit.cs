using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Websad.Core.Models
{
    [Table(name: "SiteVisits")]
    public class SiteVisit
    {
        public long Id { get; set; }
        public string SessionId { get; set; }
        public DateTime CreateDate { get; set; }
        public string AbsoluteUrl { get; set; }
        public string UrlReferrer { get; set; }
        public int? UserId { get; set; }
        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string OsPlatform { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
    }
}
