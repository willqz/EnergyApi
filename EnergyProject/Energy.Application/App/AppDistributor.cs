using Energy.Application.Interface;
using Energy.Domain.Entities;
using Energy.Domain.Interface;

namespace Energy.Application.App
{
    public class AppDistributor : IAppDistributor
    {
        IDistributor _IDistributor;

        public AppDistributor(IDistributor IDistributor)
        {
            _IDistributor = IDistributor;
        }

        public void Add(Distributor t)
        {
            _IDistributor.Add(t);
        }

        public void Delete(int id)
        {
            _IDistributor.Delete(id);
        }

        public IEnumerable<Distributor> GetAll()
        {
            return _IDistributor.GetAll();
        }

        public Distributor GetById(int Id)
        {
            return _IDistributor.GetById(Id);
        }

        public void Update(Distributor t)
        {
            _IDistributor.Update(t);
        }
    }
}
