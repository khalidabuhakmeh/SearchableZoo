using System.Collections.Generic;
using System.Linq;

namespace SearchableZoo.Models.Objects
{
    public class Keeper
    {
        public Keeper()
        {
            Sex = SexTypes.Unspecified;
            Animals = Enumerable.Empty<Animal>().ToList();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Speciality { get; set; }
        public int YearsExperience { get; set; }
        public SexTypes Sex { get; set; }
        public virtual IList<Animal> Animals { get; set; }
    }
}