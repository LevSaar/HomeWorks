using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ShopDB = new DataSet();

            DataTable Orders = new DataTable("Orders");
            Orders.Columns.Add("Id", typeof(int));
            Orders.Columns.Add("CustomerId", typeof(int));
            Orders.Columns.Add("EmployeeId", typeof(int));
            Orders.Columns.Add("Date", typeof(DateTime));


            DataTable Customers = new DataTable("Customers");
            Customers.Columns.Add("Id", typeof(int));
            Customers.Columns.Add("Name", typeof(string));
            Customers.Columns.Add("Address", typeof(string));
            Customers.Columns.Add("Phone", typeof(string));


            DataTable Employees = new DataTable("Employees");
            Employees.Columns.Add("Id", typeof(int));
            Employees.Columns.Add("Name", typeof(string));
            Employees.Columns.Add("Phone", typeof(string));


            DataTable OrderDetails = new DataTable("OrderDetails");
            OrderDetails.Columns.Add("Id", typeof(int));
            OrderDetails.Columns.Add("OrderId", typeof(int));
            OrderDetails.Columns.Add("ProductId", typeof(int));
            OrderDetails.Columns.Add("Quantity", typeof(int));
            OrderDetails.Columns.Add("UnitPrice", typeof(int));
            OrderDetails.Columns.Add("Discount", typeof(int));


            DataTable Products = new DataTable("Products");
            Products.Columns.Add("Id", typeof(int));
            Products.Columns.Add("Name", typeof(string));
            Products.Columns.Add("Price", typeof(int));
            Products.Columns.Add("UnitPrice", typeof(int));
            Products.Columns.Add("InStock", typeof(int));


            Orders.PrimaryKey = new DataColumn[] { Orders.Columns["Id"] };
            Customers.PrimaryKey = new DataColumn[] { Customers.Columns["Id"] };
            Employees.PrimaryKey = new DataColumn[] { Employees.Columns["Id"] };
            OrderDetails.PrimaryKey = new DataColumn[] { OrderDetails.Columns["Id"] };
            Products.PrimaryKey = new DataColumn[] { Products.Columns["Id"] };


            ShopDB.Tables.AddRange(new DataTable[] { Orders, Customers, Employees, OrderDetails, Products });



            DataColumn parentColumn = ShopDB.Tables["Customers"].Columns["Id"];
            DataColumn childColumn = ShopDB.Tables["Orders"].Columns["CustomerId"];
            ForeignKeyConstraint foreignKeyConstraint = new ForeignKeyConstraint
               ("CustOrderFK", parentColumn, childColumn);
            ShopDB.Tables["Orders"].Constraints.Add(foreignKeyConstraint);

            parentColumn = ShopDB.Tables["Employees"].Columns["Id"];
            childColumn = ShopDB.Tables["Orders"].Columns["EmployeeId"];
            foreignKeyConstraint = new ForeignKeyConstraint
               ("EmpOrderFK", parentColumn, childColumn);
            ShopDB.Tables["Orders"].Constraints.Add(foreignKeyConstraint);

            parentColumn = ShopDB.Tables["Orders"].Columns["Id"];
            childColumn = ShopDB.Tables["OrderDetails"].Columns["OrderId"];
            foreignKeyConstraint = new ForeignKeyConstraint
               ("OrdDetFK", parentColumn, childColumn);
            ShopDB.Tables["OrderDetails"].Constraints.Add(foreignKeyConstraint);

            parentColumn = ShopDB.Tables["Products"].Columns["Id"];
            childColumn = ShopDB.Tables["OrderDetails"].Columns["ProductId"];
            foreignKeyConstraint = new ForeignKeyConstraint
               ("ProOrdFk", parentColumn, childColumn);
            ShopDB.Tables["OrderDetails"].Constraints.Add(foreignKeyConstraint);

            ShopDB.EnforceConstraints = true;

        }
    }
}
