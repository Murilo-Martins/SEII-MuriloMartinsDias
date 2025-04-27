namespace MAUIMediaCapture
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }
        private async void CapturePhotoBtn_Clicked(object sender, EventArgs e)
        {
            if(MediaPicker.Default.IsCaptureSupported)
            {
                var options = new MediaPickerOptions
                {
                    Title = "Capture a Photo"
                };
                FileResult? fileResult = await MediaPicker.Default.CaptureVideoAsync(options);
                if (fileResult is null)
                {
                    //Maluco nao quis
                    await DisplayAlert("Alert", "Permissão negada", "OK");
                    return;

                }
                var photoStream = await fileResult.OpenReadAsync();


                //Use this photoStream to precess
                //1. mostrar no app
                //2. salvar no bdd
                //3. manda por APi***
                //4. Trabalhar na imagem
                //Img.Source = ImageSource.FromStream(()=>photoStream);
                var tempVideoPath = Path.Combine(FileSystem.CacheDirectory, fileResult.FileName);
                var html = $@"
                <html>
                    <body style='margin:0;padding:0;'>
                        <video width='100%' height='100%' controls>
                            <source src='file://{tempVideoPath}' type='video/mp4'>
                        </video>
                    </body>
                </html>";

                videoWebView.Source = new HtmlWebViewSource { Html = html };

                //Save this image
                //var path = Path.Combine(FileSystem.CacheDirectory, fileResult.FileName);
                //var fs = File.Create(path);
                //await photoStream.CopyToAsync(fs);


            }

            else
            {
                //Mensagem de alerta
            }
        }
        private void ShowPhotoStreamOnUI(Stream photoStream)
        {
            //Img.Source = ImageSource.FromStream(() => photoStream);
        }
        private async Task SavePhotoToDeviceAsync(Stream photoStream)
        {

        }
        private void SehdPhotoStreamToAPI(Stream photoStream)
        {
            
            //HTTPCLient
            var ms = new MemoryStream();
            photoStream.CopyTo(ms);

            var byteArray = ms.ToArray();
        }
        private void SavePhotoStreamToLocal(Stream phoStream)
        { 
        }

    }

}
