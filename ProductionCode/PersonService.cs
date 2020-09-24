using System;
using System.Collections.Generic;
using ProductionCode.BE;
using ProductionCode.Kernel;

namespace ProductionCode
{
    public class PersonService
    {
        IDataAccess mDataAccess;
        public PersonService(IDataAccess da)
        {
            mDataAccess = da;
        }

        public void Delete(BEPerson p)
        {
            mDataAccess.Delete(p);  
        }

        public IEnumerable<BEPerson> GetAll()
        {
            return mDataAccess.GetAll();
        }

        public BEPerson GetById(int id)
        {
            foreach (BEPerson p in mDataAccess.GetAll())
                if (p.Id == id)
                  return p;
            return null;
        }

        public void Insert(BEPerson p)
        {
            if (! String.IsNullOrEmpty(p.Name))
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

        public List<BEPerson> GetByName(string s) {

            List<BEPerson> result = new List<BEPerson>();
            foreach (BEPerson p in mDataAccess.GetAll())
                if ( p.Name.Contains(s) )
                    result.Add(p);
            return result;

        }
    }
}
