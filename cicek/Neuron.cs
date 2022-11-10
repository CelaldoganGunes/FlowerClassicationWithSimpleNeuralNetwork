using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cicek
{
    
    internal class Neuron
    {
        public double[] agirliklar;

        public Neuron()
        {
            agirliklar = new double[4];

            for (int i = 0; i < agirliklar.Length; i++)
            { 
                agirliklar[i] = Program.random.NextDouble();
                Console.WriteLine(agirliklar[i]);
            }
            


        }

        public double Hesaplama(double[] girdiler)
        {
            double sonuc = girdiler[0] * agirliklar[0] + agirliklar[1] * agirliklar[1] + agirliklar[2] * agirliklar[2] + agirliklar[3] * agirliklar[3];
            //Console.WriteLine(sonuc);
            return sonuc;
        }

        public void AgirlikArttir(double ogrenmeKatsayisi, double[] agirligaBagliGirdi)
        {
            for (int i = 0; i < agirliklar.Length; i++)
            {
                agirliklar[i] = agirliklar[i] + (ogrenmeKatsayisi * agirligaBagliGirdi[i]);
            }
        }

        public void AgirlikAzalt(double ogrenmeKatsayisi, double[] agirligaBagliGirdi)
        {
            for (int i = 0; i < agirliklar.Length; i++)
            {
                agirliklar[i] = agirliklar[i] - (ogrenmeKatsayisi * agirligaBagliGirdi[i]);
            }
        }
    }
}
