using Shp.Core.Entities;

namespace Shp.Entities.Dtos
{
    public class UserLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
