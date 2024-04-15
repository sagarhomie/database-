using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult student() {

            List<StudentModel> students = new List<StudentModel>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SimpleadonetdemoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string command = "select * from Student";
            SqlCommand sqlCommand = new SqlCommand(command, conn);
           // sqlCommand.ExecuteReader();
           SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
           DataTable dataTable= new DataTable();
           adapter.Fill(dataTable);
            foreach(DataRow student in dataTable.Rows) { 
            StudentModel studentModel = new StudentModel();
                studentModel.StudentId = Convert.ToInt32( student["StudentId"]);
                studentModel.Name= student["Name"].ToString();
                studentModel.Address= student["Address"].ToString();
                studentModel.Semester = Convert.ToInt32( student["Semester"]);
                studentModel.Marks =Convert.ToDecimal( student["Marks"]);
                students.Add(studentModel);
                
            }




            return View(students);
       
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {

            StudentModel student = new StudentModel();
            return View(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentModel student)
        {

            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Simpleadonetdemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string command = "insert into Student" +
                    "(\"Name\", \"Semester\", \"Marks\", \"Address\") Values"+
                    " ('" + student.Name + "'," + student.Semester + "," +
                    student.Marks + ",'" + student.Address + "')";
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction("student");
            }
            catch (Exception ex)

            {

               
                return View(student);
            }
         

           


        }
        [HttpGet]
        public IActionResult EditStudent(int StudentId)
        {

            StudentModel students = new  StudentModel();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SushantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string command = "select * from Student where studentId= "+ StudentId;
            SqlCommand sqlCommand = new SqlCommand(command, conn);
            // sqlCommand.ExecuteReader();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow student in dataTable.Rows)
            {
           
                students.StudentId = Convert.ToInt32(student["StudentId"]);
                students.Name = student["Name"].ToString();
                students.Address = student["Address"].ToString();
                students.Semester = Convert.ToInt32(student["Semester"]);
                students.Marks = Convert.ToDecimal(student["Marks"]);
               

            }

            return View(students);


        }

        [HttpPost]
        public IActionResult EditStudent(StudentModel student)
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SushantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string command = "Update Student set" +"\"Name\"='" + student.Name +
                    "' where StudentId= " + student.StudentId;                    
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                // sqlCommand.ExecuteReader();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction("student");


            }
            catch (Exception ex)
            {
                return View(student);
            }
           

        }
        public IActionResult DeleteStudent(int StudentId)
        {
            try
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SushantDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string command = "Delete Student where studentId=" + StudentId;
                
                SqlCommand sqlCommand = new SqlCommand(command, conn);
                // sqlCommand.ExecuteReader();
                sqlCommand.ExecuteNonQuery();
                return RedirectToAction("student");

            }
            catch (Exception)
            {

                throw;
            }

        }
    }


}
