using BiKe.Poetry.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class SiShuWuJing : AuditedEntity<Guid>
    {
        /// <summary>
        /// 类别，0大学，1孟子，2中庸
        /// </summary>
        public virtual SiShuWuJingType Type { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Chapter { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Paragraphs { get; set; }

        protected SiShuWuJing()
        {
        }
        public SiShuWuJing(Guid id, SiShuWuJingType type, string paragraphs, string chapter)
        : base(id)
        {
            Id = id;
            Type = type;
            Paragraphs = paragraphs;
            Chapter = chapter;
        }
    }
}
