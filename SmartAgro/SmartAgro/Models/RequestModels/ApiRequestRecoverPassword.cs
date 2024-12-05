using System.ComponentModel.DataAnnotations;

namespace SmartAgroAPI.DataTransferObjects
{
    public class ApiRequestRecoverPassword
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
