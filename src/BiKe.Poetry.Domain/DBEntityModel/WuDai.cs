using BiKe.Poetry.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class WuDai : AuditedEntity<Guid>
    {

        /// <summary>
        /// 类别， 3.五代·花间集，4五代·南唐二主词
        /// </summary>
        public virtual WuDaiType Type { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Paragraphs { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 题词
        /// </summary>
        public virtual string Rhythmic { get; set; }
        /// <summary>
        /// 备注科普
        /// </summary>
        public virtual string Notes { get; set; }

        protected WuDai()
        {
        }
        public WuDai(Guid id, WuDaiType type, string author, string paragraphs, string title,string rhythmic,string notes)
        : base(id)
        {
            Id = id;
            Type = type;
            Paragraphs = paragraphs;
            Title = title;
            Rhythmic = rhythmic;
            Notes = notes;
        }
    }
}
