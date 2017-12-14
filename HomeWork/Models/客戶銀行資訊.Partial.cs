namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [MetadataType(typeof(客戶銀行資訊MetaData))]
    public partial class 客戶銀行資訊
    {
        public List<SelectListItem> CustomerList { get; set; }
    }
    
    public partial class 客戶銀行資訊MetaData
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "客戶")]
        [Required]
        public int 客戶Id { get; set; }

        [Required(ErrorMessage = "請輸入銀行名稱")]
        public string 銀行名稱 { get; set; }

        [Range(0, 999)]
        [Required(ErrorMessage = "請輸入銀行代碼")]
        public int 銀行代碼 { get; set; }

        [Range(0, 999)]
        [Required(ErrorMessage = "請輸入分行代碼")]
        public int? 分行代碼 { get; set; }

        [Required(ErrorMessage = "請輸入帳戶名稱")]
        public string 帳戶名稱 { get; set; }

        [Required(ErrorMessage = "請輸入帳戶號碼")]
        public string 帳戶號碼 { get; set; }
        public bool? IsDelete { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
