using Aspose.Cells;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Equipments.AvaloniaUI.ViewModels;

namespace Equipments.AvaloniaUI.Views
{
    public partial class DialogUploadFileView : UserControl
    {
        DialogUploadFileViewModel _viewModel;
        public DialogUploadFileView()
        {
            InitializeComponent();


            DragDropFilesRectangle.AddHandler(DragDrop.DragOverEvent, DropFilesRectangle_OnDragOverDrag);
            DragDropFilesRectangle.AddHandler(DragDrop.DropEvent, DropFilesRectangle_OnDrop);
            DragDropFilesRectangle.AddHandler(DragDrop.DragLeaveEvent, DropFilesRectangle_OnDragLeave);
            DragDropFilesRectangle.AddHandler(DragDrop.DragEnterEvent, DropFilesRectangle_OnDragEnter);
        }

        private async void DropFilesRectangle_OnDrop(object? sender, DragEventArgs e)
        {
            DragDropFilesRectangle.ZIndex = 0;
            if (e.Data.Contains(DataFormats.Files))
            {
                if (DataContext is DialogUploadFileViewModel vm)
                {
                    var files = e.Data.GetFiles();
                    //var f = e.Data.
                    vm.LoadFiles(files);

                }
            }
        }

        private void DropFilesRectangle_OnDragEnter(object? sender, DragEventArgs e)
        {
            DragDropFilesRectangle.ZIndex = 10;
        }

        private void DropFilesRectangle_OnDragLeave(object? sender, DragEventArgs e)
        {
            DragDropFilesRectangle.ZIndex = 0;
        }

        public void DropFilesRectangle_OnDragOverDrag(object? sender, DragEventArgs e)
        {
            if (e.Data.Contains(DataFormats.Files))
            {
                e.DragEffects = DragDropEffects.Copy;
            }
            else
            {
                e.DragEffects = DragDropEffects.None;
            }
        }

        private async void OpenFileDialogButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);

            var files = await topLevel!.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                AllowMultiple = true,
            });
            
            if (files.Count >= 1)
            {
                if (DataContext is DialogUploadFileViewModel vm)
                {
                    //var f = e.Data.
                    vm.LoadFiles(files);
                }

            }
        }
    }
}
