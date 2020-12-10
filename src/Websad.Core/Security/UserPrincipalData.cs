using System;
using System.Collections.Generic;
using System.Text;

namespace Websad.Core.Security
{
    public class UserPrincipalData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ApiKey { get; set; }
        public bool Enabled { get; set; }
    }
}
