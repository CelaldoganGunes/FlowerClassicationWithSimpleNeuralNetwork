using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cicek
{
    internal class NeuralNetwork
    {
        public Neuron[] noronlar;
        public NeuralNetwork(int neuronAmount)
        {
            noronlar = new Neuron[neuronAmount];
            for (int i = 0; i < neuronAmount; i++)
            {
                Neuron neuron = new Neuron();
                noronlar[i] = neuron;
            }
        }

        public void EgitimYap(double ogrenmeKatsayisi)
        {
            for (int j = 0; j < Program.girdiler.GetLength(0); j++)
            {
                //Console.WriteLine(j);
                double[] doubles = new double[4] { Program.girdiler[j, 0], Program.girdiler[j, 1], Program.girdiler[j, 2], Program.girdiler[j, 3] };
                double n1 = noronlar[0].Hesaplama(doubles);
                double n2 = noronlar[1].Hesaplama(doubles);
                double n3 = noronlar[2].Hesaplama(doubles);

                double biggestNumber = Math.Max(Math.Max(n1, n2), n3);
                Neuron enBuyukCiktiyiVerenNoron;

                if (biggestNumber == n1)
                {
                    enBuyukCiktiyiVerenNoron = noronlar[0];
                }
                else if (biggestNumber == n2)
                {
                    enBuyukCiktiyiVerenNoron = noronlar[1];
                }
                else
                {
                    enBuyukCiktiyiVerenNoron = noronlar[2];
                }

                if (Program.cicekler[j] == "Iris-setosa")
                {
                    if (biggestNumber != n1)
                    {
                        enBuyukCiktiyiVerenNoron.AgirlikAzalt(ogrenmeKatsayisi, doubles);
                        noronlar[0].AgirlikArttir(ogrenmeKatsayisi, doubles);
                    }

                }
                else if (Program.cicekler[j] == "Iris-versicolor")
                {
                    if (biggestNumber != n2)
                    {
                        enBuyukCiktiyiVerenNoron.AgirlikAzalt(ogrenmeKatsayisi, doubles);
                        noronlar[1].AgirlikArttir(ogrenmeKatsayisi, doubles);
                    }
                }
                else if (Program.cicekler[j] == "Iris-virginica")
                {
                    if (biggestNumber != n3)
                    {
                        enBuyukCiktiyiVerenNoron.AgirlikAzalt(ogrenmeKatsayisi, doubles);
                        noronlar[2].AgirlikArttir(ogrenmeKatsayisi, doubles);
                    }
                }
            }
        }

        public void DogrulukHesapla()
        {
            double dogruBilinenSayi = 0;
            for (int j = 0; j < Program.girdiler.GetLength(0); j++)
            {
                double[] doubles = new double[4] { Program.girdiler[j, 0], Program.girdiler[j, 1], Program.girdiler[j, 2], Program.girdiler[j, 3] };
                double n1 = noronlar[0].Hesaplama(doubles);
                double n2 = noronlar[1].Hesaplama(doubles);
                double n3 = noronlar[2].Hesaplama(doubles);

                double biggestNumber = Math.Max(Math.Max(n1, n2), n3);

                //Console.WriteLine(" ");
               // Console.WriteLine(Program.cicekler[j]);

                if (Program.cicekler[j] == "Iris-setosa")
                {
                    if (biggestNumber == n1)
                    {
                        Console.WriteLine("Setosa doğru bildi.");
                        dogruBilinenSayi += 1;
                    }

                }
                else if (Program.cicekler[j] == "Iris-versicolor")
                {
                    if (biggestNumber == n2)
                    {
                        Console.WriteLine("Versicolor doğru bildi.");
                        dogruBilinenSayi += 1;
                    }
                }
                else if (Program.cicekler[j] == "Iris-virginica")
                {
                    if (biggestNumber == n3)
                    {
                        Console.WriteLine("Virginica doğru bildi.");
                        dogruBilinenSayi += 1;
                    }
                }
            }

            Console.WriteLine("Doğruluk Değeri: " + (dogruBilinenSayi * 100 /150));
        }

        public void EpokDongusu(int counter, double katsayi)
        {
            for(int i = 0; i < counter; i++)
            {
                this.EgitimYap(katsayi);
            }
            //this.DogrulukHesapla();
        }
    }
}
