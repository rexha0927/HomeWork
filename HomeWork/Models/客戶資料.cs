//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class 客戶資料
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public 客戶資料()
        {
            this.客戶銀行資訊 = new HashSet<客戶銀行資訊>();
            this.客戶聯絡人 = new HashSet<客戶聯絡人>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入客戶名稱")]
        public string 客戶名稱 { get; set; }

        [Required(ErrorMessage = "請輸入統一編號")]
        public string 統一編號 { get; set; }

        [Required(ErrorMessage = "請輸入電話")]
        [RegularExpression(@"^\d{6,8}$", ErrorMessage = "請輸入正確的電話號碼")]
        public string 電話 { get; set; }

        [Required(ErrorMessage = "請輸入傳真")]
        [Phone]
        public string 傳真 { get; set; }

        [Required(ErrorMessage = "請輸入地址")]
        public string 地址 { get; set; }

        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        public Nullable<bool> IsDelete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}
