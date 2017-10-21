using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BeeAttack.View
{
    using ViewModel;

    public partial class BeeAttackGameControl : UserControl
    {
        private readonly ViewModel.BeeAttackViewModel _viewModel = new ViewModel.BeeAttackViewModel();

        public BeeAttackGameControl()
        {
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.StartGame(flower.RenderSize, hive.RenderSize, playArea.RenderSize);
        }

        private void UserControl_ManipulationDelta(object sender,
                                                     System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            _viewModel.ManipulationDelta(e.DeltaManipulation.Translation.X);
        }
    }
}
