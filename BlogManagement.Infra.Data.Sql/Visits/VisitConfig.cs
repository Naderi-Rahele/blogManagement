using BlogManagement.Core.Domain.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.Visits
{
    public class VisitConfig: IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.Property(c => c.PostId).IsRequired();
            builder.Property(c => c.CreatedOn).IsRequired();
        }
    }
    }