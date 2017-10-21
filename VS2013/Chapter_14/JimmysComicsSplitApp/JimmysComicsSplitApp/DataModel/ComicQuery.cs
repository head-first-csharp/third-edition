using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmysComicsSplitApp.DataModel
{
    class ComicQuery
    {
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }

        public ComicQuery(string title, string subtitle,
                          string description, string imagePath)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
