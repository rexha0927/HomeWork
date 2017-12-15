using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class VW客戶關聯資料統計表Repository : EFRepository<VW客戶關聯資料統計表>, IVW客戶關聯資料統計表Repository
	{

    }

	public  interface IVW客戶關聯資料統計表Repository : IRepository<VW客戶關聯資料統計表>
	{

	}
}