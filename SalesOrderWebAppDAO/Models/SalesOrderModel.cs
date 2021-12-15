using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SalesOrderWebAppDAO.Models
{
    public class SalesOrderModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }

        public SalesOrderModel()
        {
                
        }
    }

    public class SalesOrderModelServices
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(Properties.Resources.ConnectionString);

        public int SaveNeSalesOrder(SalesOrderModel data)
        {
            int afectRows;
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = string.Format("INSERT INTO [SalesOrderDB].[dbo].[SalesOrder] (Customer,Product,Price)  VALUES ('{0}','{1}',{2})", data.Customer, data.Product, data.Price);
                afectRows = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return afectRows;
        }

        public List<SalesOrderModel> GetSalesOrders()
        {
            List<SalesOrderModel> salesorderList = new List<SalesOrderModel>();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT [Id],[Customer],[Product],[Price] FROM [SalesOrderDB].[dbo].[SalesOrder] ORDER BY [Price] DESC";
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    SalesOrderModel so = new SalesOrderModel();
                    so.Id = dr.GetInt32(0);
                    so.Customer = dr.GetString(1);
                    so.Product = dr.GetString(2);
                    so.Price = dr.GetDecimal(3);
                    salesorderList.Add(so);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return salesorderList;
        }

        public SalesOrderModel GetSalesOrderById(int Id)
        {
            SalesOrderModel salesorderList = new SalesOrderModel();
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = string.Format("SELECT [Id],[Customer],[Product],[Price] FROM [SalesOrderDB].[dbo].[SalesOrder] WHERE [Id] = {0}",Id);
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    //SalesOrderModel so = new SalesOrderModel();
                    salesorderList.Id = dr.GetInt32(0);
                    salesorderList.Customer = dr.GetString(1);
                    salesorderList.Product = dr.GetString(2);
                    salesorderList.Price = dr.GetDecimal(3);
                    //salesorderList.Add(so);
                }
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return salesorderList;
        }

    }

}
