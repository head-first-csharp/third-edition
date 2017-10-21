using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimatedBee.ViewModel
{
    using View;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    class BeeViewModel
    {
        private readonly ObservableCollection<System.Windows.UIElement>
                    _sprites = new ObservableCollection<System.Windows.UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        public BeeViewModel()
        {
            AnimatedImage firstBee =
                 BeeHelper.BeeFactory(50, 50,
                                TimeSpan.FromMilliseconds(50));
            _sprites.Add(firstBee);

            AnimatedImage secondBee =
                 BeeHelper.BeeFactory(200, 200, TimeSpan.FromMilliseconds(10));
            _sprites.Add(secondBee);

            AnimatedImage thirdBee =
                 BeeHelper.BeeFactory(300, 125, TimeSpan.FromMilliseconds(100));
            _sprites.Add(thirdBee);

            BeeHelper.MakeBeeMove(firstBee, 50, 450, 40);
            BeeHelper.SetBeeLocation(secondBee, 80, 260);
            BeeHelper.SetBeeLocation(thirdBee, 230, 100);
        }
    }
}
