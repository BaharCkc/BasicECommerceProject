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
    public class StatusConfiguration : BaseConfiguration<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            base.Configure(builder);

            builder.Metadata.FindNavigation(nameof(Status.OrderList)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
