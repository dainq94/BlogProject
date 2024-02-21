using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.NewFolder.Identity
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        public required string DisplayName { get; set; }
    }
}
