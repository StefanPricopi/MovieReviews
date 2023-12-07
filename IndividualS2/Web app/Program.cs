using DALClassLibrary.DALs;
using DALClassLibrary.Interfaces;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.Interfaces;
using Service_Layer.Interfaces_PL_to_LL;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Register Logic Layer interfaces and their implementations
builder.Services.AddScoped<ICommentManager, CommentManager>();
builder.Services.AddScoped<ILikeDislikeManager, LikeDislikeManager>();
builder.Services.AddScoped<IMediaManager, MediaManager>();
builder.Services.AddScoped<IMovieManager, MovieManager>();
builder.Services.AddScoped<ITvSeriesManager, TvSeriesManager>();
builder.Services.AddScoped<IReviewManager, ReviewManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserProfileManager, UserProfileManager>();

// Register Data Access Layer interfaces and their implementations
builder.Services.AddScoped<ICommentDAL, CommentDAL>();
builder.Services.AddScoped<ILikeDislike, LikeDislikeDAL>();
builder.Services.AddScoped<IMediaManagerDAL, MediaDAL>();
builder.Services.AddScoped<IMovieManagerDAL, MovieDAL>();
builder.Services.AddScoped<IReviewManagerDALcrud, ReviewDAL>();
builder.Services.AddScoped<ITvSeriesManagerDAL, TvSeriesDAL>();
builder.Services.AddScoped<IUserManagerDAL, UserDAL>();
builder.Services.AddScoped<IUserProfileDAL, UserProfileDAL>();
builder.Services.AddScoped<IReviewDisplay, ReviewDAL>();
builder.Services.AddScoped<IReviewUtility, ReviewDAL>();
builder.Services.AddScoped<IMovieDisplay, MovieDAL>();
builder.Services.AddScoped<ITvSeriesDisplay, TvSeriesDAL>();


// Register Manager classes
builder.Services.AddScoped<CommentManager>();
builder.Services.AddScoped<LikeDislikeManager>();
builder.Services.AddScoped<MediaManager>();
builder.Services.AddScoped<MovieManager>();
builder.Services.AddScoped<TvSeriesManager>();
builder.Services.AddScoped<ReviewManager>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<UserProfileManager>();

builder.Services.AddAuthentication(options =>
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
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeManager", policy =>
       policy.RequireRole("Manager"));

    options.AddPolicy("MustBeVisitor", policy =>
        policy.RequireRole("Visitor"));
});
builder.Services.AddScoped<ICommentDAL, CommentDAL>();
builder.Services.AddScoped<CommentManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
