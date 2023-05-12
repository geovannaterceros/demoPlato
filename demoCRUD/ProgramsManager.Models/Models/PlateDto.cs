using ProgramsManager.Models.Interfaces;

namespace ProgramsManager.Models.Models
{
    public class PlateDto : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public DateTime DateActivity { get; set; }    

        public bool Offer { get; set; }
    }

}
