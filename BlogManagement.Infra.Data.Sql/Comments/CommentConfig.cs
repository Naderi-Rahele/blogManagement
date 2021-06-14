using System;
using BlogManagement.Core.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infra.Data.Sql.Comments
{
    public class CommentConfig: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Desciption).IsRequired().HasMaxLength(500);
             builder.Property(c => c.Title).IsRequired().HasMaxLength(50);
             builder.Property<DateTime>("InsertDate");
             builder.Property<DateTime>("UpdateDate");
             builder.Property<DateTime>("InsertBy");
             builder.Property<DateTime>("UpdateBy");
        }
    }
    }