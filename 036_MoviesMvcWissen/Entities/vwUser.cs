using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Entities
{
    public class vwUser
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}