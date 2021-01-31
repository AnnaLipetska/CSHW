using System;
using System.Data.Entity;
using System.Linq;

namespace Task5_4
{
    public class LanguageSchool : DbContext
    {
        public LanguageSchool()
            : base("name=LS")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
    }
}