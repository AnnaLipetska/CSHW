using System.Collections.Generic;

namespace Task5_4
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public Language()
        {
            this.Students = new HashSet<Student>();
        }
    }
}