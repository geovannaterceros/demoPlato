using Moq;
using ProgramsManager.BL.Resources;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.Models.Models;

namespace ProgramsManager.BL.Tests
{
    [TestClass]
    public class platesServiceTest
    {
        private readonly PlatesService _platesService;
        private readonly Mock<IDataAccess<CategoryDto>> _dataAccessMock;
        
        public platesServiceTest()
        {
            _dataAccessMock = new Mock<IDataAccess<CategoryDto>>();
            _platesService = new platesService(_dataAccessMock.Object);
        }

        [TestMethod]
        public async Task TestCreateAsync_ReturnSuccess_WhenCreatedACategory()
        {
            CategoryDto categoryToCreate = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            _dataAccessMock.Setup(mock => mock.CreateAsync(categoryToCreate))
                .ReturnsAsync(categoryToCreate); 

            CategoryDto categoryCreated = await _platesService.CreateAsync(categoryToCreate);

            Assert.IsNotNull(categoryCreated);
        }

        [TestMethod]
        public async Task TestDeleteAsync_ReturnSuccess_WhenDeleteCategory()
        {
            CategoryDto categoryToDelete = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            _dataAccessMock.Setup(mock => mock.DeleteAsync(categoryToDelete.Id))
                .ReturnsAsync(categoryToDelete);

            CategoryDto categoryDeleted = await _platesService.DeleteAsync(categoryToDelete.Id);

            Assert.IsNotNull(categoryDeleted);
        }


        [TestMethod]
        public async Task TestUpdateAsync_ReturnSuccess_WhenUpdateCategory()
        {
            CategoryDto category = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            _dataAccessMock.Setup(mock => mock.UpdateAsync(category.Id, category))
                .ReturnsAsync(category);

            CategoryDto categoryUpdated = await _platesService.UpdateAsync(category.Id, category);

            Assert.IsNotNull(categoryUpdated);
        }

        [TestMethod]
        public async Task TestGetAsync_ReturnSuccess_WhenGetListCategory()
        {
            IEnumerable<CategoryDto> plates = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = Guid.NewGuid(),
                    Code = "FR",
                    Name = "FRONTEND",
                }
            };

            _dataAccessMock.Setup(mock => mock.GetAsync())
                .ReturnsAsync(plates);

            IEnumerable<CategoryDto> result = await _platesService.GetAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task TestGetAsyncId_ReturnSuccess_WhenGetIdToCategory()
        {
            CategoryDto category = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            _dataAccessMock.Setup(mock => mock.GetAsync(category.Id))
                .ReturnsAsync(category);

            CategoryDto result = await _platesService.GetAsync(category.Id);

            Assert.IsNotNull(result);
        }
    }
}