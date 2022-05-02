using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Programm
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Jouer(Personnage monPerso)
        {
            Monstre monstre = new Monstre("Chacal enragé");
            bool victoire = true;
            bool suivant = false;

            while(!monstre.EstMort())
            {
                //TOUR DU MONSTRE
                Console.ForegroundColor = ConsoleColor.Red;
                monstre.Attaquer(monPerso);
                Console.WriteLine();
                Console.ReadKey(true); //pour le système de tour par tour
                
                if(monPerso.EstMort())
                {
                    victoire = false;
                    break;
                }

                //TOUR DU PERSONNAGE
                Console.ForegroundColor = ConsoleColor.Green;
                monPerso.Attaquer(monstre);
                Console.WriteLine();
                Console.ReadKey(true);
            }

            if(victoire)
            {
                monPerso.gagnerExperience(5);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine(monPerso.Caracteristiques());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();

                while(!suivant)
                {
                    Console.WriteLine("Salle suivante ? (O/N)");
                    string saisie = Console.ReadLine().ToUpper();
                    if(saisie == "O")
                    {
                        suivant = true;
                        Jouer(monPerso);
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("C'est perdu...");
                Console.ReadKey();
            }
        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Le jeu");
            Console.WriteLine();
            Console.WriteLine("Choisis ta classe : ");
            Console.WriteLine("1. Guerrier");
            Console.WriteLine("2. Sorcier");
            Console.WriteLine("3. Archer");
            Console.WriteLine("4. Quitter");
            Console.WriteLine();

            switch(Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Vous avez choisis Guerrier !");
                    Console.WriteLine();
                    Jouer(new Guerrier("Guillaume"));
                    break;
                case "2":
                    Console.WriteLine("Vous avez choisis Sorcier !");
                    Console.WriteLine();
                    Jouer(new Sorcier("Guillaume"));
                    break;
                case "3":
                    Console.WriteLine("Vous avez choisis Archer !");
                    Console.WriteLine();
                    Jouer(new Archer("Guillaume"));
                    break;

            }
        }
    }
}
