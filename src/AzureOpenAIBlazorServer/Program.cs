using AzureOpenAIBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.SemanticKernel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddApplicationInsightsTelemetry();

var kernel = Kernel.Builder.Build();
kernel.Config.AddAzureOpenAITextCompletionService(
    "davinci-azure",                                // Alias used by the kernel
    "dsr-text-davinci-003",                         // Azure OpenAI *Deployment ID*
    "https://dsr-openaidemo-oai.openai.azure.com/", // Azure OpenAI *Endpoint*
    "...your Azure OpenAI Key..."                   // Azure OpenAI *Key*
);
builder.Services.AddSingleton(implementationInstance: kernel);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
