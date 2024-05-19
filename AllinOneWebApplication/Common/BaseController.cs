using AllinOneApiApplication.Model.Login;
using AllinOneApiApplication.Model.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AllinOneWebApplication.Common
{
    public class BaseController : Controller
    {
        private UserInfoModel ? _loggedInUser;

        public UserInfoModel LoggedInUser
        {
            get
            {
                UserInfoModel userInfo = JsonConvert.DeserializeObject<UserInfoModel>(HttpContext.Session.GetString("UserInfo"));
                return userInfo;
                //return new User() { UserId= userInfo.FK_PracticeId, UserName="Ramvir Singh"};
            }

        }
    }
}
