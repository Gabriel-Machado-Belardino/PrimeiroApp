using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        private void btnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            count++;
            btnCliqueAqui.Text = "Você clicou " + count.ToString() + " vezes";

            switch (count)
            {
                case 1:
                case 2:
                case 19: break;
                case 20:
                case 39: btnCliqueAqui.BackgroundColor = Color.LightGreen; break;
                case 40:
                case 59: btnCliqueAqui.BackgroundColor = Color.Blue; break;
                case 60:
                case 79: btnCliqueAqui.BackgroundColor = Color.Red; break;
                case 80:
                case 99: btnCliqueAqui.BackgroundColor = Color.DarkRed; break;
                case 100: btnCliqueAqui.BackgroundColor = Color.Gold; break;
            }

        }

        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok");
        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique aqui";
                count = 0;
                btnCliqueAqui.BackgroundColor = Color.Default;
            }
        }
    }
}
