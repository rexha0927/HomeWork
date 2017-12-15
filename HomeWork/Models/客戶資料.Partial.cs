using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HomeWork.Models
{
    public enum Type
    {
        /// <summary>
        /// T:鈦金會員
        /// </summary>
        鈦金會員,

        /// <summary>
        /// P:白金會員
        /// </summary>
        白金會員,

        /// <summary>
        /// G:金牌會員
        /// </summary>
        金牌會員,

        /// <summary>
        /// S:一般會員
        /// </summary>
        一般會員,
    }

    [MetadataType(typeof(客戶資料MetaData))]
    public partial class 客戶資料
    {
        public List<SelectListItem> 客戶分類清單 { get; set; }
    }

    public partial class 客戶資料MetaData
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入客戶名稱")]
        public string 客戶名稱 { get; set; }

        [StringLength(8, ErrorMessage = "欄位長度不得大於 8 個字元")]
        [Required(ErrorMessage = "請輸入統一編號")]
        public string 統一編號 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入電話")]
        [RegularExpression(@"^\d{6,8}$", ErrorMessage = "請輸入正確的電話號碼")]
        public string 電話 { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入傳真")]
        [Phone]
        public string 傳真 { get; set; }

        [StringLength(100, ErrorMessage = "欄位長度不得大於 100 個字元")]
        [Required(ErrorMessage = "請輸入地址")]
        public string 地址 { get; set; }

        [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]
        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        public bool? IsDelete { get; set; }

        [Display(Name = "客戶分類")]
        //public string 客戶分類 { get; set; }
        public Type 客戶分類 { get; set; }

        //[Display(Name = "客戶分類碼")]
        //public Type TypeString
        //{
        //    get
        //    {
        //        return Flow.ConvTypeString(this.客戶分類);
        //    }
        //}

        [Display(Name = "客戶分類(顯示用)")]
        public string TypeName
        {
            get
            {
                return 客戶分類.ToString();
            }
        }

        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }

    /// <summary>
    /// 流程系列
    /// </summary>
    public static class Flow
    {
        public static Type ConvTypeString(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return Type.一般會員;

            switch (type)
            {
                case "T":
                    return Type.鈦金會員;
                case "P":
                    return Type.白金會員;
                case "G":
                    return Type.金牌會員;
                case "S":
                    return Type.一般會員;
                default:
                    return Type.一般會員;
            }
        }
    }
}
