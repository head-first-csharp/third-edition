using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmysComics
{
    using System.Windows.Media.Imaging;

    class ComicQuery
    {
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public BitmapImage Image { get; private set; }

        public ComicQuery(string title, string subtitle,
                          string description, BitmapImage image)
        {
            Title = title;
            Subtitle = subtitle;
            Description = description;
            Image = image;
        }
    }
}
