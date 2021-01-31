namespace Task5_5
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int? PhoneBrandId { get; set; }
        public PhoneBrand PhoneBrand { get; set; }
    }
}