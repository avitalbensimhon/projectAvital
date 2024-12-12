using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Reposetory
{
    public interface IRegisteresReposetory
    {
        public IEnumerable<Registeres> GetRegisteres();
        public Registeres GetRegisteres(string id);
        public Registeres AddRegisteres(Registeres registeres);
        public void UpdateRegisteres(string registeresId, Registeres registeres);
        public void ChangeRegisteresStatus(string registeresId);
    }
}
