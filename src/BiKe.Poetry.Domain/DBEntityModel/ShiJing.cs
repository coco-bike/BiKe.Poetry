using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class ShiJing : AuditedEntity<Guid>
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

        protected ShiJing()
        {
        }
        public ShiJing(Guid id, string chapter, string section,string content,string title)
        : base(id)
        {
            Id = id;
            Chapter = chapter;
            Section = section;
            Content = content;
            Title = title;
        }
    }
}
