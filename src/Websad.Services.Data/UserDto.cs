using System;
using System.Collections.Generic;
using System.Text;

namespace Websad.Services.Data
{
    public class UserApiLoginData {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string ApiKey { get; set; }
        public bool Failed { get; set; }
    }
}
