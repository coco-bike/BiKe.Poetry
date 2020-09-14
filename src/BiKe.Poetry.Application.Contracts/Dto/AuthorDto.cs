using BiKe.Poetry.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BiKe.Poetry
{
    public class AuthorDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 类别，1唐诗，2宋诗，3宋词...
        /// </summary>
        public AuthorType Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public  string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public  string Desc { get; set; }

        /// <summary>
        /// 短述
        /// </summary>
        public  string ShortDesc { get; set; }
    }
}
