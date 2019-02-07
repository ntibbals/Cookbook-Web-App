using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookbook_Web_App.Models.Interfaces
{
    public interface IComments
    {

        Task CreateComment(Comments comment);

        Task<Comments> GetSavedComments(int id);
        Task<IEnumerable<Comments>> GetComments();

        Task GetComments(Comments comment);
        Task<User> GetUser(string userName);
        Task Delete(int id);
    }
}
