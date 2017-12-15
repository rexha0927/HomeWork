using System;
using System.Linq;
using System.Collections.Generic;
	
namespace HomeWork.Models
{   
	public  class NewTableRepository : EFRepository<NewTable>, INewTableRepository
	{

    }

	public  interface INewTableRepository : IRepository<NewTable>
	{

	}
}