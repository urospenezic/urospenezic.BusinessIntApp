using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using System.Collections.Generic;
using ViewModel;

namespace Tests
{
    [TestClass]
    public class KupacViewModelTests
    {
        private IRepository<Kupac> GetTestRepository()
        {
            var testKupci= TestKupci.testKupci;
            var mockRepo = new Mock<IRepository<Kupac>>();
            mockRepo.Setup(k => k.GetAll()).Returns(testKupci);
            return mockRepo.Object;
        }
        
        [TestMethod]
        public void GenerateArrayTest()
        {
            //arrange
            var repository = GetTestRepository();
            var model = new Viewmodel(repository);
            var expected = 2;
            //act
            var array = model.GenerateZScoreMatrix(repository);
            var actual = array.Length;
            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
