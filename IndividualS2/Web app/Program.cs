using DALClassLibrary.DALs;
using DALClassLibrary.Interfaces;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelLibrary.Interfaces;
using ModelLibrary.NewsletterStrategy;
using Service_Layer.Interfaces_PL_to_LL;


public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureServices((hostContext, services) =>
                {
                    services.AddRazorPages();

                    // LL
                    services.AddScoped<ICommentManager, CommentManager>();
                    services.AddScoped<ILikeDislikeManager, LikeDislikeManager>();
                    services.AddScoped<IMediaManager, MediaManager>();
                    services.AddScoped<IMovieManager, MovieManager>();
                    services.AddScoped<ITvSeriesManager, TvSeriesManager>();
                    services.AddScoped<IReviewManager, ReviewManager>();
                    services.AddScoped<IUserManager, UserManager>();
                    services.AddScoped<IUserProfileManager, UserProfileManager>();
                    services.AddScoped<MinuteNewsletter>();
                    services.AddScoped<DailyNewsletter>();
                    services.AddScoped<WeeklyNewsletter>();
                    //managers
                    services.AddScoped<CommentManager>();
                    services.AddScoped<LikeDislikeManager>();
                    services.AddScoped<MediaManager>();
                    services.AddScoped<MovieManager>();
                    services.AddScoped<TvSeriesManager>();
                    services.AddScoped<ReviewManager>();
                    services.AddScoped<UserManager>();
                    services.AddScoped<UserProfileManager>();
                    services.AddScoped<NewsletterManager>();

                    //DAL
                    services.AddScoped<ICommentDAL, CommentDAL>();
                    services.AddScoped<ILikeDislike, LikeDislikeDAL>();
                    services.AddScoped<IMediaManagerDAL, MediaDAL>();
                    services.AddScoped<IMovieManagerDAL, MovieDAL>();
                    services.AddScoped<IReviewManagerDALcrud, ReviewDAL>();
                    services.AddScoped<ITvSeriesManagerDAL, TvSeriesDAL>();
                    services.AddScoped<IUserManagerDAL, UserDAL>();
                    services.AddScoped<IUserProfileDAL, UserProfileDAL>();
                    services.AddScoped<IReviewDisplay, ReviewDAL>();
                    services.AddScoped<IReviewUtility, ReviewDAL>();
                    services.AddScoped<IMovieDisplay, MovieDAL>();
                    services.AddScoped<ITvSeriesDisplay, TvSeriesDAL>();
                    services.AddScoped<MinuteNewsletter>();
                    services.AddScoped<DailyNewsletter>();
                    services.AddScoped<WeeklyNewsletter>();


                    services.AddScoped<CompositeNewsletterStrategy>(provider =>
                    {
                        var userProfileManager = provider.GetRequiredService<UserProfileManager>();
                        var strategies = new List<INewsletterStrategy>
                        {
                            provider.GetRequiredService<MinuteNewsletter>(),
                            provider.GetRequiredService<DailyNewsletter>(),
                            provider.GetRequiredService<WeeklyNewsletter>()
                        };

                        return new CompositeNewsletterStrategy(strategies, userProfileManager);
                    });


                    services.AddHostedService<NewsletterBackgroundService>();


                    services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = "LoginCookieAuth";
                        options.DefaultChallengeScheme = "LoginCookieAuth";
                    })
                    .AddCookie("LoginCookieAuth", options =>
                    {
                        options.Cookie.Name = "LoginCookieAuth";
                        options.LoginPath = "/login";
                        options.AccessDeniedPath = "/Index";
                    });

                    services.AddAuthorization(options =>
                    {
                        options.AddPolicy("MustBeManager", policy =>
                            policy.RequireRole("Manager"));

                        options.AddPolicy("MustBeVisitor", policy =>
                            policy.RequireRole("Visitor"));
                    });
                })
                .Configure(app =>
                {
                    // Configure middleware, routing, etc.
                    app.UseHttpsRedirection();
                    app.UseStaticFiles();
                    app.UseRouting();
                    app.UseAuthentication();
                    app.UseAuthorization();


                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapRazorPages();
                    });
                });
            });
}
