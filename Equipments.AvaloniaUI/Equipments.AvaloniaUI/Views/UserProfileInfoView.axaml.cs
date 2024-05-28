using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Equipments.AvaloniaUI.ViewModels;
using ReactiveUI;
using System;
using System.IO;
using System.Linq;

namespace Equipments.AvaloniaUI.Views
{
    public partial class UserProfileInfoView : UserControl
    {
        public UserProfileInfoView()
        {
            InitializeComponent();
            PART_EllipseDragDropImage.AddHandler(DragDrop.DragEnterEvent, PART_EllipseDragDropImage_OnDragEnter);
            PART_EllipseDragDropImage.AddHandler(DragDrop.DropEvent, PART_EllipseDragDropImage_OnDrop);
            PART_EllipseDragDropImage.AddHandler(DragDrop.DragOverEvent, PART_EllipseDragDropImage_OnDragOver);
            PART_EllipseDragDropImage.AddHandler(DragDrop.DragLeaveEvent, PART_EllipseDragDropImage_OnDragLeave);

            this.WhenAnyValue(vm => vm.PART_EllipseDragDropImage.Tag).Subscribe(tag =>
            {
                if (tag == null || tag.ToString() == string.Empty)
                    PART_droppedTextBlock.IsVisible = false;
                else if (tag.ToString() == "dropped")
                    PART_droppedTextBlock.IsVisible = true;
            });

        }

        private void PART_EllipseDragDropImage_OnDragLeave(object? sender, DragEventArgs e)
        {
            PART_EllipseDragDropImage.Tag = "";
        }

        private async void PART_EllipseDragDropImage_OnDragEnter(object? sender, DragEventArgs e)
        {
            PART_EllipseDragDropImage.Tag = "dropped";
        }
        private async void PART_EllipseDragDropImage_OnDrop(object? sender, DragEventArgs e)
        {
            if (e.Data.Contains(DataFormats.Files))
            {
                var filePath = Uri.UnescapeDataString(e.Data.GetFiles().First().Path.AbsolutePath);
                if (Path.GetExtension(filePath).ToLowerInvariant() == ".png" ||
                    Path.GetExtension(filePath).ToLowerInvariant() == ".jpg" ||
                    Path.GetExtension(filePath).ToLowerInvariant() == ".jpeg")
                {
                    var bitmap = new Bitmap(File.OpenRead(filePath));
                    PART_EllipseDragDropImage.Fill = new ImageBrush(bitmap);

                    using var stream = new MemoryStream();


                    bitmap.Save(stream);

                    if (DataContext is UserProfileInfoViewModel vm)
                    {
                        vm.ImageBytes = stream.ToArray();
                    }
                }
            }
            PART_EllipseDragDropImage.Tag = "";
        }
        private async void PART_EllipseDragDropImage_OnDragOver(object? sender, DragEventArgs e)
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

        private void ChangeImageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {

        }
    }
}
