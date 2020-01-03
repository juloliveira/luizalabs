using System;
using System.Collections.Generic;
using System.Text;

namespace Luizalabs.Challenge.Contracts.v1.Requests
{
    public class UserAuth
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
