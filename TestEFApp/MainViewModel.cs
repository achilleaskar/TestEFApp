using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace TestEFApp
{
    public class MainViewModel
    {
        public MainViewModel(MainDbContext context)
        {
            Context = context;
            TestCommand = new Command(async () => await Test());
        }

        private async Task Test()
        {

            try
            {
                var x = await Context.Customers.ToListAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.ToString(), "Okay");
                if (ex.InnerException != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", ex.InnerException.Message, "Okay");
                }
            }
        }

        public ICommand TestCommand { get; set; }
        public MainDbContext Context { get; }
    }
}