using Microsoft.AspNetCore.Identity;
using Microsoft.Net.Http.Headers;

namespace Equipments.Identity.Models
{
    public class RoleRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
        public RoleRequestStatuses Status { get; set; }
        public string Description { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        public IdentityRole? Role { get; set; }
    }
    public enum RoleRequestStatuses
    {
        Обрабатывается,
        Одобрена,
        Отклонена
    }
}
