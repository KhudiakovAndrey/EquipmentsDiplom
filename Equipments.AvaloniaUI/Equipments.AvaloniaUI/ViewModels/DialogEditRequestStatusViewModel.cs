using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Services.API;
using HanumanInstitute.MvvmDialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class DialogEditRequestStatusViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
    {
        private readonly RequestStatusChangesService _requestStatusChangesService;
        public bool? DialogResult { get; set; }

        public event EventHandler? RequestClose;
        [Reactive] public UpdateRequestStatusChangeModel Model { get; set; }

        public DialogEditRequestStatusViewModel(UpdateRequestStatusChangeModel? model,
            RequestStatusChangesService requestStatusChangesService)
        {
            _requestStatusChangesService = requestStatusChangesService;
            Model = model ?? new UpdateRequestStatusChangeModel { ID = 0 };
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
                    IDStatus = Model.IDStatus,
                    Description = Model.Description,
                };
                var response = await _requestStatusChangesService.CreateAsync(createDto);
                if (!response.IsSucces)
                {
                    await mainVm.ShowDialogHostAsync(
                        "Не удалось создать объект");
                }
            }
            else
            {
                var response = await _requestStatusChangesService.UpdateAsync(Model);
                if (!response.IsSucces)
                {
                    await mainVm.ShowDialogHostAsync(
                        "Не удалось обновить объект");
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
    }
}
