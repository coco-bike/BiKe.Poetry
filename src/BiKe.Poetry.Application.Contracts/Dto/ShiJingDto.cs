using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BiKe.Poetry.Dto
{
    public class ShiJingDto : AuditedEntityDto<Guid>
    {
        /// <summary>
        /// 词牌名
        /// </summary>
        public virtual string Chapter { get; set; }
        /// <summary>
        /// ...
        /// </summary>
        public virtual string Section { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 测试
        /// </summary>
        public List<TestDto> Tests { get; set; }
    }

    public class TestDto
    {
        public string Name { get; set; }

        public int Count { get; set; }
    }

}
