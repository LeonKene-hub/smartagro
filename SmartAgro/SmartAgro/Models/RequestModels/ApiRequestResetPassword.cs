using System.ComponentModel.DataAnnotations;

namespace SmartAgroAPI.DataTransferObjects
{
    public class ApiRequestResetPassword
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string TemporaryToken { get; set; }

        [Required]
        public required string NewPassword { get; set; }

    }
}
