using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule3.BO;

namespace TPModule3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Afficher la liste des prénoms des auteurs dont le nom commence par "G"

            //Data.Instance.ListeAuteurs.Where(a => a.Nom.Substring(0, 1).Equals("G"));
            //List<Auteur> auteursQ1 = Data.Instance.ListeAuteurs
            //    .Where(a => a.Nom.StartsWith("G")).ToList();
            List<String> prenomAuteurQ1 = Data.Instance.ListeAuteurs
                .Where(a => a.Nom.Substring(0, 1).Equals("G"))
                .Select(a => a.Prenom).ToList();

            Console.WriteLine("Q1 :");

            foreach (var prenomAuteur in prenomAuteurQ1)
            {
                Console.WriteLine(prenomAuteur);
            }

            Console.ReadKey();
            Console.WriteLine();

            //Afficher l’auteur ayant écrit le plus de livres
            IGrouping<Auteur,Livre> auteurQ2 = Data.Instance.ListeLivres
                .GroupBy(l => l.Auteur)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            Console.WriteLine("Q2 :");
            Console.WriteLine($"{auteurQ2.Key.Nom} {auteurQ2.Key.Prenom}");

            Console.ReadKey();
            Console.WriteLine();

            //Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine("Q3 :");
            foreach (var groupingAuteurLivre in Data.Instance.ListeLivres.GroupBy(l => l.Auteur))
            {
                Console.WriteLine($"{groupingAuteurLivre.Key.Nom} {groupingAuteurLivre.Key.Prenom}");
                Console.WriteLine($"Moyenne des pages = {groupingAuteurLivre.Average(l => l.NbPages)}");
            }

            Console.ReadKey();
            Console.WriteLine();

            //Afficher le titre du livre avec le plus de pages
            //Data.Instance.ListeLivres.Max(x => x.NbPages)
            Livre livreQ4 = Data.Instance.ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine("Q4 :");
            Console.WriteLine($"Livre avec le maximum de page : {livreQ4.Titre}");

            Console.ReadKey();
            Console.WriteLine();

            //Afficher combien ont gagné les auteurs en moyenne (moyenne des factures)
            decimal moyenneQ5 = Data.Instance.ListeAuteurs
                .Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine("Q5 :");
            Console.WriteLine($"Moyenne des sommes gagnés par les auteurs : {moyenneQ5}");

            Console.ReadKey();
            Console.WriteLine();

            //Afficher les auteurs et la liste de leurs livres
            //foreach (var item in Data.Instance.ListeAuteurs)
            //{
            //    foreach (var livre in Data.Instance.ListeLivres)
            //    {
            //        if (livre.Auteur.Equals(item))
            //        {

            //        }
            //    }
            //}

            Console.WriteLine("Q6 :");
            var groupingAuteurLivreQ6s = Data.Instance.ListeLivres.GroupBy(l => l.Auteur);
            foreach (var auteurAvecLivres in groupingAuteurLivreQ6s)
            {
                Console.WriteLine($"{auteurAvecLivres.Key.Nom} {auteurAvecLivres.Key.Prenom}");
                foreach (var livre in auteurAvecLivres)
                {
                    Console.WriteLine($"Livre : {livre.Titre}");
                }
            }

            Console.ReadKey();
            Console.WriteLine();

            // Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine("Q7 :");
            List<String> titreQ7s = Data.Instance.ListeLivres.Select(l => l.Titre).OrderBy(t => t).ToList();
            foreach (var item in titreQ7s)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            titreQ7s.ForEach((s) =>
            {
                Console.WriteLine(s);
            });

            Console.WriteLine();
            titreQ7s.ForEach(Console.WriteLine);

            Console.ReadKey();
            Console.WriteLine();

            // Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            double nbPageMoyenneQ8 = Data.Instance.ListeLivres.Average(l => l.NbPages);
            //List<Livre> livresQ8 = Data.Instance.ListeLivres.Where(l => l.NbPages > nbPageMoyenneQ8).ToList();

            Console.WriteLine("Q8 :");
            Data.Instance.ListeLivres.Where(l => l.NbPages > nbPageMoyenneQ8)
                .ToList().ForEach((l) =>
            {
                Console.WriteLine(l.Titre);
            });

            Console.ReadKey();
            Console.WriteLine();

            // Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("Q9 :");
            Auteur auteurQ9 = Data.Instance.ListeAuteurs
                .OrderBy(a => Data.Instance.ListeLivres.Count(l => l.Auteur == a))
                .FirstOrDefault();
            Console.WriteLine($"{auteurQ9.Nom} {auteurQ9.Prenom}");

            Console.ReadKey();
        }
    }
}
