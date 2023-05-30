using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PrintOrders
    {

    public partial class frmPrint : Form
        {
        List<OrderDetail> _list;
        Orders _orders;
        public frmPrint(Orders orders, List<OrderDetail> list)
            {
            InitializeComponent();
            _orders = orders;
            _list = list;
            }

        private void FrmPrint_Load(object sender, EventArgs e)
            {
            var rptOrders1 = new rptOrders();
            rptOrders1.SetDataSource(_list);
            rptOrders1.SetParameterValue("pClientName", _orders.ClientName);
            rptOrders1.SetParameterValue("pClientCPF", _orders.CPF);
            rptOrders1.SetParameterValue("pOrderID", _orders.OrderID);
            rptOrders1.SetParameterValue("pPurchaseDate", _orders.PurchaseDate.ToString("dd/MM/yyyy"));
            rptOrders1.SetParameterValue("pCarBrand", _orders.Brand);
            rptOrders1.SetParameterValue("pCarModel", _orders.Model);
            rptOrders1.SetParameterValue("pCarPrice", _orders.Price);
            crystalReportViewer.ReportSource = rptOrders1;
            crystalReportViewer.Refresh();
            }
        }
    }
