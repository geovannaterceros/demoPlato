using ProgramsManager.Models.Models;
using AutoMapper;
using ProgramsManager.DAL.Database.DBModels;

namespace ProgramsManager.DAL.AutoMapper
{
    public class PlateProfile : Profile
    {
        public PlateProfile()
        {
            CreateMap<PlateDto, Plate>();
            CreateMap<Plate, PlateDto>();
        }
    }
}
