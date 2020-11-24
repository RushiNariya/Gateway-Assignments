using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SourceControlAssignment1.Models;

namespace SourceControlAssignment1.ViewModels
{
    public class CustomerMembershipViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}