namespace lopezrjo_7_UserSignUp_URINav;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}

    private async void BtnSignUp_Clicked(object sender, EventArgs e)
    {
        // Get values from the entries.
        string username = EntryUsername.Text?.Trim() ?? string.Empty;
        string email = EntryEmail.Text?.Trim() ?? string.Empty;
        string password = EntryPassword.Text ?? string.Empty;
        string confirmPassword = EntryConfirmPassword.Text ?? string.Empty;

        // VALIDATION

        // Required fields
        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            ShowError("All fields are required.");
            return;
        }

        // Password match
        if (password != confirmPassword)
        {
            ShowError("Passwords do not match.");
            return;
        }

        // Validation passed
        LblError.IsVisible = false;

        // URI Nav w/ dictionary params
        
        var navigationParameter = new Dictionary<string, object>
        {
            { "username", username },
            { "email", email }
        };

        await Shell.Current.GoToAsync(nameof(ProfilePage), navigationParameter);

        // Clear form
        ClearForm();
    }

    private void ShowError(string message)
    {
        LblError.Text = message;
        LblError.IsVisible = true;
    }

    private void ClearForm()
    {
        EntryUsername.Text = string.Empty;
        EntryEmail.Text = string.Empty;
        EntryPassword.Text = string.Empty;
        EntryConfirmPassword.Text = string.Empty;
        LblError.IsVisible = false;
    }
}