using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ViewModels;
using Models;
using Converter;

namespace Services
{
    public class FollowService : IFollowService
    {
        private IFollowsDao context;

        public FollowService(IFollowsDao _context)
        {
            this.context = _context;
        }

        public bool Follow(int id, int id2)
        {
            if (context.Add(id, id2))
                return true;
            else
                return false;
        }

        public bool UnFollow(int id)
        {
            if (context.Delete(id))
                return true;
            else
                return false;
        }

        public List<UserViewModel> GetFollows(int id)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            result = UserConverter.ConvertViewModelList(context.GetUserFollows(id));

            return result;
        }

        public List<FollowViewModel> GetList()
        {
            List<FollowViewModel> followlist = new List<FollowViewModel>();
            followlist = UserConverter.ConvertFollowModel(context.GetList());
            return followlist;
        }

        
    }
}