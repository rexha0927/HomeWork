using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return Where(m => m.IsDelete != true);
        }

        public IQueryable<客戶聯絡人> QueryKeyword(string keyword)
        {
            var query = All().OrderBy(m => m.客戶Id).ThenBy(m => m.Id);
            if (!string.IsNullOrEmpty(keyword))
            {
                return All().Where(m => m.客戶資料.客戶名稱.Contains(keyword) || m.職稱.Contains(keyword));
            }
            return query;
        }

        public 客戶聯絡人 Find(int? id)
        {
            return All().FirstOrDefault(a => a.Id == id);
        }

        public bool EmailNotRepeat(客戶聯絡人 客戶聯絡人)
        {
            return All().Any(m => m.Email != 客戶聯絡人.Email && m.Id == 客戶聯絡人.Id);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}