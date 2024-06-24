using Avalonia.Controls;
using Equipments.AvaloniaUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Equipments.AvaloniaUI.Views
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            var vm = App.ServiceProvider!.GetRequiredService<MainMenuWindowViewModel>();
            DataContext = vm;
        }

        public void ShowAuthView()
        {
            var content = new MainAuthView();
            this.Content = content;
        }
        public void ShowMainMenu()
        {
            var content = new MainMenuView();
            var vm = content.DataContext as MainMenuViewModel;
            this.Content = content;
            vm?.Initialize();

        }
    }
}
