using System;
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
        //private readonly IMapper mapper;
        public AuthorAppService(IRepository<Author, Guid> repository)
            : base(repository)
        {
            //this.mapper = mapper;
        }
        //public async Task<PagedResult<AuthorDto>> ListResultDtoPageAsync(int skipCount, int pageSize, string name)
        //{
        //    var authorDtos = new List<AuthorDto>();
        //    var query = Repository.WhereIf(string.IsNullOrEmpty(name), s => s.Name.Contains(name)).AsQueryable();
        //    var result = query.Skip(skipCount).Take(pageSize).ToList();
        //    var list = mapper.Map<List<Author>, IQueryable<AuthorDto>>(result);
        //    var totalCount = query.Count();
        //    return new PagedResult<AuthorDto>()
        //    {
        //        Queryable = list,
        //        RowCount = totalCount,
        //    };
        //}
    }
}
