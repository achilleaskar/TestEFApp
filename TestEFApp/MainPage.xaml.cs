using Microsoft.EntityFrameworkCore;
using System.Windows.Input;

namespace TestEFApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainViewModel context)
	{
		BindingContext = context;
		InitializeComponent();
    }
  
}

