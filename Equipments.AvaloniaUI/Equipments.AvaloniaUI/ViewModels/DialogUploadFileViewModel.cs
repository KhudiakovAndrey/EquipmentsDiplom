using Avalonia.Platform.Storage;
using DynamicData;
using HanumanInstitute.MvvmDialogs;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

namespace Equipments.AvaloniaUI.ViewModels
{
    public class DialogUploadFileViewModel : ViewModelBase, IModalDialogViewModel, ICloseable
    {
        public bool? DialogResult { get; private set; }

        public event EventHandler? RequestClose;
        private readonly IDialogService _dialogService;
        public DialogUploadFileViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }
        public DialogUploadFileViewModel()
        {

        }
        public async void LoadFiles(IEnumerable<IStorageItem> files)
        {
            Files.AddRange(files);
            //var file = await Files[0].GetBasicPropertiesAsync();
            //file.
        }

        public async void LoadSelectedFiles()
        {

        }

        private ReactiveCommand<IStorageItem, Unit>? _deleteFile;
        public ReactiveCommand<IStorageItem, Unit>? DeleteFile => _deleteFile ?? ReactiveCommand.Create<IStorageItem>(DeleteFileImpl);
        private void DeleteFileImpl(IStorageItem storageItem) => Files.Remove(storageItem);

        private ReactiveCommand<Unit, Unit>? _ok;
        public ReactiveCommand<Unit, Unit>? Ok => _ok ?? ReactiveCommand.Create(OkImpl);
        private void OkImpl()
        {
            DialogResult = true;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private ReactiveCommand<Unit, Unit>? _cancel;
        public ReactiveCommand<Unit, Unit>? Cancel => _cancel ?? ReactiveCommand.Create(CancelImpl);
        private void CancelImpl()
        {
            DialogResult = false;
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
        [Reactive] public ObservableCollection<IStorageItem>? SelectedFiles { get; set; } = new();
        [Reactive] public ObservableCollection<IStorageItem> Files { get; private set; } = new();

    }
}
