using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Equipments.AvaloniaUI.Models
{
    public class UpdateRequestStatusChangeModel : ReactiveObject
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public Guid IDRequestService { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Reactive] public RequestStatusModel Status { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Reactive] public string? Description { get; set; }
    }
}
