using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class AllViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public List<FollowViewModel> CurrentUserFollows { get; set; }
    }
}
