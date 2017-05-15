using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Controls;
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

        private static void GetEmployésFromDataReader(SqlDataReader reader, List<Employé> lstEmployé)
        {
            while (reader.Read())
            {

                if (!lstEmployé.Any() || lstEmployé.Last().Id != (int)reader["EmployeeID"])
                {
                    Employé e = new Employé()
                    {
                        Id = (int)reader["EmployeeID"],
                        Prénom = reader["FirstName"].ToString(),
                        Nom = reader["LastName"].ToString(),
                        LstTerritoire = new List<Territoire>()
                    };

                    if (reader["ManagerFirstName"] != DBNull.Value)
                        e.PrénomManager = reader["ManagerFirstName"].ToString();

                    if (reader["ManagerLastName"] != DBNull.Value)
                        e.NomManager = reader["ManagerLastName"].ToString();

                    lstEmployé.Add(e);
                }

                Territoire t = new Territoire()
                {
                    Id = reader["TerritoryID"].ToString(),
                    Description = reader["TerritoryDescription"].ToString()
                };

                lstEmployé.Last().LstTerritoire.Add(t);
            }
        }

        private static void GetEmployésWithPhotoFromDataReader(SqlDataReader reader, List<Employé> lstEmployé)
        {
            while (reader.Read())
            {
                Employé e = new Employé()
                {
                    Prénom = reader["FirstName"].ToString(),
                    Nom = reader["LastName"].ToString(),
                    Photo = reader["Photo"] == DBNull.Value ? null : ConvertBytesToImageSource((Byte[])reader["Photo"])
                };

                lstEmployé.Add(e);
            }
        }

        #endregion

        #region Méthodes publiques
        static public List<Employé> GetEmployés()
        {
            List<Employé> lstEmployé = new List<Employé>();

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();

                string query = @"select e.EmployeeID, e.LastName, e.FirstName,
                                            t.TerritoryID, t.TerritoryDescription,
                                            e1.FirstName ManagerFirstName, e1.LastName ManagerLastName
                                 from Employees e
                                 left outer join Employees e1 on e.ReportsTo = e1.EmployeeID
                                 inner join EmployeeTerritories et on e.EmployeeID = et.EmployeeID
                                 inner join Territories t on et.TerritoryID = t.TerritoryID";

                SqlCommand cmd = new SqlCommand(query, cnx);

                using (var reader = cmd.ExecuteReader())
                {
                    GetEmployésFromDataReader(reader, lstEmployé);
                }
            }

            return lstEmployé;
        }

        static public List<Employé> GetEmployésWithPhoto()
        {
            List<Employé> lstEmployé = new List<Employé>();

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();

                string query = @"select e1.Photo, e1.FirstName, e1.LastName
                                 from Employees e1";

                SqlCommand cmd = new SqlCommand(query, cnx);

                using (var reader = cmd.ExecuteReader())
                {
                    GetEmployésWithPhotoFromDataReader(reader, lstEmployé);
                }
            }

            return lstEmployé;
        }
        #endregion
    }
}
