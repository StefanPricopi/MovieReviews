using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Web_app.Pages
{
    public class ChartModel : PageModel
    {
        private readonly LikeDislikeManager likeDislikeManager;
        public List<Tuple<int, int, string>> Top5LikedMedia { get; set; }

        public ChartModel(LikeDislikeManager likeDislikeManager) 
        {
            this.likeDislikeManager = likeDislikeManager;
        }

        public void OnGet()
        {
            Top5LikedMedia = likeDislikeManager.Top5MostLiked();

            // Debug: Print the data to the console
            foreach (var item in Top5LikedMedia)
            {
                Console.WriteLine($"MediaID: {item.Item1}, LikeCount: {item.Item2}, Title: {item.Item3}");
            }
        }

    }
}
