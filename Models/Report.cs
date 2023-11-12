using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LibraryWebApp.Models
{
    public class Report
    {
        public ReportTypes ReportType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public enum ReportTypes
    {
        [Display(Name = "Books Purchased Report")]
        BooksPurchased,
        [Display(Name = "Fees Accumulated Report")]
        FeesAccumulated,
        [Display(Name = "Movies Purchased Report")]
        MoviesPurchased,
    }
}