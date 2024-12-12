﻿using Project.core.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.core.Reposetory
{
    public interface IGuideReposetory
    {
        public IEnumerable<Guide> GetGuides();
        public Guide GetGuide(string id);
        public Guide AddGuide(Guide guide);
        public void UpdateGuide(string guideId, Guide guide);
        public void ChangeGuideStatus(string guideId);

    }
}
