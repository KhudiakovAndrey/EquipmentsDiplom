using Equipments.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Equipments.Identity.Data
{
    public class RoleRequestConfiguration : IEntityTypeConfiguration<RoleRequest>
    {
        public void Configure(EntityTypeBuilder<RoleRequest> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
