#nullable disable
using Microsoft.AspNetCore.Identity;

namespace TodoList.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Todo> Todos { get; set; }
    }
}