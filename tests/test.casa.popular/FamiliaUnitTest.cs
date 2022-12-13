namespace test.casa.popular
{
    using AutoMapper;
    using core.casa.popular.Implementation;
    using Moq;
    using Newtonsoft.Json.Linq;
    using repository.casa.popular.Repositories;
    public class FamiliaUnitTest : BaseTest
    {
        private readonly FamiliaCore _familiaCore;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<IFamiliaRepository> _familiaRepository;

        public FamiliaUnitTest()
        {
            _mapper = new Mock<IMapper>();
            _familiaRepository = new Mock<IFamiliaRepository>();
            _familiaCore = new FamiliaCore(_mapper.Object, _familiaRepository.Object);
        }

        [Fact]
        public async Task ObterListaFamiliaCore()
        {
            var familias = JObject.Parse(await _familiaCore.Get(1, 10));

            Assert.Null(familias["Familia"]);
        }

        [Fact]
        public void ObterExceptionFamiliaCorePorIdVazio()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _familiaCore.Get(Guid.Empty));
        }

        [Fact]
        public void ObterExceptionFamiliaCorePorIdRandomico()
        {
            Assert.ThrowsAsync<NullReferenceException>(() => _familiaCore.Get(Guid.NewGuid()));
        }
    }
}