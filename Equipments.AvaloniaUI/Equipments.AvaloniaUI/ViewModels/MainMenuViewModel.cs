using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        [Reactive] public UserControl SelectedView { get; set; }
        public MainMenuViewModel()
        {

        }
    }
}
