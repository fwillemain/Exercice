using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CollectionsBD
{
    public class DAL
    {
        static public List<string> RécupérerTitreAlbum(int annéeDébut, int annéeFin)
        {
            XDocument doc = XDocument.Load(@"../../CollectionsBD.xml");

            var listeTitre = doc.Descendants("Album")
                                .Where(a => int.Parse(a.Attribute("Année").Value) >= annéeDébut 
                                                && int.Parse(a.Attribute("Année").Value) <= annéeFin)
                                .Attributes("Titre").Select(t => t.Value).ToList();

            return listeTitre;
        }

        static public void AjouterAuteur(string auteur, string collection)
        {
            XDocument doc = XDocument.Load(@"../../CollectionsBD.xml");

            var col = doc.Descendants("CollectionBD").Where(c => c.Attribute("Nom").Value == collection).FirstOrDefault();

            if (col != default(XElement))
            {
                if (!col.Descendants("Auteur").Where(a => a.Value == auteur).Any())
                    col.Descendants("Auteurs").First().Add(new XElement("Auteur", auteur));
            }

            doc.Save(@"../../CollectionsBD.xml");
        }

        static public void AjouterAlbum(string titre, string auteur, int année, string collection)
        {
            XDocument doc = XDocument.Load(@"../../CollectionsBD.xml");

            var col = doc.Descendants("CollectionBD").Where(c => c.Attribute("Nom").Value == collection).FirstOrDefault();

            if (col != default(XElement))
            {
                if (!col.Descendants("Auteur").Where(a => a.Value == auteur).Any())
                    col.Descendants("Auteurs").First().Add(new XElement("Auteur", auteur));

                if (!col.Descendants("Album").Where(a => a.Attribute("Titre").Value == titre).Any())
                {
                    var albums = col.Descendants("Albums").First();
                    int id = albums.Descendants("Album").Max(a => int.Parse(a.Attribute("Id").Value)) + 1;

                    albums.Add(new XElement("Album",
                                            new XAttribute("Id", id),
                                            new XAttribute("Titre", titre),
                                            new XAttribute("Année", année)));
                }
            }

            doc.Save(@"../../CollectionsBD.xml");
        }

        static public void MettreTitreMajuscule(int idAlbum, string collection)
        {
            XDocument doc = XDocument.Load(@"../../CollectionsBD.xml");

            var col = doc.Descendants("CollectionBD").Where(c => c.Attribute("Nom").Value == collection).FirstOrDefault();

            if (col != default(XElement))
            {
                var album = col.Descendants("Album").Where(a => int.Parse(a.Attribute("Id").Value) == idAlbum).FirstOrDefault();

                if (album != default(XElement))
                    album.Attribute("Titre").Value = album.Attribute("Titre").Value.ToUpper();
            }

            doc.Save(@"../../CollectionsBD.xml");
        }
    }

    public static class XContainerHandler
    {
        // Renvoi une liste d'attribut "attributeName" du premier élément "descendantName"
        // Amusant mais pas très utile
        public static IEnumerable<XAttribute> DescendantAttribute(this XContainer container, string descendantName, string attributeName)
        {
            return container.Descendants(descendantName).First().Attributes(attributeName);
        }
    }
}
