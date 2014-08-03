using SearchableZoo.Models.Objects;

namespace SearchableZoo.Models.ViewModels.Keepers
{
    public class EditModel
    {
        public EditModel()
        {
            
        }

        public EditModel(Keeper keeper)
        {
            Id = keeper.Id;
            FirstName = keeper.FirstName;
            LastName = keeper.LastName;
            Sex = keeper.Sex;
            YearsExperience = keeper.YearsExperience;
            Speciality = keeper.Speciality;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexTypes Sex { get; set; }
        public int YearsExperience { get; set; }
        public string Speciality { get; set; }
    }
}