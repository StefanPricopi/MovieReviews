using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using ModelLibrary.DTO;
using ModelLibrary.Interfaces;
using ModelLibrary.NewsletterStrategy;

namespace Web_app.Pages
{
    public class NewsletterController : Controller
    {
        private readonly UserProfileManager _userProfileManager;
        private readonly NewsletterManager _newsletterManager;

        public NewsletterController(
            UserProfileManager userProfileManager,
            NewsletterManager newsletterManager)
        {
            _userProfileManager = userProfileManager;
            _newsletterManager = newsletterManager;
        }


        public ActionResult SendNewsletters(int userId)
        {
            List<string> userNewsletterPreferences = _userProfileManager.GetUserNewsletterPreferences(userId);

            foreach (string preference in userNewsletterPreferences)
            {
                INewsletterStrategy strategy = GetStrategyFromPreference(preference);
                if (strategy != null)
                {
                    _newsletterManager.AddStrategy(strategy);
                }
                else
                {
                }
            }

            _newsletterManager.ExecuteNewsletterSending();
            return RedirectToAction("Index");
        }

        private INewsletterStrategy GetStrategyFromPreference(string preference)
        {
            switch (preference)
            {
                case "60s":
                    return new MinuteNewsletter(); // Instantiate and return MinuteNewsletter
                case "daily":
                    return new DailyNewsletter(); // Instantiate and return DailyNewsletter
                case "weekly":
                    return new WeeklyNewsletter(); // Instantiate and return WeeklyNewsletter
                default:
                    return null; 
            }
        }

    }
}
