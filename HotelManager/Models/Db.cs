using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace HotelManager.Models
{
    public class Db
    {
        public static Users GetUserByUsername(string username)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Users where Username = @username", conn);
                cmd.Parameters.AddWithValue("username", username);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                Users user = new Users();
                while (sqlDataReader.Read())
                {
                    user.IdUser = Convert.ToInt32(sqlDataReader["IdUser"]);
                    user.Username = sqlDataReader["Username"].ToString();
                    user.Psw = sqlDataReader["Psw"].ToString();
                    user.Role = sqlDataReader["Role"].ToString();
                }
                return user;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;

        }
        public static Customer GetCustomerById(int id)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("select * from Customers where IdCustomer = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                Customer c = new Customer();
                while (sqlDataReader.Read())
                {

                    c.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    c.Name = sqlDataReader["Name"].ToString();
                    c.Surname = sqlDataReader["Surname"].ToString();
                    c.Cf = sqlDataReader["Cf"].ToString();
                    c.City = sqlDataReader["City"].ToString();
                    c.Pr = sqlDataReader["Pr"].ToString();
                    c.Email = sqlDataReader["Email"].ToString();
                    c.Tel = sqlDataReader["Tel"].ToString();
                    c.Cell = sqlDataReader["Cell"].ToString();
                }

                return c;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;

        }
        public static void ModifyCustomer(int id, string Name, string Surname, string Cf, string City, string Pr, string Email, string Tel, string Cell)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Customers SET Name=@Name,Surname=@Surname, Cf=@Cf, City=@City, Pr=@Pr, Email=@Email, Tel=@Tel, Cell=@Cell where IdCustomer=@id";
            cmd.Parameters.AddWithValue("Name", Name);
            cmd.Parameters.AddWithValue("Surname", Surname);
            cmd.Parameters.AddWithValue("Cf", Cf);
            cmd.Parameters.AddWithValue("City", City);
            cmd.Parameters.AddWithValue("Pr", Pr);
            cmd.Parameters.AddWithValue("Email", Email);
            cmd.Parameters.AddWithValue("Tel", Tel);
            cmd.Parameters.AddWithValue("Cell", Cell);
            cmd.Parameters.AddWithValue("id", id);
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static List<Customer> GetAllCustomers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Customers", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            List<Customer> customers = new List<Customer>();
            while (sqlDataReader.Read())
            {
                Customer c = new Customer();
                c.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                c.Name = sqlDataReader["Name"].ToString();
                c.Surname = sqlDataReader["Surname"].ToString();
                c.Cf = sqlDataReader["Cf"].ToString();
                c.City = sqlDataReader["City"].ToString();
                c.Pr = sqlDataReader["Pr"].ToString();
                c.Email = sqlDataReader["Email"].ToString();
                c.Tel = sqlDataReader["Tel"].ToString();
                c.Cell = sqlDataReader["Cell"].ToString();
                customers.Add(c);

            }

            conn.Close();
            return customers;
        }
        public static List<Reservation> GetAllReservation()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reservations ORDER BY IdReservation DESC", conn);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                List<Reservation> reservations = new List<Reservation>();
                while (sqlDataReader.Read())
                {
                    Reservation r = new Reservation();
                    r.IdReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    r.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    r.Start = Convert.ToDateTime(sqlDataReader["Start"]);
                    r.EndRes = Convert.ToDateTime(sqlDataReader["EndRes"]);
                    r.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    r.Price = Convert.ToDouble(sqlDataReader["Price"]);
                    r.Details = sqlDataReader["Details"].ToString();
                    r.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    r.IdRooms = Convert.ToInt32(sqlDataReader["IdRooms"]);
                    reservations.Add(r);
                }

                return reservations;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static Reservation GetReservationById(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reservations Where IdReservation = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();
                Reservation r = new Reservation();
                while (sqlDataReader.Read())
                {
                    
                    r.IdReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    r.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    r.Start = Convert.ToDateTime(sqlDataReader["Start"]);
                    r.EndRes = Convert.ToDateTime(sqlDataReader["EndRes"]);
                    r.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    r.Price = Convert.ToDouble(sqlDataReader["Price"]);
                    r.Details = sqlDataReader["Details"].ToString();
                    r.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    r.IdRooms = Convert.ToInt32(sqlDataReader["IdRooms"]);
                
                }

                return r;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static List<Room> GetAllRooms()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Rooms", conn);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            List<Room> rooms = new List<Room>();
            while (sqlDataReader.Read())
            {
                Room r = new Room();
                r.IdRoom = Convert.ToInt32(sqlDataReader["IdRoom"]);
                r.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                r.Description = sqlDataReader["RoomNumber"].ToString();
                r.Type = sqlDataReader["Type"].ToString();

                rooms.Add(r);

            }

            conn.Close();
            return rooms;
        }
        public static void InsertOpts(bool RoomBr, bool MiniBar, bool Internet, bool AddBed, bool Cradle, int IdReservation)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Services VALUES(@RoomBr,@MiniBar,@Internet,@AddBed,@Cradle,@IdReservation)";
                cmd.Parameters.AddWithValue("RoomBr", RoomBr);
                cmd.Parameters.AddWithValue("MiniBar", MiniBar);
                cmd.Parameters.AddWithValue("Internet", Internet);
                cmd.Parameters.AddWithValue("AddBed", AddBed);
                cmd.Parameters.AddWithValue("Cradle", Cradle);
                cmd.Parameters.AddWithValue("IdReservation", IdReservation);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void NewCustomer(string Name, string Surname, string Cf, string City, string Pr, string Email, string Tel, string Cell)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Customers VALUES(@Name,@Surname,@Cf,@City,@Pr,@Email,@Tel,@Cell)";
                cmd.Parameters.AddWithValue("Name", Name);
                cmd.Parameters.AddWithValue("Surname", Surname);
                cmd.Parameters.AddWithValue("Cf", Cf);
                cmd.Parameters.AddWithValue("City", City);
                cmd.Parameters.AddWithValue("Pr", Pr);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("Tel", Tel);
                cmd.Parameters.AddWithValue("Cell", Cell);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void MakeReservation(DateTime ResDate, DateTime Start, DateTime EndRes, double Deposit, double Price, string Details, int IdCustomer, int IdRoom)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Reservations VALUES(@ResDate,@Start,@EndRes,@Deposit,@Price,@Details,@IdCustomer,@IdRoom)";
                cmd.Parameters.AddWithValue("ResDate", ResDate);
                cmd.Parameters.AddWithValue("Start", Start);
                cmd.Parameters.AddWithValue("EndRes", EndRes);
                cmd.Parameters.AddWithValue("Deposit", Deposit);
                cmd.Parameters.AddWithValue("Price", Price);
                cmd.Parameters.AddWithValue("Details", Details);
                cmd.Parameters.AddWithValue("IdCustomer", IdCustomer);
                cmd.Parameters.AddWithValue("IdRoom", IdRoom);


                int IsOk = cmd.ExecuteNonQuery();

            }

            catch
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static Reservation GetLastReservation()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Reservations ORDER BY IdReservation DESC", conn);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                Reservation r = new Reservation();
                while (sqlDataReader.Read())
                {

                    r.IdReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    r.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    r.Start = Convert.ToDateTime(sqlDataReader["Start"]);
                    r.EndRes = Convert.ToDateTime(sqlDataReader["EndRes"]);
                    r.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    r.Price = Convert.ToDouble(sqlDataReader["Price"]);
                    r.Details = sqlDataReader["Details"].ToString();
                    r.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    r.IdRooms = Convert.ToInt32(sqlDataReader["IdRooms"]);

                }

                return r;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static void ModifyReservation(int id, DateTime Start, DateTime EndRes, double Deposit, double Price, string Details)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Reservations SET Start=@Start,EndRes=@EndRes,Deposit=@Deposit,Price=@Price where IdReservation=@id";
            cmd.Parameters.AddWithValue("Start", Start);
            cmd.Parameters.AddWithValue("EndRes", EndRes);
            cmd.Parameters.AddWithValue("Deposit", Deposit);
            cmd.Parameters.AddWithValue("Price", Price);
            cmd.Parameters.AddWithValue("id", id);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static CheckOut GetCheckOutInfo(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Reservations.IdReservation,ResDate,Start,EndRes,Deposit,Price,Details,IdCustomer,IdRoom, Rooms.RoomNumber,Rooms.Type, Services.RoomBr, Services.MiniBar, Services.Internet,Services.AddBed, Services.Cradle FROM Reservations Inner Join Rooms on Reservations.IdRooms = Rooms.IdRoom inner join Services on Reservations.IdReservation = Services.IdReservation where Reservations.IdReservation = @id", conn);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                CheckOut c = new CheckOut();
                while (sqlDataReader.Read())
                {

                    c.IdReservation = Convert.ToInt32(sqlDataReader["Idreservation"]);
                    c.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    c.Start = Convert.ToDateTime(sqlDataReader["Start"]);
                    c.EndRes = Convert.ToDateTime(sqlDataReader["EndRes"]);
                    c.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    c.Price = Convert.ToDouble(sqlDataReader["Price"]);
                    c.Details = sqlDataReader["Details"].ToString();
                    c.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    c.IdRoom = Convert.ToInt32(sqlDataReader["IdRoom"]);
                    c.RoomNumber = Convert.ToInt32(sqlDataReader["RoomNumber"]);
                    c.Type = sqlDataReader["Type"].ToString();
                    c.RoomBr = Convert.ToBoolean(sqlDataReader["RoomBr"]);
                    c.MiniBar = Convert.ToBoolean(sqlDataReader["MiniBar"]);
                    c.Internet = Convert.ToBoolean(sqlDataReader["Internet"]);
                    c.AddBed = Convert.ToBoolean(sqlDataReader["AddBed"]);
                    c.Cradle = Convert.ToBoolean(sqlDataReader["Cradle"]);

                }

                return c;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static List<QueryCf> GetReservationByCf(string cf)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("Select IdReservation, ResDate, Deposit, Customers.Name, Customers.Surname, Customers.Cf from Reservations Inner join Customers on Reservations.IdCustomer = Customers.IdCustomer Where Cf = @cf", conn);
                cmd.Parameters.AddWithValue("cf", cf);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();
                List<QueryCf> list = new List<QueryCf>();
                while (sqlDataReader.Read())
                {
                    QueryCf q = new QueryCf();
                    q.IdReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    q.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    q.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    q.Name = sqlDataReader["Name"].ToString();
                    q.Surname = sqlDataReader["Surname"].ToString();
                    q.Cf = sqlDataReader["Cf"].ToString();
                    list.Add(q);
                }

                return list;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static List<Reservation> GetQueryRes()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Reservations Where Details='Pensione Completa'", conn);
                SqlDataReader sqlDataReader;

                conn.Open();
                sqlDataReader = cmd.ExecuteReader();

                List<Reservation> list = new List<Reservation>();
                while (sqlDataReader.Read())
                {
                    Reservation r = new Reservation();
                    r.IdReservation = Convert.ToInt32(sqlDataReader["IdReservation"]);
                    r.ResDate = Convert.ToDateTime(sqlDataReader["ResDate"]);
                    r.Start = Convert.ToDateTime(sqlDataReader["Start"]);
                    r.EndRes = Convert.ToDateTime(sqlDataReader["EndRes"]);
                    r.Deposit = Convert.ToDouble(sqlDataReader["Deposit"]);
                    r.Price = Convert.ToDouble(sqlDataReader["Price"]);
                    r.Details = sqlDataReader["Details"].ToString();
                    r.IdCustomer = Convert.ToInt32(sqlDataReader["IdCustomer"]);
                    r.IdRooms = Convert.ToInt32(sqlDataReader["IdRooms"]);
                    list.Add(r);
                }

                return list;
            }
            catch { }
            finally
            {
                conn.Close();

            }
            return null;
        }
        public static void SetResPrice(double Price, int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Reservations SET Price=@Price where IdReservation=@id";
            cmd.Parameters.AddWithValue("Price", Price);
            cmd.Parameters.AddWithValue("Id", id);
            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}