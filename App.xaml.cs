namespace FlyoutNavigationTest;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		FlyoutPage flyout = null;
        var toAnotherPageCommand = new Command(() => flyout.Detail.Navigation.PushAsync(new ContentPage
        {
            Title = "Another page"
        }));
        var changePageCommand = new Command(() => flyout.Detail = new NavigationPage(new ContentPage
		{
			Title = "That page",
            Content = new StackLayout
            {
                Children = {
                        new Label { Text = "That page" },
                        new Button { Text = "To another page", Command = toAnotherPageCommand }
                    }
            }
        }));
		MainPage = flyout = new FlyoutPage
		{
			Flyout = new ContentPage()
			{
				Title = "Menu",
				Content = new StackLayout
				{
					Children = {
						new Button
						{
							Text = "Change Page",
							Command = changePageCommand
						}
					}
				}
			},
			Detail = new NavigationPage(new ContentPage()
			{
				Title = "This Page",
				Content = new Label { Text = "This page" }
            })
		};
	}
}

