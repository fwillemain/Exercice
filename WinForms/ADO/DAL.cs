using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace ADO
{
    static public class DAL
    {
        #region Méthodes privées
        static private void RécupFournisseursDepuisSqlDataReader(SqlDataReader reader, List<Fournisseur> lstFournisseur)
        {
            while (reader.Read())
            {
                Fournisseur f = new Fournisseur();

                f.Id = (int)reader["SupplierID"];
                f.NomEntreprise = (string)reader["CompanyName"];
                if (reader["ContactName"] != DBNull.Value)
                    f.NomContact = (string)reader["ContactName"];
                if (reader["ContactTitle"] != DBNull.Value)
                    f.TitreContact = (string)reader["ContactTitle"];
                if (reader["Address"] != DBNull.Value)
                    f.Adresse = (string)reader["Address"];
                if (reader["City"] != DBNull.Value)
                    f.Ville = (string)reader["City"];
                if (reader["Region"] != DBNull.Value)
                    f.Région = (string)reader["Region"];
                if (reader["PostalCode"] != DBNull.Value)
                    f.CodePostal = (string)reader["PostalCode"];
                if (reader["Country"] != DBNull.Value)
                    f.Pays = (string)reader["Country"];

                lstFournisseur.Add(f);
            }
        }

        //static private void RécupCommandesDepuisSqlDataReader(SqlDataReader reader, List<Commande> lstCommande)
        //{
        //    while (reader.Read())
        //    {
        //        Commande c = new Commande();
        //        c.Id = reader["Id"].ToString();
        //        if (reader["Date"] != DBNull.Value)
        //            c.Date = (DateTime)reader["Date"];
        //        if (reader["DateEnvoi"] != DBNull.Value)
        //            c.DateEnvoi = (DateTime)reader["DateEnvoi"];
        //        c.NbArticles = (int)reader["NbArticles"];
        //        c.MontantTot = (decimal)reader["MontantTot"];
        //        c.FraisEnvoi = (decimal)reader["FraisEnvoi"];

        //        lstCommande.Add(c);
        //    }
        //}

        static private void RécupClientsDepuisSqlDataReader(SqlDataReader reader, List<Client> lstClient)
        {
            while (reader.Read())
            {
                Client c = new Client();
                c.Id = reader["CustomerID"].ToString();
                c.NomEntreprise = reader["CompanyName"].ToString();

                lstClient.Add(c);
            }
        }

        private static void RécupérerCommandesDepuisSqlDataReader(SqlDataReader reader, List<Commande> lstCommandes)
        {
            while (reader.Read())
            {
                int currentIdCommande = (int)reader["OrderID"];

                if (lstCommandes.Count == 0 || currentIdCommande != lstCommandes.Last().IdCommande)
                {
                    var com = new Commande() { LstLignesCommandes = new List<LigneCommande>() };
                    com.IdCommande = currentIdCommande;

                    if (reader["CustomerID"] != DBNull.Value)
                        com.IdClient = reader["CustomerID"].ToString();
                    if (reader["OrderDate"] != DBNull.Value)
                        com.Date = (DateTime)reader["OrderDate"];

                    lstCommandes.Add(com);
                }

                var ligne = new LigneCommande();

                ligne.IdProduit = (int)reader["ProductID"];
                ligne.PrixUnitaire = (decimal)reader["UnitPrice"];
                ligne.Quantité = (Int16)reader["Quantity"];
                ligne.Réduction = (float)reader["Discount"];

                lstCommandes.Last().LstLignesCommandes.Add(ligne);
            }
        }

        static private void RécupProduitsDepuisSqlDataReader(SqlDataReader reader, BindingList<Produit> lstProduit)
        {
            while (reader.Read())
            {
                var p = new Produit();

                p.Id = (int)reader["ProductID"];
                p.Nom = reader["ProductName"].ToString();

                if (reader["SupplierID"] != DBNull.Value)
                    p.IdFournisseur = (int)reader["SupplierID"];

                if (reader["CategoryID"] != DBNull.Value)
                    p.IdCatégorie = (int)reader["CategoryID"];

                if (reader["QuantityPerUnit"] != DBNull.Value)
                    p.QuantitéParUnité = reader["QuantityPerUnit"].ToString();

                if (reader["UnitPrice"] != DBNull.Value)
                    p.PrixUnitaire = (decimal)reader["UnitPrice"];

                if (reader["UnitsInStock"] != DBNull.Value)
                    p.QuantitéStock = (Int16)reader["UnitsInStock"];

                //if (reader["UnitsOnOrder"] != DBNull.Value)
                //    p.QuantitéAttenteRécéption = (Int16)reader["UnitsOnOrder"];

                //p.EnFinDeSérie = (bool)reader["Discontinued"];

                lstProduit.Add(p);
            }
        }

        static private void RécupCatégoriesDepuisSqlDataReader(SqlDataReader reader, List<Catégorie> lstCatégorie)
        {
            while (reader.Read())
            {
                Catégorie c = new Catégorie();
                c.Id = (int)reader["CategoryId"];
                c.Nom = reader["CategoryName"].ToString();
                lstCatégorie.Add(c);
            }
        }

        private static void RécupérerEmployéesDepuisSqlDataReader(SqlDataReader reader, List<Employée> lstEmployées)
        {
            while (reader.Read())
            {
                Employée emp = new Employée();
                emp.Id = (int)reader["EmployeeID"];
                emp.NomComplet = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();

                lstEmployées.Add(emp);
            }
        }

        private static void RécupérerTerritoiresRégionsDepuisSqlDataReader(SqlDataReader reader, BindingList<TerritoireRégion> lstTerritoires)
        {
            while (reader.Read())
            {
                TerritoireRégion ter = new TerritoireRégion();
                ter.CodeTerritoire = reader["TerritoryID"].ToString();
                ter.DescriptionTerritoire = reader["TerritoryDescription"].ToString();
                ter.IdRégion = (int)reader["RegionID"];
                ter.DescriptionRégion = reader["RegionDescription"].ToString();

                lstTerritoires.Add(ter);
            }
        }

        private static void RécupérerTerritoiresEmployésDepuisSqlDataReader(SqlDataReader reader, List<TerritoireEmployé> lstTerritoiresEmployés)
        {
            while (reader.Read())
            {
                TerritoireEmployé terE = new TerritoireEmployé();
                terE.CodeTerritoire = reader["TerritoryID"].ToString();
                terE.IdEmployé = (int)reader["EmployeeID"];

                lstTerritoiresEmployés.Add(terE);
            }
        }

        /// <summary>
        /// Renvoi une DataTable de type TypeTableProduit
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        private static object RécupérerDataTableTTPDepuisListeProduit(List<Produit> lp)
        {
            DataTable table = new DataTable();

            #region Ajout des colonnes
            table.Columns.Add(new DataColumn("ProductName", typeof(string)));
            table.Columns["ProductName"].AllowDBNull = false;

            table.Columns.Add(new DataColumn("SupplierID", typeof(int)));

            table.Columns.Add(new DataColumn("CategoryID", typeof(int)));

            table.Columns.Add(new DataColumn("QuantityPerUnit", typeof(string)));

            table.Columns.Add(new DataColumn("UnitPrice", typeof(decimal)));

            table.Columns.Add(new DataColumn("UnitsInStock", typeof(Int16)));
            #endregion

            foreach (var p in lp)
            {
                DataRow ligne = table.NewRow();

                #region Remplissage de la ligne
                ligne["ProductName"] = p.Nom;

                if (p.IdFournisseur != null)
                    ligne["SupplierID"] = p.IdFournisseur;
                else
                    ligne["SupplierID"] = DBNull.Value;

                if (p.IdCatégorie != null)
                    ligne["CategoryID"] = p.IdCatégorie;
                else
                    ligne["CategoryID"] = DBNull.Value;

                if (p.QuantitéParUnité != null)
                    ligne["QuantityPerUnit"] = p.QuantitéParUnité;
                else
                    ligne["QuantityPerUnit"] = DBNull.Value;

                if (p.PrixUnitaire != null)
                    ligne["UnitPrice"] = p.PrixUnitaire;
                else
                    ligne["UnitPrice"] = DBNull.Value;

                if (p.QuantitéStock != null)
                    ligne["UnitsInStock"] = p.QuantitéStock;
                else
                    ligne["UnitsInStock"] = DBNull.Value;
                #endregion

                table.Rows.Add(ligne);
            }

            return table;
        }

        /// <summary>
        /// Renvoi une DataTable de type TypeTableId
        /// </summary>
        /// <param name="lp"></param>
        /// <returns></returns>
        private static object RécupérerDataTableTTIDepuisListeProduit(IEnumerable<int> lip)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns["Id"].AllowDBNull = false;

            foreach (var i in lip)
            {
                DataRow ligne = table.NewRow();

                ligne["Id"] = i;
                table.Rows.Add(ligne);
            }

            return table;
        }

        /// <summary>
        /// Renvoi une DataTable de type TypeTableTerrEmp
        /// </summary>
        /// <param name="lstTerritoiresEmployés"></param>
        /// <returns></returns>
        private static object RécupérerDataTableTTTEDepuisListeTerritoiresEmployés(List<TerritoireEmployé> lte)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("EmployeeId", typeof(int)));
            table.Columns["EmployeeId"].AllowDBNull = false;

            table.Columns.Add(new DataColumn("TerritoryId", typeof(string)));
            table.Columns["TerritoryId"].AllowDBNull = false;

            foreach (var te in lte)
            {
                DataRow ligne = table.NewRow();
                ligne["EmployeeId"] = te.IdEmployé;
                ligne["TerritoryId"] = te.CodeTerritoire;

                table.Rows.Add(ligne);
            }

            return table;
        }
        #endregion

        #region Méthodes publiques
        static public void ListeRegions()
        {
            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                // Création de la requête
                string requete = "Select * from Region";

                // Relier la requête à une connexion
                var commande = new SqlCommand(requete, connexion);

                // Ouvrir la connexion
                connexion.Open();

                // Récupérer le résultat de la commande et l'afficher
                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    Console.WriteLine("Liste des régions :");
                    while (reader.Read())
                        Console.WriteLine("{0}, {1}", reader[0], reader[1]);
                }
            }
        }

        static public List<Fournisseur> RécupérerFournisseurs()
        {
            var lstFournisseur = new List<Fournisseur>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select SupplierID, CompanyName, ContactName, ContactTitle, Address, City,
                                                        Region, PostalCode, Country from Suppliers";


                var commande = new SqlCommand(requete, connection);
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    RécupFournisseursDepuisSqlDataReader(reader, lstFournisseur);
                }
            }

            return lstFournisseur;
        }

        static public List<Fournisseur> RécupérerFournisseurs(string pays)
        {
            var lstFournisseur = new List<Fournisseur>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select SupplierID, CompanyName, ContactName, ContactTitle, Address, City,
                                                        Region, PostalCode, Country from Suppliers 
                                   where Country = @Pays";

                var param = new SqlParameter("@Pays", DbType.String);
                param.Value = pays;

                var commande = new SqlCommand(requete, connection);
                commande.Parameters.Add(param);
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    RécupFournisseursDepuisSqlDataReader(reader, lstFournisseur);
                }
            }

            return lstFournisseur;
        }

        static public List<string> RécupérerPaysFournisseurs()
        {
            var lstPaysFournisseur = new List<string>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select distinct Country from Suppliers";

                var commande = new SqlCommand(requete, connection);
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lstPaysFournisseur.Add((string)reader[0]);
                    }
                }
            }
            return lstPaysFournisseur;
        }

        static public int RécupérerNbProduitsPaysFournisseur(string pays)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select COUNT(ProductId) from Products p
                                   inner join Suppliers s on p.SupplierID = s.SupplierID
                                   where s.Country = @Pays";
                SqlParameter param = new SqlParameter("@Pays", DbType.String);
                param.Value = pays;

                var commande = new SqlCommand(requete, connection);
                commande.Parameters.Add(param);

                connection.Open();

                return (int)commande.ExecuteScalar();
            }
        }

        static public List<Commande> RécupérerCommandeClient(string IdClient)
        {
            var lstCommandeClient = new List<Commande>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select Id, Date, DateEnvoi, NbArticles, MontantTot, FraisEnvoi
                                   from ufn_CommandesClient(@IdClient)";
                var param = new SqlParameter("@IdClient", DbType.String);

                // IdClient sera sous la forme "IdClient - NomEntreprise"
                // On récupère juste la première partie
                param.Value = IdClient;

                var commande = new SqlCommand(requete, connection);
                commande.Parameters.Add(param);

                //commande.Parameters.Add(new SqlParameter("@IdClient", DbType.String));
                //commande.Parameters["@IdClient"].Value = IdClient;
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    //RécupCommandesDepuisSqlDataReader(reader, lstCommandeClient);
                }
            }
            return lstCommandeClient;
        }

        static public List<Client> RécupérerClients()
        {
            List<Client> lstClients = new List<Client>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select CustomerID, CompanyName from Customers";

                var commande = new SqlCommand(requete, connection);
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    RécupClientsDepuisSqlDataReader(reader, lstClients);
                }
            }

            return lstClients;
        }

        static public BindingList<Produit> RécupérerProduits()
        {
            BindingList<Produit> lstProduits = new BindingList<Produit>();

            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string query = @"select ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                                            UnitPrice, UnitsInStock 
                                 from Products
                                 where Discontinued = 0";
                var command = new SqlCommand(query, connexion);

                connexion.Open();

                using (var reader = command.ExecuteReader())
                {
                    RécupProduitsDepuisSqlDataReader(reader, lstProduits);
                }
            }

            return lstProduits;
        }

        static public BindingList<Produit> RécupérerProduitsFournisseur(int IdFournisseur)
        {
            BindingList<Produit> lstProduits = new BindingList<Produit>();

            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string query = @"select ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                                            UnitPrice, UnitsInStock from Products
                                 where SupplierID = @IdFournisseur";

                //string query = @"select ProductID, ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                //                            UnitPrice, UnitsInStock, UnitsOnOrder, Discontinued from Products
                //                 where SupplierID = @IdFournisseur";

                var param = new SqlParameter("IdFournisseur", DbType.Int32);
                param.Value = IdFournisseur;

                var command = new SqlCommand(query, connexion);
                command.Parameters.Add(param);

                connexion.Open();

                using (var reader = command.ExecuteReader())
                {
                    RécupProduitsDepuisSqlDataReader(reader, lstProduits);
                }
            }

            return lstProduits;
        }

        static public void AjouterProduitBDD(Produit p)
        {
            string query = @"insert Products(ProductName, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, SupplierID) 
                              values(@ProductName, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @SupplierID)";

            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                connexion.Open();
                SqlTransaction tran = connexion.BeginTransaction();

                var command = new SqlCommand(query, connexion, tran);

                #region Ajouts des paramètres
                command.Parameters.Add(new SqlParameter("@ProductName", p.Nom));
                command.Parameters["@ProductName"].Value = p.Nom;

                command.Parameters.Add(new SqlParameter("@CategoryID", DbType.Int32));
                if (p.IdCatégorie == 0)
                    command.Parameters["@CategoryID"].Value = DBNull.Value;
                else
                    command.Parameters["@CategoryID"].Value = p.IdCatégorie;

                command.Parameters.Add(new SqlParameter("@QuantityPerUnit", DbType.String));
                if (string.IsNullOrEmpty(p.QuantitéParUnité))
                    command.Parameters["@QuantityPerUnit"].Value = DBNull.Value;
                else
                    command.Parameters["@QuantityPerUnit"].Value = p.QuantitéParUnité;

                command.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Currency));
                command.Parameters["@UnitPrice"].Value = p.PrixUnitaire;

                command.Parameters.Add(new SqlParameter("@UnitsInStock", DbType.Int16));
                command.Parameters["@UnitsInStock"].Value = p.QuantitéStock;

                command.Parameters.Add(new SqlParameter("@SupplierID", DbType.Int32));
                if (p.IdFournisseur == 0)
                    command.Parameters["@SupplierID"].Value = DBNull.Value;
                else
                    command.Parameters["@SupplierID"].Value = p.IdFournisseur;
                #endregion

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

        static public void AjouterProduitBDD(List<Produit> lp)
        {
            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string query = @"insert Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock)
                             select ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock
                             from @table";

                connexion.Open();
                var tran = connexion.BeginTransaction();

                var command = new SqlCommand(query, connexion, tran);
                command.Parameters.Add(new SqlParameter("@table", SqlDbType.Structured));
                command.Parameters["@table"].Value = RécupérerDataTableTTPDepuisListeProduit(lp);
                command.Parameters["@table"].TypeName = "TypeTableProduit";

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

        static public void SupprimerProduitBDD(int ProduitId)
        {
            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                connexion.Open();
                var tran = connexion.BeginTransaction();

                string query = @"delete from Products where ProductID = @ProductID";
                var command = new SqlCommand(query, connexion, tran);

                command.Parameters.Add(new SqlParameter("@ProductID", DbType.Int32));
                command.Parameters["@ProductID"].Value = ProduitId;

                try
                {
                    command.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (SqlException e)
                {
                    tran.Rollback();

                    switch (e.Number)
                    {
                        case 547:
                        // Générer une exception spécifique pour ce cas
                        default:
                            throw;
                    }
                }
            }
        }

        static public void SupprimerProduitBDD(IEnumerable<int> listeIdProduits)
        {
            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                connexion.Open();
                var tran = connexion.BeginTransaction();

                //  string query = @"delete p from Products p inner join @table t on p.ProductId = t.Id";
                string query = @"update Products set Discontinued = 1
                                 from @table t
                                 where ProductId = t.Id";

                var command = new SqlCommand(query, connexion, tran);
                command.Parameters.Add(new SqlParameter("@table", SqlDbType.Structured));
                command.Parameters["@table"].TypeName = "TypeTableId";
                command.Parameters["@table"].Value = RécupérerDataTableTTIDepuisListeProduit(listeIdProduits);

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

        static public List<Catégorie> RécupérerCatégories()
        {
            var lstCatégories = new List<Catégorie>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                string requete = @"select CategoryId, CategoryName from Categories";

                var commande = new SqlCommand(requete, connection);
                connection.Open();

                using (SqlDataReader reader = commande.ExecuteReader())
                {
                    RécupCatégoriesDepuisSqlDataReader(reader, lstCatégories);
                }
            }
            return lstCatégories;
        }

        static public List<Employée> RécupérerEmployées()
        {
            List<Employée> lstEmployées = new List<Employée>();

            string queryString = @"select EmployeeID, LastName, FirstName from Employees";

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                cnx.Open();
                var command = new SqlCommand(queryString, cnx);

                using (var reader = command.ExecuteReader())
                {
                    RécupérerEmployéesDepuisSqlDataReader(reader, lstEmployées);
                }
            }

            return lstEmployées;
        }

        #region Attention ConnexionString de la maison !!!
        // TODO : Penser à créer le type TableTypeTerrEmp as table ( EmployeeId int, TerritoryId nvarchar(20)) chez ISAGRI
        static public BindingList<TerritoireRégion> RécupérerTerritoiresRégions()
        {
            BindingList<TerritoireRégion> lstTerritoiresRégions = new BindingList<TerritoireRégion>();

            string queryString = @"select t.TerritoryID, t.TerritoryDescription, r.RegionID, r.RegionDescription 
                                   from Territories t 
                                   inner join Region r on t.RegionID = r.RegionID
                                   order by 3";

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                cnx.Open();
                var command = new SqlCommand(queryString, cnx);

                using (var reader = command.ExecuteReader())
                {
                    RécupérerTerritoiresRégionsDepuisSqlDataReader(reader, lstTerritoiresRégions);
                }
            }

            return lstTerritoiresRégions;
        }

        static public List<TerritoireEmployé> RécupérerTerritoiresEmployés()
        {
            List<TerritoireEmployé> lstTerritoiresEmployés = new List<TerritoireEmployé>();

            string queryString = @"select et.TerritoryID, e.EmployeeID
                                   from EmployeeTerritories et 
                                   inner join Employees e on et.EmployeeID = e.EmployeeID";

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                cnx.Open();
                var command = new SqlCommand(queryString, cnx);

                using (var reader = command.ExecuteReader())
                {
                    RécupérerTerritoiresEmployésDepuisSqlDataReader(reader, lstTerritoiresEmployés);
                }
            }

            return lstTerritoiresEmployés;
        }

        static public void MajTerritoireEmployéBDD(List<TerritoireEmployé> lstTerritoiresEmployés)
        {
            // Si la liste est vide, ne rien faire
            if (!lstTerritoiresEmployés.Any())
                return;

            using (SqlConnection connexion = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                connexion.Open();
                var tran = connexion.BeginTransaction();

                string query = @"MERGE EmployeeTerritories AS Cible
                                 USING (SELECT EmployeeId, TerritoryId FROM @table) AS Source
                                 ON (Cible.TerritoryId = Source.TerritoryId and Cible.EmployeeId = Source.EmployeeId)
                                 WHEN MATCHED THEN
	                                delete
                                 WHEN NOT MATCHED BY TARGET THEN
                                    INSERT (TerritoryId, EmployeeId)
                                    VALUES (Source.TerritoryId, Source.EmployeeId);";

                var command = new SqlCommand(query, connexion, tran);

                #region Ajout des paramètres
                command.Parameters.Add(new SqlParameter("@table", SqlDbType.Structured));
                command.Parameters["@table"].TypeName = "TypeTableTerrEmp";
                command.Parameters["@table"].Value = RécupérerDataTableTTTEDepuisListeTerritoiresEmployés(lstTerritoiresEmployés);
                #endregion

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
        #endregion

        static public List<Commande> RécupérerCommandes()
        {
            var lstCommandes = new List<Commande>();


            string queryString = @"select o.OrderID, o.CustomerID, o.OrderDate,
                                            od.ProductID, od.UnitPrice, od.Quantity, od.Discount
                                   from Orders o
                                   inner join Order_Details od on o.OrderID = od.OrderID
                                   order by 1";

            using (SqlConnection cnx = new SqlConnection(Properties.Settings.Default.NorthwindConnectionString))
            {
                cnx.Open();
                var command = new SqlCommand(queryString, cnx);

                using (var reader = command.ExecuteReader())
                {
                    RécupérerCommandesDepuisSqlDataReader(reader, lstCommandes);
                }
            }

            return lstCommandes;
        }

        static public void ExporterXml(List<Commande> lstCommandes)
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<Commande>), new XmlRootAttribute("ListeCommandes"));

            using (var sw = new StreamWriter(@"../../ListeCommandes.xml"))
            {
                serial.Serialize(sw, lstCommandes);
            }
        }

        static public List<Commande> ImporterXml()
        {
            List<Commande> lstCommandes = null;

            XmlSerializer serial = new XmlSerializer(typeof(List<Commande>), new XmlRootAttribute("ListeCommandes"));
            using (var sr = new StreamReader(@"../../ListeCommandes.xml"))
            {
                lstCommandes = (List<Commande>)serial.Deserialize(sr);
            }

            return lstCommandes;
        }

        #endregion
    }
}

