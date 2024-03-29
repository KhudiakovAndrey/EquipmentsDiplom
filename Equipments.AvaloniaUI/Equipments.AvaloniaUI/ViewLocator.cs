using HanumanInstitute.MvvmDialogs.Avalonia;

namespace Equipments.AvaloniaUI
{
    public class ViewLocator : ViewLocatorBase
    {
        /// <inheritdoc />
        protected override string GetViewName(object viewModel) => viewModel.GetType().FullName!.Replace("ViewModel", "View");
    }
}
