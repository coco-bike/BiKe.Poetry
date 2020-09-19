using BiKe.Poetry.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BiKe.Poetry.IService
{

    public interface ILunYuAppService :
  ICrudAppService< //定义了CRUD方法
      LunYuDto, //用来展示
      Guid, //主键
      PagedAndSortedResultRequestDto, //分页和排序
      CreateUpdateLunYuDto, //用于创建
      CreateUpdateLunYuDto> //用于更新
    {
        Task<bool> ReceiveMessage(DateTime dateTime); 
    }
}
