/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        static float polonaise(String formule)
        {
            try
            {
                string[] t = formule.Split(' ');
                int nbCases = t.Length;
                while (nbCases > 1)
                {
                    // recherche d'un opérateur
                    int k = t.Length - 1;
                    while (t[k] != "+" && t[k] != "-" && t[k] != "/" && t[k] != "*" && k > 0)
                    {
                        k--;
                    }
                    // calcul du résultat
                    float result = 0;
                    float a = float.Parse(t[k + 1]);
                    float b = float.Parse(t[k + 2]);
                    switch (t[k])
                    {
                        case "+":
                            result = a + b;
                            break;
                        case "-":
                            result = a - b;
                            break;
                        case "/":
                            if (b == 0)
                            {
                                return float.NaN;
                            }
                            result = a / b;
                            break;
                        case "*":
                            result = a *b;
                            break;
                    }
                    // stockage du résultat à la place de l'opérateur
                    t[k] = result.ToString();

                    // suppression des 2 cases suivantes
                    for (int i = k + 1; i < nbCases - 2; i++)
                    {
                        t[i] = t[i + 2];
                    }
                    // case suivantes mises à blanc
                    for (int i = nbCases - 2; i < nbCases; i++)
                    {
                        t[i] = "";
                    }
                    nbCases -= 2;
                }
                return float.Parse(t[0]);
            }
            catch
            {
                Console.WriteLine("Erreur de saisie");
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                String laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
