using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary.Interfaces;
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserManagerDAL, UserDAL>();
builder.Services.AddScoped<UserManager>();
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
builder.Services.AddScoped<ICommentDAL, CommentDAL>(); // Register CommentDAL as ICommentDAL
builder.Services.AddScoped<CommentManager>(); // Register CommentManager

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
