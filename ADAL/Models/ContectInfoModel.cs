namespace ADAL.Models
{
    public class ContectInfoModel
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; } = 0;
        public DateTime CreatedOnUTC { get; set; }
        public DateTime UpdatedOnUTC { get; set; }

    }
}
