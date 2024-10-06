using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.BLL.Dto
{
    public class VerifyEmailDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
