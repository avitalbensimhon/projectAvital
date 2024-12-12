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
    public class GuideReposetory:IGuideReposetory
    {
        private Datacontext _context;
        public GuideReposetory(Datacontext context)
        {
            _context = context;
        }
        public IEnumerable<Guide> GetGuides()
        {
            return _context.guides.Include(t=>t.trips);
        }
        public Guide GetGuide(string id)
        {
            //נשלח את התז רק לאחר בדיקה בסרויס שזה לא שווה מינוס אחד

            var index = _context.guides.ToList().FindIndex(e => e.id.Equals(id));
            return _context.guides.Include(t=>t.trips).ToList()[index];
        }
        public Guide AddGuide(Guide guide)
        {
            _context.guides.Add(guide);
            _context.SaveChanges();
            return guide;
        }
        public void UpdateGuide(string guideId, Guide guide)
        {
            var index = _context.guides.ToList().FindIndex(e => e.id.Equals(guideId));
            _context.guides.ToList()[index].name = guide.name;
            _context.guides.ToList()[index].id = guide.id;
            _context.SaveChanges();
        }
        public void ChangeGuideStatus(string guideId)
        {
            var index = _context.guides.ToList().FindIndex(e => e.id.Equals(guideId));
            _context.guides.ToList()[index].status = false;
            _context.SaveChanges();
        }
    }
}
