using PracticeAppData;
using PracticeAppData.IRepository;
using PracticeAppData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAppBusiness.BusinessLogic
{
    public class UserLogic
    {
        PracticeDBEntities context;
        IUserRepository userRepository;

        public UserLogic()
        {
            context = new PracticeDBEntities();
            userRepository = new UserRepository(context);
        }

        public User UserRegistation(User user)
        {
            var saveUser = userRepository.Insert(user);
            return saveUser;
        }

    }
}
