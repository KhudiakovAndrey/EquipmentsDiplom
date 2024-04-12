using Equipments.AvaloniaUI.ViewModels;
using System;

namespace Equipments.AvaloniaUI.Factorys
{
    public interface ICreateServiceRequestViewModelFactory
    {
        CreateServiceRequestViewModel Create(Guid idParam);
    }
}
