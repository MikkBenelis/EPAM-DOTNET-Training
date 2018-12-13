using System.Web.Mvc;
using ASP.Models;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using Ninject;

namespace ASP.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            string resultView = "Login";
            if (model != null && model.Login != null && model.Password != null)
            {
                IAccountService service = MvcApplication.Resolver.Get<IAccountService>();
                foreach (var account in service.GetAllAccounts())
                {
                    if (model.Login == account.Login && model.Password == account.Password)
                    {
                        this.Session["AccountID"] = account.AccountID;
                        this.Session["FirstName"] = account.FirstName;
                        this.Session["LastName"] = account.LastName;
                        this.Session["Balance"] = account.Balance;
                        this.Session["AccountType"] = account.Type;
                        Response.Redirect("/Home/Account");
                        break;
                    }
                }
            }

            return this.View(resultView);
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            string resultView = "Register";
            if (model != null && model.FirstName != null && model.LastName != null)
            {
                if (model.Login != null && model.Password1 != null && model.Password2 != null)
                {
                    if (model.Password1 == model.Password2)
                    {
                        IAccountService service = MvcApplication.Resolver.Get<IAccountService>();
                        service.Create(new Account { Login = model.Login, Password = model.Password1, FirstName = model.FirstName, LastName = model.LastName });
                        resultView = "Login";
                    }
                }
            }

            return this.View(resultView);
        }
    }
}