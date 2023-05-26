using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Vilma.Blazor.Components;
using Vilma.Blazor.Components.FileUploader.LocalStorage.Client;
using Vilma.Blazor.Components.FileUploader.LocalStorage.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddVilmaBlazorServices();
builder.Services.AddVilmaBlazorFileUploaderClient();
builder.Services.AddVilmaBlazorFileUploadControllers();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseVilmaBlazorFileUploader();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
