using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be empty!")]
        [MinLength(3,ErrorMessage ="Oops! Your password can be hacked by Zucku bhaia!")]
        public string Password { get; set; }
        public int Age { get; set; }
        [AllowHtml()]
        public string Aadhar { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; internal set; }
    }
    public class UserOps
    {
        private readonly static List<User> _user = new List<User>();
        public List<User> GetAll()
        {
            if (_user.Count == 0)
            {
                _user.Add(new User() { Aadhar = "399869861144", Age = 22, Email = "parikshitverma@kpmg.com", Password = "NahiBataunga", Username = "parikshitverma", Roles = new string[] { "Admin" } });
                _user.Add(new User() { Aadhar = "399869861143", Age = 22, Email = "parikshitverma1@kpmg.com", Password = "NahiBataunga1", Username = "parthdubey", Roles = new string[] { "User" } });
            }
            return _user;
        }

        internal bool Update(string username, User pUser)
        {
            User FoundUser = FindUser(username);
            if (FoundUser != null)
            {
                FoundUser.Age = pUser.Age;
                FoundUser.Aadhar = pUser.Aadhar;
                FoundUser.Email = pUser.Email;
                FoundUser.Password = pUser.Password;
                return true;
            }
            throw new Exception("User not found");
        }

        public User FindUser(string username)
        {
            return _user.Find(x => x.Username == username);
        }
        public List<User> MatchUser(string username)
        {
            GetAll();
            return _user.Where((u) => u.Username.Contains(username)).ToList();
        }

        public void Delete(User pUser)
        {
            _user.Remove(_user.Find(user => user.Username == pUser.Username));
        }

        public void Add(User pUser)
        {
            _user.Add(pUser);
        }
    }
}