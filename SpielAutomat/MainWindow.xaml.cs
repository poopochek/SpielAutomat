using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpielAutomat
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Spielen_Click(object sender, RoutedEventArgs e)
        {
            int guthaben = 5, einsatz, gewinn;
            int z1, z2, z3;
            guthaben = Convert.ToInt32(Lbl_Guthaben1.Content);
            einsatz = Convert.ToInt32(Txt_Einsatz.Text);
            if (einsatz <= 0 || einsatz > guthaben)
            {
                MessageBox.Show("Der Einsatz muss zwischen 0 und Guthaben liegen!", "Fehler");
            }
            else
            {
                Random r = new Random();
                z1 = r.Next(1, 10);
                z2 = r.Next(1, 10);
                z3 = r.Next(1, 10);
                Lbl_Zahl1.Content = z1;
                Lbl_Zahl2.Content = z2;
                Lbl_Zahl3.Content = z3;
                guthaben -= einsatz;
                Lbl_Guthaben1.Content = guthaben;
                if (z1 == z2 || z2 == z3 || z3 == z1)
                {
                    gewinn = einsatz + 3;
                    guthaben += gewinn;
                    MessageBox.Show("kleiner Gewinn", "Gewonnen!");
                    Lbl_Guthaben1.Content = guthaben;
                }
                else if (z1 == z2 && z2 == z3)
                {
                    if (z1 == 7)
                    {
                        gewinn = einsatz * 70;
                        guthaben += gewinn;
                        MessageBox.Show("Jackpot", "Gewonnen!");
                        Lbl_Guthaben1.Content = guthaben;
                    }
                    gewinn = einsatz * 3;
                    guthaben += gewinn;
                    MessageBox.Show("Großer Gewinn", "Gewonnen!");
                    Lbl_Guthaben1.Content = guthaben;
                }
                else
                {
                    MessageBox.Show("Leider kein Gewinn", "Schade!");
                }

                    if (guthaben <= 0)
                    {
                        // Messagebox konfigurieren 
                        string MessageboxText = "Das Spiel ist Vorbei.Nochmal versuchen?";
                        string Titel = "Ende.";
                        MessageBoxButton knopf = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Question;

                        //Messagebox anzeigen
                        MessageBoxResult ergebnis = MessageBox.Show(MessageboxText, Titel, knopf, icon);

                        //Auswahl auswerten
                        switch (ergebnis)
                        {
                            case MessageBoxResult.Yes:
                                guthaben = 5;
                                Lbl_Guthaben1.Content = guthaben;
                                Lbl_Zahl1.Content = 0;
                                Lbl_Zahl2.Content = 0;
                                Lbl_Zahl3.Content = 0;
                                Txt_Einsatz.Text = "";
                                break;
                            case MessageBoxResult.No:
                                Application.Current.Shutdown();
                                break;
                        }
                    }
                }
            }
        }
    }

