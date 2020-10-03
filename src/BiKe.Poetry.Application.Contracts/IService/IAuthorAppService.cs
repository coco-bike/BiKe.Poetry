using System;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BiKe.Poetry
{
    public interface IAuthorAppService :
      ICrudAppService< //定义了CRUD方法
          AuthorDto, //用来展示
          Guid, //主键
          PagedAndSortedResultRequestDto, //分页和排序
          CreateUpdateAuthorDto, //用于创建
          CreateUpdateAuthorDto> //用于更新
    {
        Task<PagedResultDto<AuthorDto>> ListResultDtoPageAsync(int currentPage, int pageSize, string name);

        Task<bool> TestJob();
    }
}
