using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server23.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Trader Trader { get; set; }

        public ApplicationUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
            Trader = new Trader(userName);
        }
    }
}
