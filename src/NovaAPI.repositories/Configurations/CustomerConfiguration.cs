﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NovaAPI.Repositories.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<object>
    {
        public void Configure(EntityTypeBuilder<object> builder)
        {
            throw new NotImplementedException();
        }
    }
}