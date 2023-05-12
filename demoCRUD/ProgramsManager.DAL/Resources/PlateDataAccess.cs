using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models;

namespace ProgramsManager.DAL.Resources
{
    public class PlateDataAccess : IDataAccess<PlateDto>
    {
        private ProjectContext _projectContext;
        private IMapper _mapper;
        public PlateDataAccess(ProjectContext projectContext, IMapper mapper)
        {
            _projectContext = projectContext;
            _mapper = mapper;
        }
        public async Task<PlateDto> CreateAsync(PlateDto Plate)
        {
            Plate PlateToCreate = _mapper.Map<Plate>(Plate);

            await _projectContext.Plates.AddAsync(PlateToCreate);
            await _projectContext.SaveChangesAsync();

            return Plate;

        }

        public async Task<PlateDto?> DeleteAsync(Guid id)
        {
            Plate? PlateToDelete = await _projectContext.Plates
                .FirstOrDefaultAsync(c => c.Id == id);

            if (PlateToDelete is null)
            {
                return null; 
            }

            _projectContext.Remove(PlateToDelete);
            await _projectContext.SaveChangesAsync();

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateToDelete);

            return PlateDto;

        }

        public async Task<IEnumerable<PlateDto>> GetAsync()
        {
            IEnumerable<Plate> Plates = await _projectContext.Plates.Where(x=> x.DateActivity >= DateTime.Now).ToListAsync();

            IEnumerable<PlateDto> PlatesDto = Plates.Select(Plate => _mapper.Map<PlateDto>(Plate));

            return PlatesDto;
        }

        public async Task<PlateDto> GetAsync(Guid id)
        {
            Plate? PlateFound = await _projectContext.Plates.FirstOrDefaultAsync(c => c.Id == id);

            if (PlateFound is null) 
            {
                return null;
            }

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateFound);

            return PlateDto;
        }

        public async Task<PlateDto?> UpdateAsync(Guid id, PlateDto entity)
        {
            Plate? PlateToUpdate = await _projectContext.Plates.FirstOrDefaultAsync(c=> c.Id == id);

            if (PlateToUpdate is null)
            {
                return null;
            }

            PlateToUpdate.Name = entity.Name;
            PlateToUpdate.DateActivity = entity.DateActivity;
            PlateToUpdate.Offer = entity.Offer;
            
            await _projectContext.SaveChangesAsync();

            PlateDto PlateDto = _mapper.Map<PlateDto>(PlateToUpdate);

            return PlateDto;
        }
    }
}
