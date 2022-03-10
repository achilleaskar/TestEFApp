using Microsoft.EntityFrameworkCore;

namespace TestEFApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		var ConStr = "Server=localhost;;Database=testbd;pooling=true;Uid=testuser;Pwd=qwerty123!@#;Convert Zero Datetime=True; default command timeout=3600;SslMode=none;TreatTinyAsBoolean=true;";
		
		builder.Services.AddTransient<MainViewModel>();

		builder.Services.AddDbContextPool<MainDbContext>(options => options
		  .EnableSensitiveDataLogging()
		  .UseMySql(ConStr, new MySqlServerVersion(new Version(8, 0, 19))));



		return builder.Build();
	}
}
