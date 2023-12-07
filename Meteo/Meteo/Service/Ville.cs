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
        public void AjouterVille(string nouvelleVille,string cheminFichier)
        {

            try
            {
                string contenu = File.ReadAllText(cheminFichier);

                List<string> villesListe = contenu.Split(',').ToList();

                villesListe.Add(nouvelleVille);

                string nouveauContenu = string.Join(",", villesListe);

                File.WriteAllText(cheminFichier, nouveauContenu);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
            }

        }

        public void SupprimerVille(string villeAsupprimer, string cheminFichier)
        {

            try
            {
                string contenu = File.ReadAllText(cheminFichier);
                List<string> villesListe = contenu.Split(',').ToList();

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
