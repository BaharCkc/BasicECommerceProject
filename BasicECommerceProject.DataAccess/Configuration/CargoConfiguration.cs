using BasicECommerceProject.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.DataAccess.Configuration
{
    public class CargoConfiguration : BaseConfiguration<Cargo>
    {
        public override void Configure(EntityTypeBuilder<Cargo> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Order)
       .WithMany(x => x.CargoList)
      .HasForeignKey(x => x.OrderId);
        }
    }
}
