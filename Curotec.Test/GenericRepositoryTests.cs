namespace Curotec.Test
{
    using Application.Repositories;
    using Domain.Common;
    using Moq;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class GenericRepositoryTests
    {
        private readonly Mock<IGenericRepository<TestEntity>> _mockRepository;
        private readonly TestEntity _testEntity;
        private readonly List<TestEntity> _testEntityList;

        public GenericRepositoryTests()
        {
            _mockRepository = new Mock<IGenericRepository<TestEntity>>();
            _testEntity = new TestEntity { Id = 1 };
            _testEntityList = [_testEntity];
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnEntity_WhenEntityExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_testEntity);

            // Act
            var result = await _mockRepository.Object.GetByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(_testEntityList);

            // Act
            var result = await _mockRepository.Object.GetAllAsync(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<TestEntity>()))
                .ReturnsAsync(_testEntity);

            // Act
            var result = await _mockRepository.Object.AddAsync(_testEntity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ShouldDeleteEntity_WhenEntityExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.DeleteAsync(It.IsAny<int>()))
                .ReturnsAsync(_testEntity);

            // Act
            var result = await _mockRepository.Object.DeleteAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnEntity_WhenPredicateMatches()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<TestEntity, bool>>>()))
                .ReturnsAsync(_testEntity);

            // Act
            var result = await _mockRepository.Object.GetAsync(e => e.Id == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetList_ShouldReturnEntities_WhenPredicateMatches()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetList(It.IsAny<Expression<Func<TestEntity, bool>>>()))
                .Returns(_testEntityList);

            // Act
            var result = _mockRepository.Object.GetList(e => e.Id == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public async Task GetListAsync_ShouldReturnEntities_WhenPredicateMatches()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetListAsync(It.IsAny<Expression<Func<TestEntity, bool>>>()))
                .ReturnsAsync(_testEntityList);

            // Act
            var result = await _mockRepository.Object.GetListAsync(e => e.Id == 1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }

        [Fact]
        public void Update_ShouldUpdateEntity()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.Update(It.IsAny<TestEntity>()));

            // Act
            _mockRepository.Object.Update(_testEntity);

            // Assert
            _mockRepository.Verify(repo => repo.Update(It.IsAny<TestEntity>()), Times.Once);
        }

        public class TestEntity : BaseEntity
        {

        }
    }
}
