using System;
using System.Collections.Generic;
using ProductionCode.BE;
using ProductionCode.Kernel;

namespace ProductionCode
{
    public class PersonService : IDataAccess
    {
        IDataAccess mDataAccess;
        public PersonService(IDataAccess da)
        {
            mDataAccess = da;
        }

        public void Delete(BEPerson p)
        {
           
        }

        public IEnumerable<BEPerson> GetAll()
        {
            throw new NotImplementedException();
        }

        public BEPerson GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BEPerson p)
        {
            if (p != null && ! String.IsNullOrEmpty(p.Name))
                mDataAccess.Insert(p);
    
        }

        public void Update(BEPerson p)
        {
            throw new NotImplementedException();
        }

        public List<BEPerson> GetByAge(int minAge, int maxAge)
        {
            List<BEPerson> result = new List<BEPerson>();
            foreach (BEPerson p in mDataAccess.GetAll())
                if (minAge <= p.Age && p.Age <= maxAge)
                    result.Add(p);
            return result;
        }
    }
}
