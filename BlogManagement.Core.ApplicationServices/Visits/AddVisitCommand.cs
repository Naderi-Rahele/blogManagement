using System;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Core.ApplicationServices.Visits
{
    public class AddVisitCommand
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public DateTime CreatedOn{get;set;}

    }
}