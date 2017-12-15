using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return Where(m => m.IsDelete != true);
        }

        public IQueryable<客戶銀行資訊> QueryKeyword(string keyword)
        {
            var query = All().OrderBy(m => m.客戶Id).ThenBy(m => m.Id);

            if (!string.IsNullOrEmpty(keyword))
            {
                return All().Where(m => m.帳戶名稱.Contains(keyword));
            }

            return query;
        }

        public 客戶銀行資訊 Find(int? id)
        {
            return All().FirstOrDefault(a => a.Id == id);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}