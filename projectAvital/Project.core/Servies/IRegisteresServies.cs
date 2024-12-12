using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Servies
{
    public interface IRegisteresServies
    {
        public IEnumerable<Registeres> GetRegister();
        public Registeres GetRegisteres(string id);
        public Registeres AddRegisteres(Registeres registeres);
        public void Updateregisteres(string registeresId, Registeres registeres);
        public bool ChangeRegisteresStatus(string registeresId);
    }
}
