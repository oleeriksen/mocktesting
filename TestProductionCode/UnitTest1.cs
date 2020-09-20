using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductionCode;
using ProductionCode.BE;
using ProductionCode.Kernel;

namespace TestProductionCode
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNormalInsert()
        {
            Mock<IDataAccess> m = new Mock<IDataAccess>(); 
            
            PersonService mService = new PersonService(m.Object);

            BEPerson p = new BEPerson { Id = 2, Name = "peter", Age=23};
            mService.Insert(p);

            m.Verify(m => m.Insert(p), Times.Once);
        }

        [TestMethod]
        public void TestNameNotEmpty()
        {
            Mock<IDataAccess> m = new Mock<IDataAccess>();

            PersonService mService = new PersonService(m.Object);

            BEPerson p = new BEPerson { Id = 2, Name = "", Age = 23 };
            mService.Insert(p);

            m.Verify(m => m.Insert(p), Times.Never);
        }

        [TestMethod]
        public void TestByAge() {
            Mock<IDataAccess> m = new Mock<IDataAccess>();

            BEPerson[] returnValue = { new BEPerson { Id = 2, Name = "a", Age = 23 },
                                       new BEPerson { Id = 2, Name = "b", Age = 13 } };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            PersonService mService = new PersonService(m.Object);

            List<BEPerson> actualResult = mService.GetByAge(10, 15);

            m.Verify(m => m.GetAll(), Times.Once);

            Assert.IsTrue(actualResult.Count == 1);
            Assert.IsTrue(actualResult.Contains(returnValue[1]));

        }

    }
}