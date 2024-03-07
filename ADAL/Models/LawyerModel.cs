using System.ComponentModel.DataAnnotations;

namespace ADAL.Models
{
    public class LawyerModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Phone]
        public string Mobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
