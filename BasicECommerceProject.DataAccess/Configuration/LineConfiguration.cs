using BasicECommerceProject.Entities.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceProject.DataAccess.Configuration
{
    public class LineConfiguration : BaseConfiguration<Line>
    {
        public override void Configure(EntityTypeBuilder<Line> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Order)
      .WithMany(x => x.LineList)
     .HasForeignKey(x => x.OrderId);
        }
    }
}
