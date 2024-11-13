using ViewModel;

namespace Views;

public partial class KalkulPage : ContentPage
{
	public KalkulPage()
	{
		InitializeComponent();

		this.BindingContext = new KalkulViewModel();

    }
}