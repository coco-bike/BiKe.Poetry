using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BiKe.Poetry.DBEntityModel
{ 
    public class YouMengYing : AuditedEntity<Guid>
    {
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Comment { get; set; }

        protected YouMengYing()
        {
        }
        public YouMengYing(Guid id,string content,string comment)
        : base(id)
        {
            Id = id;
            Content = content;
            Comment = comment;
        }
    }
}
