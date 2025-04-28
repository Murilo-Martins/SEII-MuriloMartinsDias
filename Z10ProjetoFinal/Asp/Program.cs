using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TcpMessageReceiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona serviços ao container de injeção de dependências
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configura o pipeline de requisições
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
            app.UseRouting();

            app.MapControllers(); // Mapeia as rotas para os Controllers

            app.Run();
        }
    }
}
