using FluentAssertions;
using NUnit.Framework;
using TechnicalInterview.GenericLibrary.Contracts;
using TechnicalInterview.GenericLibrary.Models;
using TechnicalInterview.GenericLibrary.Services;

namespace TechnicalInterview.GenericLibrary.UTests
{
    [TestFixture]
    public class DocumentTypeTests
    {
        private IDocumentValidator _documentValidator;
        [OneTimeSetUp]
        public void Setup()
        {
            _documentValidator = new DocumentValidator();
        }
        #region IsCPF
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("518.551.280-63")]
        [TestCase("650.724.100-80")]
        [TestCase("633.797.348-88")]
        [TestCase("932.840.739-73")]
        [TestCase("932840.739-73")]
        [TestCase("932840.739-73")]
        [TestCase("932.840739/73")]
        [TestCase(@"932.840.739\73")]
        [TestCase(@"93284073973")]
        public void IsCPF_Should_Be_True(string input)
        {
            //Arrange

            //Act
            var isCPF = _documentValidator.IsCPF(input);
            //Assert
            isCPF.Should().Be(true);
        }
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("518.551.280-61")]
        [TestCase("650.724.100-81")]
        [TestCase("633.797.348-81")]
        [TestCase("932.840.739-71")]
        public void IsCPF_Should_Be_False(string input)
        {
            //Arrange

            //Act
            var isCPF = _documentValidator.IsCPF(input);
            //Assert
            isCPF.Should().Be(false);
        }
        #endregion

        #region IsCNPJ
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("27612158000179")]
        [TestCase("48.221.643/0001-91")]
        [TestCase("48.221.643/000191")]
        [TestCase("48221.643/000191")]
        [TestCase("96.437.604/0001-79")]
        public void IsCNPJ_Should_Be_True(string input)
        {
            //Arrange
            //Act
            var isCNPJ = _documentValidator.IsCNPJ(input);
            //Assert
            isCNPJ.Should().Be(true);
        }

        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("2761215800017")]
        [TestCase("48.221.643/0001-92")]
        [TestCase("48.221.643/000192")]
        [TestCase("48221.643/000192")]
        [TestCase("96.437.604/0001-72")]
        public void IsCNPJ_Should_Be_False(string input)
        {
            //Arrange
            //Act
            var isCNPJ = _documentValidator.IsCNPJ(input);
            //Assert
            isCNPJ.Should().Be(false);
        }

        #endregion

        #region AutoSelector
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("518.551.280-63")]
        [TestCase("650.724.100-80")]

        public void AutoSelector_Should_Be_CPF(string input)
        {
            //Arrange

            //Act
            var isCPF = _documentValidator.AutoSelector(input);
            //Assert
            isCPF.Should().Be(DocumentType.CPF);
        }
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("48.221.643/0001-91")]
        [TestCase("48.221.643/000191")]
        [TestCase("48221.643/000191")]
        [TestCase("96.437.604/0001-79")]

        public void AutoSelector_Should_Be_CNPJ(string input)
        {
            //Arrange

            //Act
            var isCPF = _documentValidator.AutoSelector(input);
            //Assert
            isCPF.Should().Be(DocumentType.CNPJ);
        }
        [Test]
        [Parallelizable(ParallelScope.All)]
        [TestCase("48221.643/000192")]
        [TestCase("96.437.604/0001-72")]

        public void AutoSelector_Should_Be_NoSupport(string input)
        {
            //Arrange

            //Act
            var isCPF = _documentValidator.AutoSelector(input);
            //Assert
            isCPF.Should().Be(DocumentType.NoSupport);
        }
        #endregion
    }
}
