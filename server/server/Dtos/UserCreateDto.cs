using System.ComponentModel.DataAnnotations;

namespace server.Dtos
{
    public record class UserCreateDto(
        [Required] string Name,
        [Required] string Email,
        [Required] string Password
    );
}
