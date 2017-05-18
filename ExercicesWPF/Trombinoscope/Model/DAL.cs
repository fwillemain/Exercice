using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;

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

                if (reader["TerritoryID"] != DBNull.Value && reader["TerritoryDescription"] != DBNull.Value)
                {
                    Territoire t = new Territoire()
                    {
                        Id = reader["TerritoryID"].ToString(),
                        Description = reader["TerritoryDescription"].ToString()
                    };

                    lstEmployé.Last().LstTerritoire.Add(t);
                }
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
                                 left outer join EmployeeTerritories et on e.EmployeeID = et.EmployeeID
                                 left outer join Territories t on et.TerritoryID = t.TerritoryID";

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

        static public void AjouterEmployé(Employé e)
        {
            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();
                var tran = cnx.BeginTransaction();

                string query = @"insert Employees(LastName, FirstName) values (@Nom, @Prénom)";
                SqlCommand command = new SqlCommand(query, cnx, tran);

                command.Parameters.Add(new SqlParameter("@Nom", SqlDbType.NVarChar));
                command.Parameters["@Nom"].Value = e.Nom;

                command.Parameters.Add(new SqlParameter("@Prénom", SqlDbType.NVarChar));
                command.Parameters["@Prénom"].Value = e.Prénom;

                try
                {
                    command.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        static public void SupprimerEmployé(int id)
        {
            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();
                var tran = cnx.BeginTransaction();

                string query = @"delete from Employees where EmployeeID = @Id";
                SqlCommand command = new SqlCommand(query, cnx, tran);

                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters["@Id"].Value = id;

                try
                {
                    command.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        static public int RécupérérIdDernierEmployé()
        {
            int res = 0;

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.StringConnection))
            {
                cnx.Open();
                string query = @"select top 1 EmployeeID from Employees
                                 order by EmployeeID desc";
                SqlCommand command = new SqlCommand(query, cnx);

                res = (int) command.ExecuteScalar();
            }

            return res;
        }
        #endregion
    }
}
