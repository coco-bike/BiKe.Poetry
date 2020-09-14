using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class YuanQu : AuditedEntity<Guid>
    {
        /// <summary>
        /// 作者
        /// </summary>
        public virtual string Author { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Paragraphs { get; set; }
        protected YuanQu()
        {
        }
        public YuanQu(Guid id, string author, string paragraphs)
        : base(id)
        {
            Id = id;
            Author = author;
            Paragraphs = paragraphs;
        }
    }
}
