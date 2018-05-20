using EF_DBContext;
using EF_DBContext.Models;
using EF_DBContext.Unit;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class UserService: IUserService
    {
           public UnitOfWork uow = null;

        public UserService()
        {
            uow = new UnitOfWork(new StoreContext());
        }

        public IEnumerable<MstUser> GetAllUsers()
        {   
            var users = uow.UserRepository.GetAll();
            return users;
        }

        public IEnumerable<MstUser> AddUser(MstUser user)
        {
            IEnumerable<MstUser> allUsers = null;
            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;
            user.ModifiedBy = this.GetUserId("");
            uow.UserRepository.Add(user);

            if (uow.Complete())
                allUsers = GetAllUsers();

            return allUsers;
        }

        public IEnumerable<MstUser> UpdateUser(MstUser user)
        {
            IEnumerable<MstUser> allUsers = null;
            MstUser existingUser = uow.UserRepository.Get(user.Id);

            if (existingUser != null)
            {
                existingUser.Address = user.Address;
                existingUser.AltPhone = user.Address;
                existingUser.CityId = user.CityId;
                existingUser.ModifiedBy = this.GetUserId("");
                existingUser.IsActive = user.IsActive;
                existingUser.ModifiedDate = DateTime.Now;
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                existingUser.Pincode = user.Pincode;
                
                // uow.update
                if (uow.Complete())
                    allUsers = GetAllUsers();
            }

            return allUsers;
        }

        public IEnumerable<MstUser> DeleteUser(int userId)
        {
            IEnumerable<MstUser> allUsers = null;

             MstUser existingUser = uow.UserRepository.Get(userId);

             if (existingUser != null)
             {
                 uow.UserRepository.Remove(existingUser);
                 if (uow.Complete())
                     allUsers = GetAllUsers();
             }

            return allUsers;
        }

        private MstUser GetUser(int userId)
        {
            return uow.UserRepository.Get(userId);
        }

        private int GetUserId(string token)
        {
            return uow.UserRepository.GetUserId(token);
        }
    }
}
