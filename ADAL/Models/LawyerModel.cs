﻿using ADAL.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace ADAL.Models
{
    public class LawyerModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [NonEmptyName(ErrorMessage = "Name cannot be empty or whitespace.")]
        public string FirstName { get; set; }

        [Required]
        [NonEmptyName(ErrorMessage = "Name cannot be empty or whitespace.")]
        public string LastName { get; set; }

        [Required]
        [Phone]
        [StringLength(11, ErrorMessage = "Your mobile number is invalid", MinimumLength = 11)]
        [NumericPhoneNumber(ErrorMessage = "Invalid phone number.")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        [GmailEmail(ErrorMessage = "Email must be a Gmail address.")]
        public string Email { get; set; }
        public string UserId { get; set; }
        public string CNIC { get; set; }
        public int LawyerType { get; set; }
        public int ContectInfoId { get; set; }
        public bool Active { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}
