using Equipments.AvaloniaUI.Data;
using HanumanInstitute.MvvmDialogs;
using HanumanInstitute.MvvmDialogs.Avalonia.DialogHost;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private readonly SettingsDbContext _dbContext;

        //public event EventHandler 
        public AuthorizationViewModel(SettingsDbContext dbContext)
        {
            AuthCommand = ReactiveCommand.CreateFromTask(Auth);
            _dbContext = dbContext;
        }
        public ReactiveCommand<Unit, Unit> AuthCommand { get; private set; }
        public async Task Auth()
        {

        }
    }
}
