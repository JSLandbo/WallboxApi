using Microsoft.Extensions.Options;
using WallboxApi.Auth;
using WallboxApi.Models.Options;
using WallboxApi.Requests;

namespace WallboxApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services
                .AddOptions<WallboxOptions>()
                .BindConfiguration("WallboxConfig")
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services
                .AddTransient<IWallboxOptions, WallboxOptions>();

            builder.Services
                .AddTransient<IWallboxTokenManager, WallboxTokenManager>();
            
            builder.Services.AddHttpClient<IWallboxRequestManager, WallboxRequestManager>((sp, httpClient) =>
                {
                    var options = sp.GetRequiredService<IOptions<WallboxOptions>>().Value;
                    httpClient.BaseAddress = new Uri(options.WallboxUri);
                    httpClient.Timeout = TimeSpan.FromSeconds(options.Timeout);
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
                });

            var app = builder.Build();
            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}