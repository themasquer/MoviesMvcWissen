using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [DisplayName("Movie Name")]
        public string Name { get; set; }

        [StringLength(4)]
        public string ProductionYear { get; set; }

        public double? BoxOfficeReturn { get; set; }
        public virtual List<MovieDirector> MovieDirectors { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public string FilePath { get; set; }
    }
}