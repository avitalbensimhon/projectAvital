using Project.core.model;
using Project.core.Reposetory;
using Project.core.Servies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Servies
{
    public class RegisteresServies: IRegisteresServies
    {
        IRegisteresReposetory _registeresReposetory;
        public RegisteresServies(IRegisteresReposetory registeresReposetory)
        {
            _registeresReposetory = registeresReposetory;
        }
        public IEnumerable<Registeres> GetRegister()
        {
            return _registeresReposetory.GetRegisteres();
        }
        public Registeres GetRegisteres(string id)
        {
          if(IsExist(id))
            {
                return _registeresReposetory.GetRegisteres(id);
            }
          return null;
        }
        public Registeres AddRegisteres(Registeres registeres)
        {
            if (IsExist(registeres.id))
            {
                _registeresReposetory.UpdateRegisteres(registeres.id, registeres);
                return registeres;
                  
            }
            _registeresReposetory.AddRegisteres(registeres);
            return registeres;
        }
        public void Updateregisteres(string registeresId, Registeres registeres)
        {
            if (IsExist(registeres.id))
            {
                _registeresReposetory.UpdateRegisteres(registeresId, registeres);
                return;
            }
            _registeresReposetory.AddRegisteres(registeres);
        }
        public bool ChangeRegisteresStatus(string registeresId)
        {
            if (IsExist(registeresId))
            {
                _registeresReposetory.ChangeRegisteresStatus(registeresId); 
                return true;
            }
            return false;  
              
        }
        public bool IsExist(string id)
        {
            var register = _registeresReposetory.GetRegisteres();
            var exist = register.Any(guide => guide.id == id);
            if (exist) { return true; }
            return false;
        }
    }
}

