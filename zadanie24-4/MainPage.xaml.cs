namespace zadanie24_4
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void EksportClicked(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatki_eksport.txt");
            string tresc = DateTime.Now.ToString("yyyy-MM-dd HH-mm") + "\n" + EditorNotatka.Text + "\n";

            await File.WriteAllTextAsync(sciezka, tresc);
            Obsluga.Text = Obsluga.Text + "\n" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + " Eksport";
        }

        private async void ImportClicked(object? sender, EventArgs e)
        {
                    var opcjeTekst = new PickOptions

                    {

                        PickerTitle = "Wybierz plik tekstowy",

                        FileTypes = new FilePickerFileType(

        new Dictionary<DevicePlatform, IEnumerable<string>>

        {

           { DevicePlatform.Android, new[] { "text/plain" } },

           { DevicePlatform.iOS, new[] { "public.plain–text" } },

           { DevicePlatform.WinUI, new[] { ".txt" } },

        })

                    };
                    try
                    {
                        var wynik = await FilePicker.Default.PickAsync(opcjeTekst);
                        if (wynik != null)
                        {
                            string nazwaPliku = wynik.FileName;
                            string pelnaSciezka = wynik.FullPath;
                            await DisplayAlert("Wybrano plik", $"Nazwa: {nazwaPliku}", "OK");
                            string tresc = await File.ReadAllTextAsync(pelnaSciezka);
                            EditorNotatka.Text = tresc;
                            Obsluga.Text = Obsluga.Text + "\n" + DateTime.Now.ToString("yyyy-MM-dd HH-mm") + " Import";
                        }
                    }

                    catch (Exception ex)
                    {

                        await DisplayAlert("B³¹d", $"Nie uda³o siê wybraæ pliku: {ex.Message}", "OK");

                    }
                }
            }
        }
    

