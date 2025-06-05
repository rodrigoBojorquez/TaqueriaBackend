using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taqueria.Api.Data.Entities;

namespace Taqueria.Api.Data.Configurations;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        var orderStatusConverter = new EnumToStringConverter<OrderStatus>();
        
        builder
            .Property(o => o.Status)
            .HasConversion(orderStatusConverter);
    }
}