using System.Configuration;
using System.Data;
using System.Windows;
using DBEnity.Configuration;
using DBEnity.Data;
using DBEnity.Services;
using Microsoft.Extensions.DependencyInjection;
using MYDWP.ViewModel;

namespace MYDWP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();

            services.AddDbEnityContext("Data Source=Mydata.db");

            services.AddTransient<DbUserService>();
            services.AddSingleton<MainViewModel>();

            _serviceProvider = services.BuildServiceProvider();

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = _serviceProvider.GetRequiredService<MainViewModel>()
            };
            mainWindow.Show();
            base.OnStartup(e);
        }
    }

}
