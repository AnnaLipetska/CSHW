using System;
using System.Data.Entity;
using System.Linq;

namespace Task5_3
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<PhoneBrand> PhoneBrands { get; set; }
        public virtual DbSet<PhoneModel> PhoneModels { get; set; }
    }
}