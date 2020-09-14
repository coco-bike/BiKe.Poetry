using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BiKe.Poetry.Dto
{
    public class LunYuDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Paragraphs { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Chapter { get; set; }
    }
}
