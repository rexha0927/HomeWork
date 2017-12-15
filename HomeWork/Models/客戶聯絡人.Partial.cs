namespace HomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        /// <summary>
        /// 加入模型驗證IValidatableObject
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new 客戶資料Entities();

            if (this.Id == 0)
            {
                //Create
                if (db.客戶聯絡人.Where(p => p.客戶Id == this.客戶Id && p.Email == this.Email).Any())
                {
                    yield return new ValidationResult("Email 已存在", new string[] { "Email" });
                }
            }
            else
            {
                //Update
                if (db.客戶聯絡人.Where(p => p.客戶Id == this.客戶Id && p.Id != this.Id && p.Email == this.Email).Any())
                {
                    yield return new ValidationResult("Email 已存在", new string[] { "Email" });
                }
            }
            yield return ValidationResult.Success;
        }

        public List<SelectListItem> CustomerList { get; set; }
    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int 客戶Id { get; set; }

        [Required(ErrorMessage = "請輸入職稱")]
        public string 職稱 { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        public string 姓名 { get; set; }

        [Required(ErrorMessage = "請輸入Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入手機號碼")]
        [RegularExpression(@"09[0-9]{2}-[0-9]{6}", ErrorMessage = "請輸入正確的手機號碼! 09XX-XXXXXX")]
        public string 手機 { get; set; }

        [RegularExpression(@"^\d{6,8}$", ErrorMessage = "請輸入正確的電話號碼")]
        [Required(ErrorMessage = "請輸入電話")]
        public string 電話 { get; set; }

        public bool? IsDelete { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
