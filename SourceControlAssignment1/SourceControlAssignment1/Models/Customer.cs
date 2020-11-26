using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlAssignment1.Models
{
    [Bind(Exclude = "Id")]
    public class Customer
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please enter customer's Name.")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please check the Box.")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Customer Email")]
        [Required(ErrorMessage ="Please enter customer's Email.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Display(Name = "Comfirm Email")]
        [Required(ErrorMessage = "Please enter customer's Email.")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Email Not Matched")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Customer Phone Number")]
        [Required(ErrorMessage = "Please enter customer's Phone Nmuber.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage = "Please Enter valid Phone Number.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Customer Photo")]
        public string PhotoPath { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Photo.")]
        [FileExtension]
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please Enter Customer's Age.")]
        [Range(5,100)]
        public byte Age { get; set; }

        [Display(Name = "Customer BirthDate")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        [Url]
        [Display(Name = "Customer's LinkedIn URL")]
        public string URL { get; set; }
    }
}