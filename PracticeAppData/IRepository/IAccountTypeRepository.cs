using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppData.IRepository
{
    public interface IAccountTypeRepository : IGenericRepository<AccountType>, IDisposable
    {
    }
}
