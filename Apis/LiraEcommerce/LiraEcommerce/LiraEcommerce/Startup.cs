using LiraBelle.Interfaces;
using LiraBelle.Repositorios;
using LiraBelle.RepositoriosViewModel;
using LiraCore.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiraEcommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Injeção de dependencia
            services.AddScoped(typeof(IProduto), typeof(LiraData.FlatFile.CRUD.ProdutoCRUD));
            services.AddScoped(typeof(ICategoriaServico), typeof(LiraData.FlatFile.CRUD.CategoriaServicoCRUD));
            services.AddScoped(typeof(ISubCategoriaServico), typeof(LiraData.FlatFile.CRUD.SubCategoriaServicoCRUD));
            services.AddScoped(typeof(IEstabelecimento), typeof(LiraData.FlatFile.CRUD.EstabelecimentoCRUD));
            services.AddScoped(typeof(IUsuario), typeof(LiraData.FlatFile.CRUD.UsuarioCRUD));

            services.AddScoped<ICategoriaServicoRepositorioViewModel>(X => ActivatorUtilities.CreateInstance<CategoriaServicoRepositorioViewModel>(X, X.GetService<ICategoriaServico>(), X.GetService<ISubCategoriaServico>()));
            services.AddScoped<ISubCategoriaServicoRepositorioModel>(X => ActivatorUtilities.CreateInstance<SubCategoriaServicoRepositorioViewModel>(X, X.GetService<ISubCategoriaServico>(), X.GetService<ICategoriaServico>()));
            services.AddScoped<IEstabelecimentoRepositorioViewModel>(X => ActivatorUtilities.CreateInstance<EstabelecimentoRepositorioViewModel>(X, X.GetService<IEstabelecimento>(), X.GetService<IUsuario>()));
            services.AddScoped<IUsuarioRepositorioViewModel>(X => ActivatorUtilities.CreateInstance<UsuarioRepositorioViewModel>(X, X.GetService<IUsuario>(), X.GetService<IEstabelecimento>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
