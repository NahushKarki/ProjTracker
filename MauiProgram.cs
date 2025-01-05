using Microsoft.Extensions.Logging;
using Tracker.Services;
using Tracker.Services.Debt;
using Tracker.Services.Transaction;
using Tracker.Services.Bank;

namespace Tracker
{
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

            builder.Services.AddMauiBlazorWebView();

            //registering User Services
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<ITodoService, TodoService>();
            builder.Services.AddSingleton<IDebtService, DebtService>();
            builder.Services.AddSingleton<IBankService, BankService>();
            builder.Services.AddSingleton<ITransactionService, TransactionService>();
            builder.Services.AddSingleton<AuthenticationStateService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
