using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusDep.DataAccess.Sessions;
using BusDep.Entity;
using NUnit.Framework;

namespace BusDep.Testing
{
    [TestFixture]
    public class PruebaConfig
    {
        [Test]
        public void Test1()
        {

            foreach (var dep in DataAccess.BaseDataAccess<Deporte>.GetAll())
            {
                Console.WriteLine("Borrado:" +dep.Id);
                DataAccess.BaseDataAccess<Deporte>.Delete(dep);
            }

            Deporte dep1 = new Deporte{Descripcion = "Futbol", Tipo = "Futbol"};
            DataAccess.BaseDataAccess<Deporte>.Save(dep1);
            dep1 = new Deporte { Descripcion = "Voley", Tipo = "Voley" };
            DataAccess.BaseDataAccess<Deporte>.Save(dep1);
            foreach (var dep in DataAccess.BaseDataAccess<Deporte>.GetAll())
            {
                Console.WriteLine(dep.Descripcion);
                //DataAccess.Base.NHibernateBase.Save(dep);    
            }
        }
    }
}
