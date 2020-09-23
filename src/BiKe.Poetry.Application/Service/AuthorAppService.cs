using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Repositories;

namespace BiKe.Poetry
{
    public class AuthorAppService :
    CrudAppService<Author, AuthorDto, Guid, PagedAndSortedResultRequestDto,
                        CreateUpdateAuthorDto, CreateUpdateAuthorDto>,
    IAuthorAppService
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        private readonly ICapPublisher _capBus;
        private readonly IBackgroundJobManager _backgroundJobManager;
        private readonly ILogger _logger;
        private readonly IDistributedCache<List<AuthorDto>> _cache;

        public AuthorAppService(IRepository<Author, Guid> repository,
            ICapPublisher capPublisher,
            IBackgroundJobManager backgroundJobManager,
            IDistributedCache<List<AuthorDto>> cache
            )
            : base(repository)
        {
            _authorRepository = repository;
            _capBus = capPublisher;
            _backgroundJobManager = backgroundJobManager;
            _cache = cache;
        }
        public async Task<PagedResultDto<AuthorDto>> ListResultDtoPageAsync(int currentPage, int pageSize, string name)
        {
            var query = _authorRepository.AsTracking();
            //await _authorRepository.GetDbSet<Author, Guid>().AddRangeAsync();
            await _capBus.PublishAsync("now", DateTime.Now);
            //await _backgroundJobManager.EnqueueAsync("你好");
            var rows = await _cache.GetOrAddAsync("PageList",
                async () =>
                {
                    var list = await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
                    return ObjectMapper.Map<List<Author>, List<AuthorDto>>(list);
                }, () => new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
                });
            return new PagedResultDto<AuthorDto>()
            {
                Rows = rows,
                PageCount = pageSize,
                RowCount = await query.CountAsync(),
                PageSize = currentPage,
                CurrentPage = currentPage,
            };
        }
    }
}
