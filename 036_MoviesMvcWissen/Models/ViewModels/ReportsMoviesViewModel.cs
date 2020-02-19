using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _036_MoviesMvcWissen.Models.ViewModels
{
    public class ReportsMoviesViewModel
    {
        public List<MovieReportModel> MovieReports { get; set; }
        public int RecordCount { get; set; }
        public int RecordsPerPageCount { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}