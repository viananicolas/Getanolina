using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Getanolina.Methods
{
    public static class CalculaCombustivel
    {
        public static string VerificaCombustivel(double alcool, double gasolina)
        {
            return null;
        }

        public static string VerificaCombustivel(double alcool, double gasolina, double gnv, double quilometragem, double litragemMensal)
        {
            var consumoComb = quilometragem / litragemMensal;
            var gastocombGas = consumoComb * gasolina;
            var gastocombAlco = consumoComb * alcool;
            var consumoGNV = quilometragem / 12.5;
            var gastoGNV = (quilometragem / 12.5) * gnv;
            var economiaGas = (gastocombGas) - (gastoGNV);
            var economiaAlco = (gastocombAlco) - (gastoGNV);
            //var payback = Instalacao / economia;
            var custoGasKm = gasolina / litragemMensal;
            var custoAlcoKm = alcool / litragemMensal;
            var custoGNVKm = gnv / 12.5;
            return null;
        }
    }
}