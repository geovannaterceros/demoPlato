using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Database.DBModels;
using ProgramsManager.DAL.Resources;

namespace ProgramsManager.DAL.Tests
{
    [TestClass]
    public class platesDataAccessTests
    {
        private Mock<ProjectContext> _mockContext;
        private Mock<IMapper> _mockMapper;
        private Mock<DbSet<Category>> _mockSet;
        private PlateDataAccess _platesDataAccess;
        private IQueryable<Category> _plates;

        public platesDataAccessTests()
        {
            _mockContext = new Mock<ProjectContext>();
            _mockMapper = new Mock<IMapper>();
            _mockSet = new Mock<DbSet<Category>>();
          
            _plates = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Code = "FR",
                    Name = "FRONTEND",
                }
            }.AsQueryable();

            _platesDataAccess = new PlateDataAccess(_mockContext.Object, _mockMapper.Object);
        }

        [TestInitialize]
        public void Initialize()
        {
            _mockContext.Setup(x => x.plates).Returns(_mockSet.Object);
            _mockSet.As<IQueryable<Category>>().Setup(mock => mock.Provider).Returns(this._plates.Provider);
            _mockSet.As<IQueryable<Category>>().Setup(mock => mock.Expression).Returns(this._plates.Expression);
            _mockSet.As<IQueryable<Category>>().Setup(mock => mock.ElementType).Returns(this._plates.ElementType);
            _mockSet.As<IQueryable<Category>>().Setup(mock => mock.GetEnumerator()).Returns(this._plates.GetEnumerator());

        }

        [TestMethod]
        public async Task TestGetAsync_ReturnSuccess_WhenIEnumerableOfCategory()
        {
            var plates = _platesDataAccess.GetAsync();
            Assert.IsNotNull(plates);
        }

        [TestMethod]
        public async Task TestGetAsync_ReturnSuccess_WhenGetCategoryToId()
        {
            Guid id = Guid.NewGuid();
            var plates = _platesDataAccess.GetAsync(id);
            Assert.IsNotNull(plates);
        }
    }
}