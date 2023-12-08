using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Meteo.Service
{
    public class Ville
    {
        // Méthode pour ajouter une nouvelle ville au fichier spécifié
        public void AjouterVille(string nouvelleVille,string cheminFichier)
        {

            try
            {
                // Lire le contenu actuel du fichier
                string contenu = File.ReadAllText(cheminFichier);
                // Convertir le contenu en une liste de villes en utilisant ',' comme séparateur
                List<string> villesListe = contenu.Split(',').ToList();
                // Ajouter la nouvelle ville à la liste
                villesListe.Add(nouvelleVille);
                // Créer une nouvelle chaîne en joignant les villes avec ',' comme séparateur
                string nouveauContenu = string.Join(",", villesListe);
                // Écrire la nouvelle chaîne dans le fichier
                File.WriteAllText(cheminFichier, nouveauContenu);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }

        }
        // Méthode pour supprimer une ville spécifiée du fichier
        public void SupprimerVille(string villeAsupprimer, string cheminFichier)
        {

            try
            {
                // Lire le contenu actuel du fichier
                string contenu = File.ReadAllText(cheminFichier);
                // Convertir le contenu en une liste de villes en utilisant ',' comme séparateur
                List<string> villesListe = contenu.Split(',').ToList();
                // Supprimer la ville spécifiée de la liste 
                villesListe.Remove(villeAsupprimer);

                string nouveauContenu = string.Join(",", villesListe);

                File.WriteAllText(cheminFichier, nouveauContenu);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }
        public void RecupererVille(string cheminFichier, ComboBox villeComboBox)
        {


            try
            {
                string contenu = File.ReadAllText(cheminFichier);

                string[] villesArray = contenu.Split(',');

                List<string> villesListe = new List<string>(villesArray);

                foreach (string ville in villesListe)
                {
                    villeComboBox.Items.Add(ville);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }
        }
    }
}
