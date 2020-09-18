using AutoMapper;
using AutoMapper.QueryableExtensions;
using BiKe.Poetry.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BiKe.Poetry
{
    public class AuthorAppService :
    CrudAppService<Author, AuthorDto, Guid, PagedAndSortedResultRequestDto,
                        CreateUpdateAuthorDto, CreateUpdateAuthorDto>,
    IAuthorAppService
    {
        private readonly IRepository<Author, Guid> _authorRepository;
        public AuthorAppService(IRepository<Author, Guid> repository
            )
            : base(repository)
        {
            _authorRepository = repository;
        }
        public async Task<PagedResultDto<AuthorDto>> ListResultDtoPageAsync(int pageIndex, int pageSize, string name)
        {
            var query = _authorRepository.AsTracking();
            var list = await query.Skip((pageIndex-1)*pageSize).Take(pageSize).ToListAsync();
            var rows = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list);
            await _authorRepository.GetDbSet<Author, Guid>().AddRangeAsync();
            return new PagedResultDto<AuthorDto>()
            {
                Rows = rows,
                PageCount = pageSize,
                RowCount =await query.CountAsync()
            };
        }
    }
}
