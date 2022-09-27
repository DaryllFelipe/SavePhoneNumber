using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavePhoneDetailsAPI.Models
{
    public partial class ContactDetail
    {
        public int Id { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage = "Full name is needed")]
        public string? FullName { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is needed")]
        [StringLength(11, ErrorMessage = "Phone number must be 11 character only")]
        public string? PhoneNumber { get; set; }
    }
}
