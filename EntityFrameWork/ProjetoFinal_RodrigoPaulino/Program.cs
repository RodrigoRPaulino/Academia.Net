using Microsoft.EntityFrameworkCore;
using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//linha para configurar a string de conexao
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o=> o.UseSqlServer("Data Source=DESKTOP-ICK0HDA\\SQLEXPRESS;Initial Catalog=SistemaShopping_db;Integrated Security=True"));
// sempre que a interface for chamada a inje��o sera automatica 
builder.Services.AddScoped<IRepositorioLojas, RepositoroLojas>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
