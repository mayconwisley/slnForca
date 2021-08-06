using System;
using System.Collections;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Forca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string plv;

        #region Vericando se a letra digitada esta correta
        private string verificandoLetra(string palavraNormal, string letra, string palavraCaracter)
        {

            string letraJogo = string.Empty;
            char[] posicaoLetra = palavraNormal.ToCharArray();
            int tamanhoPalavra = palavraNormal.Length;

            letraJogo += palavraCaracter;

            for (int i = 0; i < tamanhoPalavra; i++)
            {

                if (letra == posicaoLetra[i].ToString())
                {
                    letraJogo = letraJogo.Remove(i, 1);
                    letraJogo = letraJogo.Insert(i, posicaoLetra[i].ToString()).ToString();

                }
            }
            return letraJogo;
        }
        #endregion

        #region Amarzenando Letras Erradas.
        private string verificandoLetraErrada(string palavraNormal, string letra, string letraErrada, string toForca)
        {

            string letraJogoErrada = string.Empty;
            int posicaoLetra = 0;
            int contador = 0;
            int tamanhoPalavra = palavraNormal.Length;

            letraJogoErrada += letraErrada;
            foreach (char item in toForca)
            {
                posicaoLetra = toForca.IndexOf(item);
                //se letra digitada não constar na palavra

                try
                {
                    if (letra == item.ToString())
                    {
                        LblInfo.Visibility = Visibility.Visible;
                        LblInfo.Content = "Letra já digitada.";

                        //MessageBox.Show("Letra já digitada.", "Aviso");
                        return letraJogoErrada;
                    }
                    else
                    {
                        LblInfo.Visibility = Visibility.Hidden;
                        LblInfo.Content = "";
                    }
                }
                catch
                {
                }
            }

            //Verifica letra por letra digitada
            foreach (char item in palavraNormal)
            {
                posicaoLetra = palavraNormal.IndexOf(item);
                //se letra digitada não constar na palavra

                if (item.ToString() != letra)
                {
                    contador += 1;
                }
            }

            if (contador == tamanhoPalavra)
            {
                letraJogoErrada += letra;
            }
            return letraJogoErrada;
        }
        #endregion

        #region Contagem de letras erradas
        private int verificaNumErros(string letrasErradas)
        {
            int numLetrasErros = letrasErradas.Length;
            int totalErros = 7 - numLetrasErros;
            return totalErros;
        }
        #endregion

        #region Vencedor
        int vencer = 0;
        private int vencedor(string palavraNormal, string letra, string palavraCaracter, string toForca)
        {

            string letraJogo = string.Empty;
            char[] posicaoLetra = palavraNormal.ToCharArray();
            int forca = 0;
            int tamanhoPalavra = palavraNormal.Length;
            letraJogo += palavraCaracter;

            foreach (char item in toForca)
            {
                forca = toForca.IndexOf(item);
                //se letra digitada não constar na palavra

                try
                {
                    if (letra == item.ToString())
                    {
                        LblInfo.Content = "Letra já digitada.";
                        LblInfo.Visibility = Visibility.Visible;
                        //MessageBox.Show("Letra já digitada.", "Aviso");
                        return vencer;
                    }
                    else
                    {
                        LblInfo.Visibility = Visibility.Hidden;
                        LblInfo.Content = "";
                    }
                }
                catch (Exception)
                {
                }
            }
            for (int i = 0; i < tamanhoPalavra; i++)
            {
                if (letra == posicaoLetra[i].ToString())
                {
                    vencer += 1;
                }
            }
            return vencer;
        }

        #endregion

        #region Palavras e dicas Aleatórias

        private string palavras(int id)
        {
            ArrayList palavra = new ArrayList();

            palavra.Add("WINDOWS");
            palavra.Add("ANDROID");
            palavra.Add("INTERNT");
            palavra.Add("USUÁRIO");
            palavra.Add("OFFICE");
            palavra.Add("TECLADO");
            palavra.Add("MOUSE");
            palavra.Add("GOOGLE");
            palavra.Add("FORCA");
            palavra.Add("CELULAR");
            palavra.Add("FACEBOOK");
            palavra.Add("PROGRAMAR");
            palavra.Add("DEDICAÇÃO");
            palavra.Add("CONCLUIR");

            string palavraAlatoria = palavra[id].ToString();

            return palavraAlatoria;
        }

        private string dicas(int id)
        {
            ArrayList dica = new ArrayList();

            dica.Add("MICROSOFT");
            dica.Add("GOOGLE");
            dica.Add("REDE");
            dica.Add("PROGRAMADOR");
            dica.Add("TRABALHO");
            dica.Add("PERIFÉRICO");
            dica.Add("RATO");
            dica.Add("PESQUISA");
            dica.Add("JOGO");
            dica.Add("REDE MÓVEL");
            dica.Add("REDE SOCIAL");
            dica.Add("OBJETIVO");
            dica.Add("CONQUISTA");
            dica.Add("META");

            string palavraAlatoria = dica[id].ToString();

            return palavraAlatoria;
        }

        #endregion

        #region Comando e Principais do programa
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtLetra.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetrasDigitadas2.Visibility = System.Windows.Visibility.Hidden;
                txtPalavra.Visibility = System.Windows.Visibility.Hidden;
                txtDica.Visibility = System.Windows.Visibility.Hidden;
                lblChances.Visibility = System.Windows.Visibility.Hidden;
                lblPalavra.Visibility = System.Windows.Visibility.Hidden;
                lblTituloDica.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetra.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetrasDigitadas.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetrasDigitadas2.Visibility = System.Windows.Visibility.Hidden;
                lblTituloPalavra.Visibility = System.Windows.Visibility.Hidden;
                btnReinicia.Visibility = System.Windows.Visibility.Hidden;
                LblInfo.Visibility = Visibility.Hidden;
                btnInicioJogo.IsEnabled = false;
                btnReinicia.IsEnabled = false;
                btnVerificar.IsEnabled = false;
                btnVerificar.Visibility = System.Windows.Visibility.Hidden;
                lblPalavra.Content = "";
                lblTituloLetrasDigitadas.Content = "";

                SoundPlayer seiLa = new SoundPlayer("Audio/hos6.wav");
                seiLa.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxListaDoJogo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SoundPlayer emPosicao = new SoundPlayer("Audio/emPosicao.wav");
                int idItens = cbxListaDoJogo.SelectedIndex;
                plv = txtPalavra.Text;

                if (idItens == 0)
                {
                    txtPalavra.Visibility = System.Windows.Visibility.Visible;
                    txtPalavra.Text = "";
                    txtDica.Text = "";
                    txtDica.Visibility = System.Windows.Visibility.Visible;
                    txtDica.IsReadOnly = false;
                    lblPalavra.Visibility = System.Windows.Visibility.Visible;
                    lblTituloDica.Visibility = System.Windows.Visibility.Visible;
                    lblTituloPalavra.Visibility = System.Windows.Visibility.Visible;
                    btnInicioJogo.IsEnabled = true;
                    txtPalavra.Focus();
                }
                else if (idItens == 1)
                {
                    txtPalavra.Visibility = System.Windows.Visibility.Hidden;
                    txtDica.Visibility = System.Windows.Visibility.Visible;
                    lblTituloLetra.Visibility = System.Windows.Visibility.Visible;
                    lblTituloDica.Visibility = System.Windows.Visibility.Visible;
                    lblPalavra.Visibility = System.Windows.Visibility.Visible;
                    lblTituloLetra.Visibility = System.Windows.Visibility.Hidden;
                    lblTituloPalavra.Visibility = System.Windows.Visibility.Hidden;
                    btnInicioJogo.IsEnabled = true;

                    Random rdn = new Random();

                    int index = rdn.Next(13);
                    plv = palavras(index);
                    txtDica.Text = dicas(index);
                }
                emPosicao.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInicioJogo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPalavra.Text == string.Empty)
                {
                }
                else
                {
                    plv = txtPalavra.Text;
                }

                if (plv == string.Empty)
                {

                    txtPalavra.Visibility = System.Windows.Visibility.Visible;
                    lblTituloPalavra.Visibility = System.Windows.Visibility.Visible;
                    txtDica.IsReadOnly = false;
                    btnInicioJogo.IsEnabled = true;
                    MessageBox.Show("Por favor Digitar uma palavra valida", "Aviso", MessageBoxButton.OK);
                }
                else
                {
                    lblChances.Visibility = System.Windows.Visibility.Visible;
                    lblTituloLetrasDigitadas2.Visibility = System.Windows.Visibility.Visible;
                    lblTituloLetrasDigitadas.Visibility = System.Windows.Visibility.Visible;
                    lblTituloLetra.Visibility = System.Windows.Visibility.Visible;
                    txtLetra.Visibility = System.Windows.Visibility.Visible;
                    lblTituloDica.Visibility = System.Windows.Visibility.Visible;
                    txtPalavra.Visibility = System.Windows.Visibility.Hidden;
                    lblTituloPalavra.Visibility = System.Windows.Visibility.Hidden;
                    txtPalavra.Visibility = System.Windows.Visibility.Hidden;
                    lblTituloPalavra.Visibility = System.Windows.Visibility.Hidden;
                    btnReinicia.Visibility = System.Windows.Visibility.Hidden;
                    txtDica.IsReadOnly = true;
                    txtLetra.IsReadOnly = false;
                    btnInicioJogo.IsEnabled = false;
                    btnReinicia.IsEnabled = true;
                    btnVerificar.IsEnabled = true;
                    btnVerificar.Visibility = System.Windows.Visibility.Visible;
                    cbxListaDoJogo.IsEnabled = false;

                    int tamanhoPalavra = plv.Length;
                    lblPalavra.Content = "";

                    for (int i = 0; i < tamanhoPalavra; i++)
                    {
                        lblPalavra.Content += "-";
                    }
                }
                txtLetra.Focus();
                SoundPlayer inicioJogo = new SoundPlayer("Audio/inicioJogo.wav");
                inicioJogo.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReinicia_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SoundPlayer reiniciaJogo = new SoundPlayer("Audio/jogarDeNovo.wav");

                txtLetra.Visibility = System.Windows.Visibility.Hidden;
                txtPalavra.Visibility = System.Windows.Visibility.Hidden;
                txtDica.Visibility = System.Windows.Visibility.Hidden;
                lblChances.Visibility = System.Windows.Visibility.Hidden;
                lblPalavra.Visibility = System.Windows.Visibility.Hidden;
                lblTituloDica.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetra.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetrasDigitadas.Visibility = System.Windows.Visibility.Hidden;
                lblTituloLetrasDigitadas2.Visibility = System.Windows.Visibility.Hidden;
                lblTituloPalavra.Visibility = System.Windows.Visibility.Hidden;
                LblInfo.Visibility = Visibility.Hidden;
                btnReinicia.Visibility = System.Windows.Visibility.Hidden;
                btnInicioJogo.IsEnabled = false;
                btnReinicia.IsEnabled = false;
                cbxListaDoJogo.IsEnabled = true;
                cbxListaDoJogo.Text = "";
                txtDica.Text = "";
                txtPalavra.Text = "";
                lblPalavra.Content = "";
                txtLetra.Text = "";
                lblTituloLetrasDigitadas.Content = "";
                btnVerificar.IsEnabled = false;
                btnVerificar.Visibility = System.Windows.Visibility.Hidden;
                ImageSource imagem1 = new BitmapImage(new Uri("Boneco/imagem1.png", UriKind.RelativeOrAbsolute));
                vencer = 0;
                imgJogo.Source = imagem1;
                reiniciaJogo.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int pontosVoce = 0;
        int pontosPC = 0;

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer perdeuJogo = new SoundPlayer("Audio/seFudeu.wav");
                SoundPlayer erro1 = new SoundPlayer("Audio/letraErrada.wav");
                SoundPlayer erro2 = new SoundPlayer("Audio/caiNoMato.wav");
                SoundPlayer certo = new SoundPlayer("Audio/letraCerta.wav");
                SoundPlayer venceu = new SoundPlayer("Audio/vencedor.wav");
                string palavraSecreta = plv;
                int palavra2 = vencedor(palavraSecreta, txtLetra.Text, lblPalavra.Content.ToString(), lblPalavra.Content.ToString());
                lblTituloLetrasDigitadas.Content = verificandoLetraErrada(plv, txtLetra.Text, lblTituloLetrasDigitadas.Content.ToString(), lblTituloLetrasDigitadas.Content.ToString());
                lblPalavra.Content = verificandoLetra(plv, txtLetra.Text, lblPalavra.Content.ToString());
                string letrasDigitadas = lblTituloLetrasDigitadas.Content.ToString();

                int totalDeLetrasErradas = letrasDigitadas.Length;

                int palavra = palavraSecreta.Length;

                if (palavra2 == palavra)
                {
                    venceu.Play();
                    ImageSource ganhador = new BitmapImage(new Uri("vencedor.png", UriKind.RelativeOrAbsolute));
                    imgJogo.Source = ganhador;
                    btnReinicia.Visibility = System.Windows.Visibility.Visible;
                    btnVerificar.IsEnabled = false;
                    txtLetra.IsReadOnly = true;
                    pontosVoce += 1;
                    lblPontuacao.Content = "Pontuação: Você " + pontosVoce + " x " + pontosPC + " Computador";
                }
                else
                {
                    foreach (char item in letrasDigitadas)
                    {

                        if (item.ToString() == txtLetra.Text)
                        {
                            switch (totalDeLetrasErradas)
                            {
                                case 1:
                                    ImageSource imagem2 = new BitmapImage(new Uri("Boneco/imagem2.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem2;
                                    erro1.Play();
                                    break;
                                case 2:
                                    ImageSource imagem3 = new BitmapImage(new Uri("Boneco/imagem3.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem3;
                                    erro1.Play();
                                    break;
                                case 3:
                                    ImageSource imagem4 = new BitmapImage(new Uri("Boneco/imagem4.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem4;
                                    erro1.Play();
                                    break;
                                case 4:
                                    ImageSource imagem5 = new BitmapImage(new Uri("Boneco/imagem5.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem5;
                                    erro1.Play();
                                    break;
                                case 5:
                                    ImageSource imagem6 = new BitmapImage(new Uri("Boneco/imagem6.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem6;
                                    erro1.Play();
                                    break;
                                case 6:
                                    ImageSource imagem7 = new BitmapImage(new Uri("Boneco/imagem7.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem7;
                                    erro2.Play();
                                    break;
                                case 7:
                                    ImageSource imagem8 = new BitmapImage(new Uri("Boneco/imagem8.png", UriKind.RelativeOrAbsolute));
                                    imgJogo.Source = imagem8;
                                    erro1.Play();
                                    pontosPC += 1;
                                    lblPontuacao.Content = "Pontuação: Você " + pontosVoce + " x " + pontosPC + " Computador";
                                    perdeuJogo.Play();
                                    break;
                            }
                        }
                    }
                    foreach (char item in lblPalavra.Content.ToString())
                    {
                        if (item.ToString() == txtLetra.Text)
                        {
                            certo.Play();
                        }
                    }
                }

                int errosPermitidos = verificaNumErros(lblTituloLetrasDigitadas.Content.ToString());

                if (errosPermitidos <= 0)
                {
                    lblChances.Content = "Você Perdeu!!!";
                    btnReinicia.Visibility = System.Windows.Visibility.Visible;
                    txtLetra.IsReadOnly = true;
                    lblPalavra.Content = plv;
                    btnVerificar.IsEnabled = false;
                }
                else
                {
                    lblChances.Content = "Você tem " + errosPermitidos + " tentativas...";
                }
                txtLetra.Text = "";
                txtLetra.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLetra_KeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Enter == e.Key && txtLetra.IsReadOnly != true)
            {
                btnVerificar_Click(e, e);
                txtLetra.Text = "";
                txtLetra.Focus();
            }
        }

        private void txtDica_KeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Enter == e.Key && txtDica.IsReadOnly != true)
            {
                btnInicioJogo_Click(e, e);
            }
        }
        #endregion
    }
}
