using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ZooFerma;
using Microsoft.AspNetCore.Authentication.Cookies;
using ZooFerma.Services.Dto;
using ZooFerma.Services.Dto.Impls;
using ZooFerma.Services.Dao;
using ZooFerma.Services.Dao.Impls;

var builder = WebApplication.CreateBuilder(args);
// kestrel
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// IIS
builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

builder.Services.AddScoped<IDbService, DbServiceImpl>();
builder.Services.AddScoped<IDbServiceDAO, DbServaceDAOImpl>();
//builder.Services.AddScoped<IUserService, UserServiceImpl>();
//builder.Services.AddScoped<IClientService, ClientServiceImpl>();
//builder.Services.AddScoped<ISessionService, SessionServiceImpl>();
//builder.Services.AddScoped<IListSessionService, ListSessionServiceImpl>();
//builder.Services.AddScoped<IListCallsService, ListCallsServiceImpl>();
//builder.Services.AddScoped<ICallService, CallServiceImpl>();
//builder.Services.AddScoped<IJsonConvertService, JsonConvertServiceImpl>();
//builder.Services.AddScoped<IResoreService, RestoreServiceImpl>();
//builder.Services.AddScoped<ILkService, LkServiceImpl>();
//builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
//builder.Services.AddScoped<CryptService>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => {
        options.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddMvc();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
