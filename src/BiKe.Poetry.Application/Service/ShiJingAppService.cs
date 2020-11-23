using System;
using System.Collections.Generic;
using System.Text;
using BiKe.Poetry.DBEntityModel;
using BiKe.Poetry.Dto;
using BiKe.Poetry.IService;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BiKe.Poetry.Service
{
    public class ShiJingAppService  :
        CrudAppService<ShiJing, ShiJingDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateShiJingDto, CreateUpdateShiJingDto>,
        IShiJingAppService
    {
        public ShiJingAppService(IRepository<ShiJing, Guid> repository)
            : base(repository)
        {

        }
    }
}
