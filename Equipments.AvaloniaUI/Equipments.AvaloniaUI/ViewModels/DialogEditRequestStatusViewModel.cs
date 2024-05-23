using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using Nito.AsyncEx;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Serilog;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class DialogEditRequestStatusViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
    {
        private readonly RequestStatusChangesService _requestStatusChangesService;
        private readonly RequestStatusesService _requestStatusesService;
        public bool? DialogResult { get; set; }

        public event EventHandler? RequestClose;
        [Reactive] public UpdateRequestStatusChangeModel Model { get; set; }

        public DialogEditRequestStatusViewModel(RequestStatusChangesService requestStatusChangesService,
            RequestStatusesService requestStatusesService)
        {
            _requestStatusChangesService = requestStatusChangesService;
            _requestStatusesService = requestStatusesService;
        }
        public void Intitialize()
        {
            InitializeNotify = NotifyTaskCompletion.Create(GetAllStatuses);
        }
        private async Task GetAllStatuses()
        {
            try
            {
                var response = await _requestStatusesService.GetAll();
                if (response.IsSucces)
                {
                    Statuses = new ObservableCollection<RequestStatusModel>(response.Data);
                    if (Model.Status != null)
                    {
                        var idModelStatus = Model.Status.ID;
                        Model.Status = Statuses.FirstOrDefault(x => x.ID == idModelStatus)!;
                    }
                }
            }
            catch (WebException ex)
            {
                Log.Fatal(ex.Message);
                RequestClose?.Invoke(this, EventArgs.Empty);
            }
        }

        private ReactiveCommand<Unit, Unit>? _edit;
        public ReactiveCommand<Unit, Unit> Edit => _edit ??= ReactiveCommand.CreateFromTask(EditImpl);
        private async Task EditImpl()
        {
            var mainVm = App.MainMenuVM;
            if (Model.ID == 0)
            {
                //Добавление
                var createDto = new CreateRequestStatusChangeModel
                {
                    IDRequestService = Model.IDRequestService,
                    IDStatus = Model.Status.ID,
                    Description = Model.Description,
                };

                try
                {
                    var response = await _requestStatusChangesService.CreateAsync(createDto);
                    if (!response.IsSucces)
                    {
                        await mainVm.ShowDialogHostAsync(
                            "Не удалось создать объект");
                    }
                }
                catch (WebException ex)
                {
                    Log.Fatal(ex.Message);
                    RequestClose?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                try
                {
                    var response = await _requestStatusChangesService.UpdateAsync(Model);
                    if (!response.IsSucces)
                    {
                        await mainVm.ShowDialogHostAsync(
                            "Не удалось обновить объект");
                    }
                }
                catch (WebException ex)
                {

                    Log.Fatal(ex.Message);
                    RequestClose?.Invoke(this, EventArgs.Empty);
                }
            }
            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private ReactiveCommand<Unit, Unit>? _cancel;
        public ReactiveCommand<Unit, Unit> Cancel => _cancel ??= ReactiveCommand.Create(CancelImpl);
        private void CancelImpl()
        {

            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        #region Properties

        [Reactive] public ObservableCollection<RequestStatusModel> Statuses { get; private set; } = new();

        #endregion
    }
}
