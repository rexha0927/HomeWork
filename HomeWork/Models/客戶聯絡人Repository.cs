using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
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