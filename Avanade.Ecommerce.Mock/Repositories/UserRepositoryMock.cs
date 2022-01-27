using Avanade.Ecommerce.Core.Entities;
using Avanade.Ecommerce.Core.Repositories;
using Avanade.Ecommerce.Mock.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanade.Ecommerce.Mock.Repositories
{
    public class UserRepositoryMock : IUserRepository
    {
        public User GetByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return null;

            return AllocationMockStorage.Users.Where(u => u.UserName.Equals(userName)).FirstOrDefault();
        }
    }
}
