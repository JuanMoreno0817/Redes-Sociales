using redes_Sociales.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar Razor Pages para que use "components/pages" como directorio ra�z
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/components/pages";
});
builder.Services.AddServerSideBlazor();

// Registrar el servicio GraphService
builder.Services.AddScoped<GraphService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
// Ahora, dado que la ra�z de las p�ginas es "/components/pages", 
// _Host.cshtml se encontrar� como "/_Host"
app.MapFallbackToPage("/_Host");

app.Run();