using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class LunYu : AuditedEntity<Guid>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Paragraphs { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Chapter { get; set; }

        protected LunYu()
        {
        }
        public LunYu(Guid id, string paragraphs, string chapter)
        : base(id)
        {
            Id = id;
            Paragraphs = paragraphs;
            Chapter = chapter;
        }
    }
}
