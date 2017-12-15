using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public 客戶資料 Find(int? id)
        {
            return All().FirstOrDefault(a => a.Id == id);
        }

        public 客戶資料 Create(客戶資料 model)
        {
            if (model==null)
            {
                model = new 客戶資料();
            }

            this.Add(model);

            return model;
        }
    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}