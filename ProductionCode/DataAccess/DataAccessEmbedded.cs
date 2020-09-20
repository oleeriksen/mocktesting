using System;
using System.Collections.Generic;
using ProductionCode.BE;
using ProductionCode.Kernel;

namespace ProductionCode.DataAccess
{
    public class DataAccessEmbedded : IDataAccess
    {
        List<BEPerson> mPersons;

        public DataAccessEmbedded()
        {
            mPersons = new List<BEPerson>();
        }

        public void Delete(BEPerson p)
        {
            mPersons.Remove(p);
        }

        public IEnumerable<BEPerson> GetAll()
        {
            return new List<BEPerson>(mPersons);
        }

        public BEPerson GetById(int id)
        {
            foreach (BEPerson ap in mPersons)
                if (ap.Id == id)
                    return ap;
            return null;
        }

        public void Insert(BEPerson p)
        {
            mPersons.Add(p);
        }

        public void Update(BEPerson p)
        {
            Delete(p);
            Insert(p);
        }
    }
}
