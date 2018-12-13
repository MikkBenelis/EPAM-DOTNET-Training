using System.Linq;
using System.Web.Mvc;
using ASP.Models;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using Ninject;

namespace ASP.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Account()
        {
            if (this.Session["AccountID"] != null)
            {
                IAccountService service = MvcApplication.Resolver.Get<IAccountService>();
                this.Session["Balance"] = (from a in service.GetAllAccounts()
                                           where a.AccountID == (int)Session["AccountID"]
                                           select a.Balance).Single();
            }
            else
            {
                Response.Redirect("/Authentication/Login");
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult Transfer(TransferModel model)
        {
            if (model.FromAccountID != model.ToAccountID && model.Amount > 0)
            {
                IAccountService service = MvcApplication.Resolver.Get<IAccountService>();
                service.Withdraw(model.FromAccountID, model.Amount);
                service.Deposit(model.ToAccountID, model.Amount);
                this.Session["Balance"] = (from a in service.GetAllAccounts()
                                           where a.AccountID == model.FromAccountID
                                           select a.Balance).Single();
                this.SendNotification(model.FromAccountID, $"{model.Amount} transfered to {model.ToAccountID}");
                this.SendNotification(model.ToAccountID, $"{model.Amount} received from {model.FromAccountID}");
            }

            return this.View("Account");
        }

        public void SendNotification(int accountID, string message)
        {
            IAccountService service = MvcApplication.Resolver.Get<IAccountService>();
            Account account = (from a in service.GetAllAccounts()
                               where a.AccountID == accountID
                               select a).Single();

            this.MailTo("Banking System", account.Login, "Money transferring", message);
        }

        public void MailTo(string from, string to, string subject, string message)
        {
            // TODO
        }
    }
}