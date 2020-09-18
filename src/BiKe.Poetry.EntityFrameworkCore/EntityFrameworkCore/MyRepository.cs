using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BiKe.Poetry.EntityFrameworkCore
{
    //public class MyRepository <TEntity,Guid> : EfCoreRepository<PoetryDbContext, TEntity, Guid>, IMyRepository<TEntity, Guid>
    //{
    //    public MyRepository(IDbContextProvider<PoetryDbContext> dbContextProvider)
    //   : base(dbContextProvider)
    //    {

    //    }

    //    public async Task<Person> FindByNameAsync(string name)
    //    {
    //        return await DbContext.Set<Person>()
    //            .Where(p => p.Name == name)
    //            .FirstOrDefaultAsync();
    //    }
    //}
}
