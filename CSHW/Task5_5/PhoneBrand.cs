using System.Collections.Generic;

namespace Task5_5
{
    public class PhoneBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PhoneModel> PhoneModels { get; set; }

        public PhoneBrand()
        {
            PhoneModels = new List<PhoneModel>();
        }
    }
}