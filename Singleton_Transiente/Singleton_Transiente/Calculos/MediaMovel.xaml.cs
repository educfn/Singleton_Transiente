﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Singleton_Transiente.Calculos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MediaMovel : ContentPage
    {
        private static bool primeiraVez = true;
        private static int[] vetor;
        private static int mediaMovel = 0;
        private static int valorDiario = 0;
        private static int ultimaPosicao = 0;

        public MediaMovel()
        {
            InitializeComponent();
        }

        private bool coletarDados()
        {
            bool error = false;

            int tamanhoDoVetor = 0;

            //Verifica se as entradas estao vazias.
            if ((primeiraVez && entryValorTamanhoVetor.Text == "") || entryValorDiaro.Text == "")
            {
                error = true;
                labelMensagemParaUsuario.Text = "Preencha os valores";
            }

            //Verifica se as entradas sao numeros
            else if (!stringSomenteNumeros(entryValorTamanhoVetor.Text) || !stringSomenteNumeros(entryValorDiaro.Text))
            {
                error = true;
                labelMensagemParaUsuario.Text = "Somente coloque numeros nas entradas";
                entryValorTamanhoVetor.Text = "";
                entryValorDiaro.Text = "";
            }


            if (error == false)
            {

                if (vetor == null)
                {
                    tamanhoDoVetor = int.Parse(entryValorTamanhoVetor.Text);
                    //Inicializando o 'vetor'.
                    //TO DO: Implementar verificacao da variavel 'tamanhoDoVetor' para verificar se o valor esta zero ou negativo.
                    vetor = new int[tamanhoDoVetor];

                }

                valorDiario = int.Parse(entryValorDiaro.Text);

            }

            return error;
        }

        private void popularVetor(int valor)
        {
            //Populando array 'vetor' com o mesmo valor.
            //TO DO: Verificar se 'valor' esta com valor zero ou negativo.
            //TO DO: Verificar se o vetor foi inicializado.
            for (int i = 0; i < vetor.Length; i++)
            {
                vetor[i] = valor;
            }
        }

        public void calcularMediaMovel()
        {
            labelMensagemParaUsuario.Text = "Calculando Media Movel";

            int somaDosValores = 0, quantidadeDeValores = vetor.Length;

            for (int i = 0; i < vetor.Length; i++)
            {
                somaDosValores += vetor[i];
            }

            mediaMovel = somaDosValores / quantidadeDeValores;

            labelMensagemParaUsuario.Text = "Media Movel:" + mediaMovel;
        }

        private void colocarNovoValorDiario(int novoValorDiario)
        {
            if (ultimaPosicao >= vetor.Length) ultimaPosicao = 0;
            else vetor[ultimaPosicao++] = novoValorDiario;
        }

        #region Metodos_auxiliadores
        private bool stringSomenteNumeros(string s)
        {
            bool ehNumero = true;

            for (int i = 0; i < s.Length; i++)
            {

                if (!char.IsNumber(s[i]))
                {
                    ehNumero = false;
                    return ehNumero;
                }
            }

            return ehNumero;
        }

        #endregion

        #region botoes
        private void botaoInicial_Clicked(object sender, EventArgs e)
        {

            labelMensagemParaUsuario.Text = "";

            if (!coletarDados())
            {
                if (primeiraVez == true)
                {
                    popularVetor(valorDiario);
                    calcularMediaMovel();
                    labelSubTituloTamanhoVetor.IsEnabled = false;
                    labelSubTituloTamanhoVetor.IsVisible = false;
                    entryValorTamanhoVetor.IsEnabled = false;
                    entryValorTamanhoVetor.IsVisible = false;
                    entryValorTamanhoVetor.Text = "";
                    entryValorDiaro.Text = "";
                    primeiraVez = false;

                }
                else
                {
                    colocarNovoValorDiario(valorDiario);
                    calcularMediaMovel();
                    entryValorDiaro.Text = "";
                }

            }

        }//Fim do metodo 'botaoInicial_Clicked'

        private void botao_reset_Clicked(object sender, EventArgs e)
        {
            primeiraVez = true;
            vetor = null;
            mediaMovel = 0;
            valorDiario = 0;
            ultimaPosicao = 0;
            labelSubTituloTamanhoVetor.Text = "Informe a quantidade de valore usados na media movel:";
            labelSubTituloTamanhoVetor.IsVisible = true;
            labelSubTituloTamanhoVetor.IsEnabled = true;
            entryValorTamanhoVetor.Text = "";
            entryValorTamanhoVetor.IsEnabled = true;
            entryValorTamanhoVetor.IsVisible = true;
            labelSubTituloValorDiario.Text = "Preencha o valor Diario:";
            entryValorDiaro.Text = "";
            labelMensagemParaUsuario.Text = "";

        }//Fim do metodo 'botao_sair_Clicked'

        private void botao_sair_Clicked(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        #endregion


    }
}