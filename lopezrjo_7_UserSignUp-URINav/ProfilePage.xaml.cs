namespace lopezrjo_7_UserSignUp_URINav;

[QueryProperty(nameof(Username), "username")]
[QueryProperty(nameof(Email), "email")]
public partial class ProfilePage : ContentPage
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ProfilePage()
	{
		InitializeComponent();
	}

    //Push values to UI when page appears after Shell query property assignment.
    protected override void OnAppearing()
    {
        base.OnAppearing();

        LblUsername.Text = Username;
        LblEmail.Text = Email;
    }

    // Sign out: Back to Prev Page - Home/Signup Page
    private async void BtnSignOut_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}