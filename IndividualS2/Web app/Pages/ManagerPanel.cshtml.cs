using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_app.Pages
{
    [Authorize(Roles = "Manager")]
    public class ManagerPanelModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
