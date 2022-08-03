using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
                lblDataNascimento.Text = string.Empty;
                lblDiasVividos.Text = string.Empty;
            }
        }

        private async void btnInformarDataNascimento_Clicked(object sender, EventArgs e)
        {
            try
            {
                string DataDigitada = await DisplayPromptAsync("Info", "Digite a Data de Nascimento", "Ok", null, "dd/MM/yyyy");

                DateTime DataConvertida;

                bool converteu = DateTime.TryParse(DataDigitada, new CultureInfo("pt-BR"), DateTimeStyles.None, out DataConvertida);

                //if(!converteu)
                if (converteu == false)
                    throw new Exception("Esta data não é valida");
                else
                {
                    lblDataNascimento.Text = string.Format("{0:dd/MM/yyyy}", DataConvertida);
                    int DiasVividos = (int) DateTime.Now.Subtract(DataConvertida).TotalDays;
                    await DisplayAlert("Info", "Você ja viveu " + DiasVividos + " dias", "Ok");
                    lblDiasVividos.Text = "Dias vividos: " + DiasVividos;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }

            //=========BREAK PO0INTS=============
            //f10 - passa de uma linha para o outra
            //f5 - passa de um breakpoint para outro
        }

        private async void btnOpcoes_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblDataNascimento.Text))
                    throw new Exception("Informe a data de nascimento");

                else
                {
                    DateTime dtNascimento = Convert.ToDateTime(lblDataNascimento.Text, new CultureInfo("pt-BR"));
                    string resposta = await 
                        DisplayActionSheet("Opções", 
                        "Cancelar", 
                        "Ok", 
                        "Saber o dia da semana", 
                        "Saber o dia do mês",
                        "Saber o dia do ano");

                    string msg = $"Você nasceu no(a)";

                    switch (resposta)
                    {
                        case "Saber o dia da semana":
                            string dayWeek = string.Empty;

                            switch(dtNascimento.DayOfWeek)
                            {
                                case DayOfWeek.Sunday: dayWeek = "Domingo"; break;
                                case DayOfWeek.Monday: dayWeek = "Segunda-Feira";  break;
                                case DayOfWeek.Tuesday: dayWeek = "Terça-Feira"; break;
                                case DayOfWeek.Wednesday: dayWeek = "Quarta-Feira"; break;
                                case DayOfWeek.Thursday: dayWeek = "Quinta-Feira"; break;
                                case DayOfWeek.Friday: dayWeek = "Sexta-Feira"; break;
                                case DayOfWeek.Saturday: dayWeek = "Sabado"; break;
                            }

                            msg += $" {dayWeek}";
                            await DisplayAlert("Info", msg, "Ok");
                            break;

                        case "Saber o dia do mês":
                            msg += $" {dtNascimento.Day}° dia do mês";
                            await DisplayAlert("Info", msg, "Ok");
                            break;

                        case "Saber o dia do ano":
                            msg += $" {dtNascimento.DayOfYear}° dia do ano";
                            await DisplayAlert("Info", msg, "Ok");
                            break;

                    }


                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("Info", ex.Message + ex.InnerException, "Ok");
            }
        }
    }
}
