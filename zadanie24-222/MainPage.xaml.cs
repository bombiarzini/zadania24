namespace zadanie24_222
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
            if (File.Exists(sciezka))
            {
                string tresc = File.ReadAllText(sciezka);
                Dziennik.Text = tresc;
            }
        }


        private async void DodawanieWpisu(object? sender, EventArgs e)
        {
            string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");

            string nowyWpis = $"\n[{DateTime.Now:dd.MM.yyyy HH:mm}] Nowy wpis w dzienniku: "+ EditorWpis.Text;
            Dziennik.Text = Dziennik.Text + "\n" + nowyWpis;

            await File.WriteAllTextAsync(sciezka, nowyWpis);
        }



        private async void WyczyscDziennik(object? sender, EventArgs e)
        {
            string potwierdz = await DisplayActionSheet("Wykonac?", "Tak", "Nie");

            if (potwierdz == "Tak")
                {

                    string sciezka = Path.Combine(FileSystem.Current.AppDataDirectory, "dziennik.txt");
                    if (File.Exists(sciezka))
                    {
                        File.Delete(sciezka);
                    }
                    Dziennik.Text = string.Empty;
                }
            }
    }
}
