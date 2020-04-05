using Shop.Domain.Dtos;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.DAO
{
    public class UserDAO
    {
        public readonly ShopDbContext _context = null;
        public UserDAO()
        {
            _context = new ShopDbContext();
        }
        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.ID;
        }
        public bool Delete(int id)
        {
            var query = _context.Users.Where(x => x.ID == id).SingleOrDefault();
            if (query != null)
            {
                _context.Users.Remove(query);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }            
        }
        public bool UpDate(UserDtos userDtos)
        {
            try
            {
                var user = _context.Users.Where(x => x.UserName == userDtos.UserName).SingleOrDefault();
                user.Password = userDtos.Password;
                user.Name = userDtos.Name;
                user.Address = userDtos.Address;
                user.Phone = userDtos.Phone;
                user.Email = userDtos.Email;
                user.ModifiedDate = DateTime.Now;
                user.Status = userDtos.Status;
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool ChangeStatus(int id)
        {
            var user = _context.Users.Find(id);
            user.Status = !user.Status;
            _context.SaveChanges();
            return user.Status;
        }
        public User GetSingle(int id)
        {
            var query = _context.Users.Where(x => x.ID == id).SingleOrDefault();
            return query;
        }
        public List<User> GetAll()
        {
            var list = _context.Users.ToList();
            return list;
        }
        public PagedResult<User> GetPagingUser(int pageIndex, int pageSize, string keyword)
        {
            List<User> list = new List<User>();
            int totalRow = 0;
            if (!string.IsNullOrEmpty(keyword))
            {
                list = _context.Users.Where(x => x.UserName.Contains(keyword) == true).OrderByDescending(x=>x.CreateDate).ToList();                
            }
            else
            {
                list = _context.Users.OrderByDescending(x => x.CreateDate).ToList();
            }
            totalRow = list.Count();
            var data = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var pageResult = new PagedResult<User>()
            {
                Items = data,
                TotalRecord = totalRow
            };
            return pageResult;
        }
        public User GetSingleByUser(string user)
        {
            return _context.Users.Where(x => x.UserName == user).SingleOrDefault();
        }
        public int Login(string user,string pass)
        {
            var query = _context.Users.Where(x => x.UserName == user && x.Password == pass && x.Status ==true).SingleOrDefault();
            if(query != null)
            {
                return 1;
            }
            else { return 0; }
        }
    }
}
