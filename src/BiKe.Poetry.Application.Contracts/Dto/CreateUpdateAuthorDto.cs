using BiKe.Poetry.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiKe.Poetry
{
    public class CreateUpdateAuthorDto
    {
        /// <summary>
        /// 类别，1唐诗，2宋诗，3宋词...
        /// </summary>
        [Required(ErrorMessage = "类型必填")]
        public AuthorType Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称必填")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 短述
        /// </summary>
        public string ShortDesc { get; set; }
    }
}