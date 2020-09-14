using BiKe.Poetry.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry
{
    public class Author : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 类别，1唐诗，2宋诗，3宋词...
        /// </summary>
        public virtual AuthorType Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Desc { get; set; }

        /// <summary>
        /// 短述
        /// </summary>
        public virtual string ShortDesc { get; set; }

        protected Author()
        {
        }
        public Author(Guid id, AuthorType type, string name, string desc, string shortDesc)
        : base(id)
        {
            Id = id;
            Type = type;
            Name = name;
            Desc = desc;
            ShortDesc = shortDesc;
        }
    }
}
