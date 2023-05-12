
using ProgramsManager.BL.Exceptions;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.BL.Validators;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgramsManager.BL.Resources
{
    public class PlatesService : IServices<PlateDto>
    {
        private readonly IDataAccess<PlateDto> _PlateDataAccess;
        
        public PlatesService(IDataAccess<PlateDto> PlateDataAccess)
        {
            _PlateDataAccess = PlateDataAccess;
       
        }
        public async Task<PlateDto> CreateAsync(PlateDto entity)
        {
            PlateValidator _plateValidator = new PlateValidator();
            var validationResult = _plateValidator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new DtoValidationException(validationResult.Errors);
            }

            PlateDto PlateDtoCreated = await _PlateDataAccess.CreateAsync(entity);

            return PlateDtoCreated;
        }

        public async Task<PlateDto> DeleteAsync(Guid id)
        {
            PlateDto PlateDtoDeleted = await _PlateDataAccess.DeleteAsync(id);

            return PlateDtoDeleted;
        }

        public async Task<IEnumerable<PlateDto>> GetAsync()
        {
            IEnumerable<PlateDto> PlateDtos = await _PlateDataAccess.GetAsync();

            return PlateDtos;
        }

        public async Task<PlateDto> GetAsync(Guid id)
        {
            PlateDto PlateDtoFound = await _PlateDataAccess.GetAsync(id);

            return PlateDtoFound;
        }

        public async Task<PlateDto> UpdateAsync(Guid id, PlateDto entity)
        {
            PlateDto PlateDtoUpdated =  await _PlateDataAccess.UpdateAsync(id, entity);

            return PlateDtoUpdated;
        }
    }
}
