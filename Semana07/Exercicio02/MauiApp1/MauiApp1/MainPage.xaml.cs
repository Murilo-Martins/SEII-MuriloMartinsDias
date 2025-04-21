namespace MauiApp1
{
    public partial class MainPage : TabbedPage
    {
        string nomeUser;
        

        public MainPage()
        {
            InitializeComponent();

            string endereco = @"<iframe width=""560"" height=""315"" src=""https://www.youtube.com/embed/3uDm5SPVsQM?si=5LwRpjBpSlx3OWBX"" title=""YouTube video player"" frameborder=""0"" allow=""accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"" referrerpolicy=""strict-origin-when-cross-origin"" allowfullscreen></iframe>";
            WVVideo.Source = new HtmlWebViewSource
            {
                Html = endereco
            };
        }

        private async void BTNOla_Clicked(object sender, EventArgs e)
        {
            nomeUser = await DisplayPromptAsync("Nome", "Digite seu nome: ", "Ok");
            await DisplayAlert("Aviso", "O aviso: Olá mundo!", "Fechar");
            await DisplayAlert("Nome", $"O aviso: {nomeUser}", "Fechar");
        }
    }

}
