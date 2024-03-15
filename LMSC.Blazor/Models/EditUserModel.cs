using LMSC.Models;
using System.ComponentModel.DataAnnotations;

namespace LMSC.Blazor.Models
{
    public class EditUserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name must be provided.")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match.")]
        public string ConfirmEmail { get; set; }
        public int RoleID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhotoPath { get; set; }
    }
}
