namespace zadanie24_1
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ZapiszPlik(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatka.txt");

            string tresc = EntryZapis.Text;

            await File.WriteAllTextAsync(sciezka, tresc);
            await DisplayAlert("Zapisano", "Notatka została zapisana.", "OK");
        }
        private async void OdczytPlik(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "notatka.txt");

            
            if(File.Exists(sciezka))
            {
                string tresc = await File.ReadAllTextAsync(sciezka);
                LabelWyswietl.Text = tresc;
            }
            else
            {
                await DisplayAlert("info", "nie ma", "ok");
            }
        }

        
    }
}
/*
 * nazwa funkcji: ZapiszPlik
    opis funkcji: zapisuje tekst z entry do pliku, jak zapisze do wyswietla alert
    parametry: object, sender, EventArgs e
    zwracany typ i opis: -

nazwa funkcji: OdczytPlik
    opis funkcji: sprawdza ifem czy sciezka sie zgadza i jesli nie to wyswietla alert
    parametry: object, sender, EventArgs e
    zwracany typ i opis: -

    autor: kacper wandzak
 */
