using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiKe.Poetry.Dto
{
    public class CreateUpdateLunYuDto
    {
        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "内容必填")]
        public string Paragraphs { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题必填")]
        public string Chapter { get; set; }
    }
}
