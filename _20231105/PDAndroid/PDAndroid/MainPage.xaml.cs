namespace PDAndroid
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void FileSelect_Clicked(object sender, EventArgs e)
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick File"
            });

            var imageSource = images.FullPath.ToString();
            lblFileName.Text = imageSource;
        }
    }
}