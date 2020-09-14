using BiKe.Poetry.Enums;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{
    public class TangSong : AuditedEntity<Guid>
    {

        /// <summary>
        /// 类别，0唐诗，1宋词，2元曲...
        /// </summary>
        public virtual TangSongType Type { get; set; }
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

        protected TangSong()
        {
        }

        public TangSong(Guid id, TangSongType type, string author, string paragraphs, string title)
        : base(id)
        {
            Id = id;
            Type = type;
            Paragraphs = paragraphs;
            Title = title;
            Author = author;
        }
    }
}
