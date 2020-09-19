using BiKe.Poetry.DBEntityModel;
using BiKe.Poetry.Dto;
using BiKe.Poetry.IService;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PoetryApi.Service
{

    public class LunYuAppService :
   CrudAppService<LunYu, LunYuDto, Guid, PagedAndSortedResultRequestDto,
                       CreateUpdateLunYuDto, CreateUpdateLunYuDto>,
   ILunYuAppService
    {
        public LunYuAppService(IRepository<LunYu, Guid> repository)
            : base(repository)
        {

        }
        public async Task<bool> ReceiveMessage(DateTime dateTime)
        {
            return true;
        }
    }
}
