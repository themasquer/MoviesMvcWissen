using _036_MoviesMvcWissen.Validations.FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Entities
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required]
        [StringLength(25)]
        public string Password { get; set; }
        public bool Active { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}