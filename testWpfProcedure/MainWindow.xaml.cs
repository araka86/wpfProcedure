using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using testWpfProcedure.Repo.Data;
using System.Configuration;
using testWpfProcedure.Repo;
using testWpfProcedure.Repo.DataAccess;

namespace testWpfProcedure
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserData userData;

        public MainWindow()
        {
            InitializeComponent();

            Qwe();

            using (var dbContext = new DataTestContext())
            {

                List<User> users = dbContext.Users.ToList();

            }

           
        }



  


        //string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

        //string storedProcedureName = "dbo.spUser_GetAll";
        //SqlParameter[] parameters = new SqlParameter[] { };

        //DataTable result = await dbHelper.GetDataFromStoredProcedureAsync(storedProcedureName, parameters);



        public  void Qwe()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            int userId = 2; //  нужный идентификатор пользователя.
            User user = dbHelper.GetUserById(userId);
            List<User> users = dbHelper.GetUsersByFirstName("qqq");

           
        }
    }
}
