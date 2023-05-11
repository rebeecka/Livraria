using Livraria.Areas.Admin.Servicos;
using Livraria.context;
using Livraria.Models;
using Livraria.Repositories.Interfaces;
using Livraria.Repositories;
using Microsoft.EntityFrameworkCore;
using Livraria.Services;
using Livraria.Areas.admin.Services;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Identity;
using FastReport.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDb>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefautConnection")));

FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDb>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");



builder.Services.AddTransient<ILivroRepository, LivroRepository>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
builder.Services.AddScoped<RelatorioVendasService>();
builder.Services.AddScoped<GraficoVendasService>();
builder.Services.AddScoped<RelatorioLivrosService>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin",
        politica =>
        {
            politica.RequireRole("Admin");
        });
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));
builder.Services.AddControllersWithViews();

builder.Services.AddPaging(options => {
    options.ViewName = "Bootstrap5";
    options.PageParameterName = "pageindex";
});

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app =builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseFastReport();
app.UseRouting();
CriarPerfisUsuarios(app);


app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "categoriaFiltro",
        pattern: "Livro/{action}/{categoria?}",
        defaults: new { Controller = "Livro", action = "List" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();

void CriarPerfisUsuarios(WebApplication app)
{
    var scopedFactory=app.Services.GetService<IServiceScopeFactory>();
    using(var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        service.SeedUsers();
        service.SeedRoles();
    }
}