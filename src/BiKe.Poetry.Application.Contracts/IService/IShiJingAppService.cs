using System;
using System.Collections.Generic;
using System.Text;
using BiKe.Poetry.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BiKe.Poetry.IService
{
    public interface IShiJingAppService : ICrudAppService< //定义了CRUD方法
        ShiJingDto, //用来展示
        Guid, //主键
        PagedAndSortedResultRequestDto, //分页和排序
        CreateUpdateShiJingDto, //用于创建
        CreateUpdateShiJingDto> //用于更新
    {

    }
}
