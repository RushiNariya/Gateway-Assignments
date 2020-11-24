using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControlAssignment1.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string MembershipName { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}