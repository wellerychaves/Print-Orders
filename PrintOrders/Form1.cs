using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PrintOrders
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }

        private void BtnLoad_Click(object sender, EventArgs e)
            {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string query = $"SELECT c.ID AS ClientID, c.Name AS ClientName, c.CPF, ca.ID AS CarID, ca.Brand, ca.Model, ca.Price, o.ID AS OrderID, o.PurchaseDate " +
                               $"FROM Clients c " +
                               $"JOIN Orders o ON c.ID = o.ClientID " +
                               $"JOIN Cars ca ON o.CarID = ca.ID " +
                               $"WHERE o.PurchaseDate BETWEEN '{dtFromDate.Value}' and '{dtToDate.Value}'";
                ordersBindingSource.DataSource = db.Query<Orders>(query, commandType: CommandType.Text);
                }
            }

        private void BtnPrint_Click(object sender, EventArgs e)
            {

            Orders obj = ordersBindingSource.Current as Orders;
            if (obj != null)
                {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
                    {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    string query = "SELECT o.ID AS OrderID, c.Name AS ClientName, c.CPF, ca.ID AS CarID, ca.Brand, ca.Model, ca.FabricationDate, ca.Price, o.PurchaseDate " +
                                   "FROM Orders o " +
                                   "JOIN Clients c ON c.ID = o.ClientID " +
                                   "JOIN Cars ca ON o.CarID = ca.ID " +
                                   $"WHERE o.ID = '{obj.OrderID}'";
                    List<OrderDetail> list = db.Query<OrderDetail>(query, commandType: CommandType.Text).ToList();
                    using (frmPrint frm = new frmPrint(obj, list))
                        {
                        frm.ShowDialog();
                        }
                    }
                }

            }

        }
    }
