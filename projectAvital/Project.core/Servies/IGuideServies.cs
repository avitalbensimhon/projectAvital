using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Servies
{
    public interface IGuideServies
    {
        public IEnumerable<Guide> GetGuides();
        public Guide GetGuide(string id);
        public Guide AddGuide(Guide guide);
        public void UpdateGuide(string guideId, Guide guide);
        public bool ChangeGuideStatus(string guideId);

    }
}
