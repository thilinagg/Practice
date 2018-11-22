using PracticeAppData.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppData.Repository
{
    public class AccountTypeRepository : GenericRepository<AccountType>, IAccountTypeRepository
    {
        private bool disposed = false;

        public AccountTypeRepository(PracticeDBEntities context)
            : base(context)
        {

        }

        #region Dispose Function

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                        Context.Dispose();
                }
                disposed = true;
            }
        }

        #endregion
    }
}
