using ADAL.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity;

namespace ADAL.Models
{
    public class ClientModel : IdentityUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CNIC { get; set; }
        public int ContectInfoId { get; set; }
        public bool Active { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }
    }
}
