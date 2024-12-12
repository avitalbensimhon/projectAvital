using Microsoft.EntityFrameworkCore;
using Project.core.model;
using Project.core.Reposetory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Reposetory
{
    public class RegisteresReposetory: IRegisteresReposetory
    {
        private Datacontext _context;
        public RegisteresReposetory(Datacontext context)
        {
            _context = context;
        }
        public IEnumerable<Registeres> GetRegisteres()
        {  
            return _context.registeres.Include(t=>t.trips);
        }
        public Registeres GetRegisteres(string id)
        {
            //נשלח את התז רק לאחר בדיקה בסרויס שזה לא שווה מינוס אחד

            var index = _context.registeres.ToList().FindIndex(e => e.id.Equals(id));
            return _context.registeres.Include(t=>t.trips).ToList()[index];
        }
        public Registeres AddRegisteres(Registeres registeres)
        {
            _context.registeres.Add(registeres);
            return registeres;
        }
        public void UpdateRegisteres(string registeresId, Registeres registeres)
        {
            var index = _context.registeres.ToList().FindIndex(e => e.id.Equals(registeresId));
            _context.registeres.ToList()[index].name = registeres.name;
            _context.registeres.ToList()[index].id = registeres.id;
            _context.registeres.ToList()[index].age = registeres.age;

        }
        public void ChangeRegisteresStatus(string registeresId)
        {
            var index = _context.registeres.ToList().FindIndex(e => e.id.Equals(registeresId));
            _context.registeres.ToList()[index].status = false;
        }
    }
}
