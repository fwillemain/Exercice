using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Trombinoscope
{
    static public class DAL
    {
        #region Méthodes privées
        private static ImageSource ConvertBytesToImageSource(Byte[] tab)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Les images stockées dans la base Northwind ont un en-tête de 78 octets 
                // qu'il faut enlever pour pouvoir les charger correctement
                ms.Write(tab, 78, tab.Length - 78);
                ImageSource image = BitmapFrame.Create(ms, BitmapCreateOptions.None,
                                      BitmapCacheOption.OnLoad);
                return image;
            }
        }

        private static void GetPhotosFromDataReader(SqlDataReader reader, List<ImageSource> listPhotos)
        {
            while (reader.Read())
            {
                ImageSource photo = ConvertBytesToImageSource((Byte[])reader["Photo"]);
                listPhotos.Add(photo);
            }
        }

        private static void GetEmployésFromDataReader(SqlDataReader reader, List<Employé> lstEmployé)
        {
            while (reader.Read())
            {
                Employé e = new Employé()
                {
                    Id = (int)reader["EmployeeID"],
                    Prénom = reader["FirstName"].ToString(),
                    Nom = reader["LastName"].ToString()
                };

                lstEmployé.Add(e);
            }
        }
        #endregion

        #region Méthodes publiques
        static public List<ImageSource> GetPhotos()
        {
            List<ImageSource> listPhotos = new List<ImageSource>();

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();

                string query = "select Photo from Employees";
                SqlCommand cmd = new SqlCommand(query, cnx);

                using (var reader = cmd.ExecuteReader())
                {
                    GetPhotosFromDataReader(reader, listPhotos);
                }
            }
            return listPhotos;
        }

        static public List<Employé> GetEmployés()
        {
            List<Employé> lstEmployé = new List<Employé>();

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();

                string query = "select EmployeeID, LastName, FirstName from Employees";
                SqlCommand cmd = new SqlCommand(query, cnx);

                using (var reader = cmd.ExecuteReader())
                {
                    GetEmployésFromDataReader(reader, lstEmployé);
                }
            }

            return lstEmployé;
        }
        #endregion
    }
}
