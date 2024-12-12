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
    public class GuideServies: IGuideServies
    {
        private IGuideReposetory _guideReposetory ;
        public GuideServies(IGuideReposetory guideReposetory)
        {
            _guideReposetory = guideReposetory;
        }
        public IEnumerable<Guide> GetGuides()
        {
            return _guideReposetory.GetGuides();
        }
        public Guide GetGuide(string id)
        {
          if(IsExist(id))
                return _guideReposetory.GetGuide(id);
            return null;
        }
        public Guide AddGuide(Guide guide)
        {
          if(IsExist(guide.id))
            { 
                UpdateGuide(guide.id,guide);
                return guide;
            }
            _guideReposetory.AddGuide(guide);
            return guide;
        }
        public void UpdateGuide(string guideId, Guide guide)
        {
           if(IsExist(guideId))
            {
              _guideReposetory.UpdateGuide(guideId, guide);
                return;
            }
            _guideReposetory.AddGuide(guide);
        }
        public bool ChangeGuideStatus(string guideId)
        {
           if(IsExist(guideId))
            {
                _guideReposetory.ChangeGuideStatus(guideId); 
                return true;
            }
           return false;      
                  
        }
        public bool IsExist(string guides)
        {
            var gudes = _guideReposetory.GetGuides();
             var exist=gudes.Any(guide => guide.id.Equals(guides)  );
            if(exist) { return true; }
            return false;
        }
    }
}
