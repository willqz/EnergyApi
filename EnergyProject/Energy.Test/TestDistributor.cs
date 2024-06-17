using Energy.Domain.DomainObject;
using Energy.Domain.Entities;

namespace Energy.Test
{
    public class TestDistributor
    {
        [Fact]
        public void CreteDistributorOK()
        {
            new Distributor(0, "Companhia de Luz", "CDL", true, DateTime.Now);
            Assert.True(true);
        }      

        [Fact]
        public void CreateDistributorErrorDescription()
        {
            Assert.Throws<DomainException>(() =>
                 new Distributor(0, "", "CDL", true, DateTime.Now)
            );
        }

        [Fact]
        public void CreateDistributorErrorSigla()
        {
            Assert.Throws<DomainException>(() =>
                 new Distributor(0, "Companhia de Luz", "", true, DateTime.Now)
            );
        }

        [Fact]
        public void CreateDistributorErrorStatus()
        {
            Assert.Throws<DomainException>(() =>
                 new Distributor(0, "Companhia de Luz", "CDL", false, DateTime.Now)
            );
        }

        [Fact]
        public void EditDistributorOK()
        {
            new Distributor(10, "Companhia de Luz", "CDL", true, DateTime.Now);
            Assert.True(true);
        }

    }
}