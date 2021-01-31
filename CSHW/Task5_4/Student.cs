using System.Collections.Generic;

namespace Task5_4
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Language> Languages { get; set; }

        public Student()
        {
            this.Languages = new HashSet<Language>();
        }
    }
}