using BasicECommerceProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.DataAccess.Configuration
{
    public class OrderConfiguration : BaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Status)
    .WithMany(x => x.OrderList)
   .HasForeignKey(x => x.StatusId);

            builder.Metadata.FindNavigation(nameof(Order.LineList)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Order.CargoList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
