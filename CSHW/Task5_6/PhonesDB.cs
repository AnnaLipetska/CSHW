using System;
using System.Data.Entity;
using System.Linq;

namespace Task5_6
{
    public class PhonesDB : DbContext
    {
        public PhonesDB()
            : base("name=PhonesDB")
        {
        }
        public virtual DbSet<PhoneBrand> PhoneBrands { get; set; }
        public virtual DbSet<PhoneModel> PhoneModels { get; set; }
    }
}