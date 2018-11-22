using PracticeAppBusiness.ViewModel;
using PracticeAppData;
using PracticeAppData.IRepository;
using PracticeAppData.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppBusiness.BusinessLogic
{
    public class CreateAccountLogic
    {
        PracticeDBEntities context;
        ICreateAccountRepository createAccountRepository;
        IAccountTypeRepository accountTypeRepository;
        IDepositeRepository depositeRepository;

        public CreateAccountLogic()
        {
            context = new PracticeDBEntities();
            createAccountRepository = new CreateAccountRepository(context);
            accountTypeRepository = new AccountTypeRepository(context);
            depositeRepository = new DepositeRepository(context);
        }


        public IList GetAccountType()
        {
            var retItem = accountTypeRepository.GetAll().Select(x => new AccountTypeViewMode
            {
                id = x.id,
                accType = x.accType
            }).ToList();

            return retItem;
        }

        public string GenerateAccountNumber(int id)
        {
            var accNo = (createAccountRepository.GetAll().Count + 1).ToString();

            if (accNo.Length == 1)
            {
                accNo = "00" + (id).ToString() + "0000" + accNo;
            }
            else if (accNo.Length == 2)
            {
                accNo = "00" + (id).ToString() + "000" + accNo;
            }
            else if (accNo.Length == 3)
            {
                accNo = "00" + (id).ToString() + "00" + accNo;
            }
            else if (accNo.Length == 4)
            {
                accNo = "00" + (id).ToString() + "0" + accNo;
            }
            else
            {
                accNo = "00" + (id).ToString() + accNo;
            }

            return accNo;
        }

        public CreateAccount CreateNewAccount(CreateAccountViewModel model)
        {

            CreateAccount ca = new CreateAccount();
            Deposite dp = new Deposite();


            if (model.initialAmmount > 500)
            {
                ca.accountNo = model.accountNo;
                ca.holderName = model.holderName;
                ca.typeId = model.typeId;
                ca.nic = model.nic;
                ca.createDate = DateTime.Now;
                var retItem = createAccountRepository.Insert(ca);

                dp.accId = ca.id;
                dp.deposite1 = model.initialAmmount;
                depositeRepository.Insert(dp);

                return retItem;
            }
            else
            {
                ca.id = 0;
                return ca;
            }
        }


        //get all accounts
        public IList AccountList()
        {
            var retItem = createAccountRepository.GetAll().ToList();
            return retItem;
        }




    }
}
