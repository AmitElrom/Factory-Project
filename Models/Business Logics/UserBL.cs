using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factory_Project.Models.Business_Logics
{
    public class UserBL
    {
        private FactoryDBEntities FactoryDB = new FactoryDBEntities();

        public List<User> GetUsers()
        {
            return FactoryDB.User.ToList();
        }

        public string UpdateUser(int id)
        {
            var CreditCount = "";

            var user = FactoryDB.User.Where(x => x.ID == id).First();
            if (user.Date == DateTime.Today && user.NumOfActions < 30)
            {
                user.NumOfActions++;
                CreditCount = $"{user.NumOfActions}/30";
                FactoryDB.SaveChanges();
            }
            else if(user.Date != DateTime.Today && user.NumOfActions > 0)
            {
                user.Date = DateTime.Today;
                user.NumOfActions = 0;
                user.NumOfActions++;
                CreditCount = $"{user.NumOfActions}/30";
                FactoryDB.SaveChanges();
            }
            else
            {
                user.Date = DateTime.Today;
                user.NumOfActions = 0;
                CreditCount = "No more doable actions";
            }

            return CreditCount;
        }
    }
}