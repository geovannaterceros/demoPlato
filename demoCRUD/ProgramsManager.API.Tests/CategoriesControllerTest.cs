using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramsManager.API.Controllers;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.Models.Models;

namespace ProgramsManager.API.Tests
{
    [TestClass]
    public class platesControllerTest
    {
        private readonly PlatesController _platesController;
        private readonly Mock<IServices<CategoryDto>> servicesMock;

        public platesControllerTest()
        {
            servicesMock = new Mock<IServices<CategoryDto>>();
            _platesController = new platesController(servicesMock.Object);
        }

        [TestMethod]
        public async Task TestGetAsync_ReturnOk_WhenListCategoryExist()
        {
            IEnumerable<CategoryDto> plates = new List<CategoryDto>() 
            {
                new CategoryDto(){ 
                    Id = Guid.NewGuid(),
                    Code = "FR",
                    Name = "FRONTEND",
                }
            };

            servicesMock.Setup(mock => mock.GetAsync())
                .ReturnsAsync(plates);
            IActionResult response = await _platesController.GetAsync();
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task TestGetAsync_ReturnNotFound_WhenListCategoryEmpty()
        {
            IEnumerable<CategoryDto> plates = new List<CategoryDto>();
            
            servicesMock.Setup(mock => mock.GetAsync())
                .ReturnsAsync(plates);
           
            IActionResult response = await _platesController.GetAsync();
            
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task TestGetAsyncId_ReturnOk_WhenFoundCategory()
        {
            CategoryDto category = new CategoryDto()
            {
                Id = new Guid("b8895904-1852-4476-aa76-3a9556e6bfb4"),
                Code = "FR",
                Name = "FRONTEND",
            };

            servicesMock.Setup(mock => mock.GetAsync(category.Id))
                .ReturnsAsync(category);

            IActionResult response = await _platesController.GetAsync(category.Id);

            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task TestGetAsyncId_ReturnOk_WhenNotFoundCategory()
        {
            Guid Id= Guid.NewGuid();
            CategoryDto category = new CategoryDto();

            servicesMock.Setup(mock => mock.GetAsync(Id))
                .ReturnsAsync(category);

            IActionResult response = await _platesController.GetAsync(Id);

            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task TestCreateAsync_ReturnOk_WhenCreatedCategory()
        {
            CategoryDto categoryDto = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };
          
            servicesMock.Setup(mock => mock.CreateAsync(categoryDto))
                .ReturnsAsync(categoryDto);

            IActionResult response = await _platesController.CreateAsync(categoryDto);

            Assert.IsInstanceOfType(response, typeof(CreatedResult));
        }

        [TestMethod]
        public async Task TestUpdateAsync_ReturnOk_WhenUpdateCategory()
        {
            CategoryDto categoryDto = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            servicesMock.Setup(mock => mock.UpdateAsync(categoryDto.Id, categoryDto))
                .ReturnsAsync(categoryDto);

            IActionResult response = await _platesController.UpdateAsync(categoryDto.Id, categoryDto);

            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task TestDeletAsync_ReturnOk_WhenDeletCategory()
        {
            CategoryDto categoryDto = new CategoryDto()
            {
                Id = Guid.NewGuid(),
                Code = "FR",
                Name = "FRONTEND",
            };

            servicesMock.Setup(mock => mock.DeleteAsync(categoryDto.Id))
                .ReturnsAsync(categoryDto);

            IActionResult response = await _platesController.DeleteAsync(categoryDto.Id);

            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}