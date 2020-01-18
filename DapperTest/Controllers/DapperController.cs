using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DapperTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperTest.Controllers
{
    public class DapperController : Controller
    {
        string Connection = DataConnection.DataConnectionID;

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Create(Login m)
        {
            using (var connection = new SqlConnection(Connection))
            {
                string myCommand = "Insert into Login1 (Email, Password) values ('" + m.Email + "','" + m.Password + "');";
                connection.Execute(myCommand);
            }
            return Json("");
        }

        public JsonResult Update(Login m)
        {
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                string myCommand = "Update Login1 set Email = '" + m.Email + "', Password = '" + m.Password + "';";
                connection.Execute(myCommand);
            }

            return Json("");
        }

        public JsonResult Read()
        {
            List<Login> Temp = new List<Login>();

            using (SqlConnection connection = new SqlConnection(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Read");
                Temp = connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }

            return Json(Temp);
        }

        public JsonResult Delete()
        {   
            using (SqlConnection connection = new SqlConnection(Connection))
            {
                var Params = new DynamicParameters();
                Params.Add("@Flag", "Delete");
                connection.Query<Login>("LoginProcedure", Params, commandType: System.Data.CommandType.StoredProcedure);
            }

            return Json("");
        }
    }
}