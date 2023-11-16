using DALClassLibrary.DALs;
using LogicLayerClassLibrary.Classes;
using LogicLayerClassLibrary.Interfaces;
using LogicLayerClassLibrary.ManagerClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeManager",
        policy => policy.RequireClaim("Manager", "Visitor"));
});

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

app.MapRazorPages();

app.Run();
