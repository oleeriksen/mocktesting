using System;
using System.Collections.Generic;
using ProductionCode.BE;

namespace ProductionCode.Kernel
{
    public interface IDataAccess
    {

        IEnumerable<BEPerson> GetAll();

        BEPerson GetById(int id);

        void Insert(BEPerson p);

        void Update(BEPerson p);

        void Delete(BEPerson p);

    }
}
