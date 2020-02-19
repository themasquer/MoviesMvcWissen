using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Models
{
    public class MovieReportModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        [DisplayName("Movie Name")]
        public string MovieName { get; set; }
        public string MovieProductionYear { get; set; }
        public double? _MovieBoxOfficeReturn { get; set; }
        public string MovieBoxOfficeReturn { get; set; }
        public string DirectorFullName { get; set; }
        public bool _DirectorRetired { get; set; }
        public string DirectorRetired { get; set; }
        public string ReviewContent { get; set; }
        public int? ReviewRating { get; set; }
        public string ReviewReviewer { get; set; }
    }
}