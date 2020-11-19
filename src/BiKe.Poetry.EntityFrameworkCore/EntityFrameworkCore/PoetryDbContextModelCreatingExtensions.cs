using BiKe.Poetry.DBEntityModel;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BiKe.Poetry.EntityFrameworkCore
{
    public static class PoetryDbContextModelCreatingExtensions
    {
        public static void ConfigurePoetry(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(PoetryConsts.DbTablePrefix + "YourEntities", PoetryConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
            builder.Entity<Author>(b =>
            {
                b.ToTable(PoetryConsts.DbTablePrefix + "Authors", PoetryConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Type).IsRequired();
                b.Property(x => x.Name).IsRequired();
            });

            builder.Entity<LunYu>(b =>
            {
                b.ToTable(PoetryConsts.DbTablePrefix + "LunYus", PoetryConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Chapter).IsRequired();
                b.Property(x => x.Paragraphs).HasMaxLength(1000);
            });
        }
    }
}