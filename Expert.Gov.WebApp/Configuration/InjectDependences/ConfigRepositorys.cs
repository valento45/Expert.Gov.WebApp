using Expert.Gov.Core.Repositorys;
using Expert.Gov.Core.Repositorys.Interfaces;
using Npgsql;
using System.Data;
using System.Diagnostics;

namespace Expert.Gov.WebApp.Configuration.InjectDependences
{
    public static class ConfigRepositorys
    {

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddTransient<ISolicitacaoRepository, SolicitacaoRepository>();
        }

        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "";

            if (!Debugger.IsAttached)
            {
                //string encryptBase = configuration.GetConnectionString("Production");

                //var baseDecrypt = Security.Decrypt(encryptBase);
                //var basedados = JsonConvert.DeserializeObject<DatabaseSecurity>(baseDecrypt);

                //connectionString = $"Server={basedados.Server};Database={basedados.Database};user={basedados.User};password={basedados.Pass};SslMode=VerifyFull;";
                connectionString = configuration.GetConnectionString("Production");
            }

            else
                connectionString = configuration.GetConnectionString("Postgres");


            NpgsqlConnection con = new NpgsqlConnection(connectionString);

            services.AddSingleton<IDbConnection>(con);
        }
    }
}
