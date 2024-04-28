using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Xaml.Interactivity;
using Equipments.AvaloniaUI.Models;
using System.Linq;

namespace Equipments.AvaloniaUI.Behaviors
{
    public class DataGridAddColumnCheckSelectionBehavior : Behavior<DataGrid>
    {
        private DataGrid _dataGrid;
        private CheckBox _headerCheckBox;
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += OnDataGridLoaded;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Loaded -= OnDataGridLoaded;
        }

        private void OnDataGridLoaded(object? sender, RoutedEventArgs e)
        {
            _dataGrid = sender as DataGrid;
            if (_dataGrid != null)
            {
                var template = new FuncDataTemplate<ISelectableModel>((value, namescope) =>
                {

                    var check = new CheckBox
                    {
                        [!CheckBox.IsCheckedProperty] = new Binding("IsSelected", BindingMode.OneWay),
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,

                    };
                    check.IsCheckedChanged += OnSelectionChangedCheckBox;
                    return check;
                });

                var headerTemplate = new FuncDataTemplate<ISelectableModel>((value, namescope) =>
                {
                    _headerCheckBox = new CheckBox
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                    };
                    _headerCheckBox.IsCheckedChanged += (s, a) =>
                    {
                        var check = s as CheckBox;
                        if (check.IsChecked == true)
                            _dataGrid.ItemsSource.Cast<ISelectableModel>().ToList().ForEach(vm => vm.IsSelected = true);
                        else if (check.IsChecked == false)
                            _dataGrid.ItemsSource.Cast<ISelectableModel>().ToList().ForEach(vm => vm.IsSelected = false);
                    };
                    return _headerCheckBox;
                });

                var selection = new DataGridTemplateColumn
                {
                    Tag = "selection",
                    CellTemplate = template,
                    HeaderTemplate = headerTemplate,
                    CanUserResize = false,
                    CanUserReorder = false,
                    CanUserSort = false,
                    Width = new DataGridLength(40),

                };
                DataGridColumnManipulatonBehavior.SetIsCanRemoveColumn(selection, true);

                _dataGrid.Columns.Insert(0, selection);
            }
        }

        private void OnSelectionChangedCheckBox(object? sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            var vm = checkBox!.DataContext as ISelectableModel;
            vm.IsSelected = checkBox.IsChecked ?? false;

            int countSelectedItems = _dataGrid.ItemsSource.Cast<ISelectableModel>().Where(row => row.IsSelected == true).Count();

            if (countSelectedItems == 0)
                _headerCheckBox.IsChecked = false;

            else if (countSelectedItems == _dataGrid.ItemsSource.Cast<ISelectableModel>().Count())
                _headerCheckBox.IsChecked = true;

            else
                _headerCheckBox.IsChecked = null;
        }
    }
}
