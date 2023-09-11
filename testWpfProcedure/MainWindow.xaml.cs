using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using testWpfProcedure.Repo.Data;
using testWpfProcedure.Repo;
using DevExpress.Xpf.Editors;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Controls;

namespace testWpfProcedure
{


    public  class MyViewModel : INotifyPropertyChanged
    {
        private string docType;
        private string docCo;

        public string DocType
        {
            get { return docType; }
            set
            {
                if (docType != value)
                {
                    docType = value;
                    OnPropertyChanged(nameof(DocType));
                }
            }
        }

        public string DocCo
        {
            get { return docCo; }
            set
            {
                if (docCo != value)
                {
                    docCo = value;
                    OnPropertyChanged(nameof(DocCo));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    public partial class MainWindow : Window
    {
        private readonly IUserData userData;
        private MyViewModel viewModel;
        Binding binding = new Binding();
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MyViewModel();
            DataContext = viewModel;

            // Qwe();

            //using (var dbContext = new DataTestContext())
            //{

            //    List<User> users = dbContext.Users.ToList();

            //}


          

            binding.ElementName = "myTextBox"; // элемент-источник
            binding.Path = new PropertyPath("Text"); // свойство элемента-источника
            myTextBlock.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника

       

        }




        private void Doc_Type_EditValueChanged_1(object sender, EditValueChangedEventArgs e)
        {

        }



      


        private string userInput = "";
        private void FilterTextEdit_KeyDown1(object sender, KeyEventArgs e)
        {





            var textEdit = sender as TextEdit;
            if (textEdit != null)
            {


                string newText = (sender as TextEdit)?.Text + e.Key.ToString();
                if (IsNumericKey(e.Key))
                {
                    // Если нажата цифровая клавиша, добавляем символ
                    var digit = GetDigitFromKey(e.Key);
                 
                }

                 if (e.Key == Key.Back && viewModel.DocType.Length > 0)
                {
                    // Если нажата клавиша Backspace и есть символы для удаления
                    viewModel.DocType = viewModel.DocType.Substring(0, viewModel.DocType.Length - 0);
                }



                // Перемещаем каретку в конец текста
                  textEdit.CaretIndex = viewModel.DocType.Length;

                // Помечаем событие как обработанное
                e.Handled = true;


            }

        }



        private bool IsNumericKey(Key key)
        {
            // Проверка, является ли клавиша цифровой
            return key >= Key.D0 && key <= Key.D9;
        }

        private string GetDigitFromKey(Key key)
        {
            // Получение символа из цифровой клавиши
            return ((int)key - (int)Key.D0).ToString();
        }






        private void FilterTextEdit_KeyDown2(object sender, KeyEventArgs e)
        {

          

            string newText = (sender as TextEdit)?.Text + e.Key.ToString(); //first symbol

            if (IsNumericKey(e.Key))
            {
                // Если нажата цифровая клавиша, добавляем символ
                var digit = GetDigitFromKey(e.Key);
                viewModel.DocCo += digit;
            }
            if ((e.Key == Key.Back      ||
                e.Key == Key.Right      || 
                e.Key == Key.Left ) && viewModel.DocCo.Length > 0)
            {
                // Если нажата клавиша Backspace и есть символы для удаления
                viewModel.DocCo = viewModel.DocCo.Substring(0, viewModel.DocCo.Length - 1);
            }
            else
            {
                viewModel.DocCo = newText;
                TextEdit filterTextEditDoc_co = sender as TextEdit;

            }


            if (e.Key == Key.Enter)
            {

             
                
            }



        }






        private void FilterTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            TextEdit filterTextEditDoc_Type = sender as TextEdit;

            viewModel.DocType = filterTextEditDoc_Type.Text;



           

            if (e.Key == Key.Enter)
            {






                //if (sender is TextEdit filterTextEdit)
                //{
                //    string resultText = filterTextEdit.Text;

                //    if (filterTextEdit.Name == "Doc_Type")
                //    {
                //        docTypeFilled = !string.IsNullOrWhiteSpace(resultText);
                //    }
                //    else if (filterTextEdit.Name == "Doc_Co")
                //    {
                //        docCoFilled = !string.IsNullOrWhiteSpace(resultText);
                //    }

                //    if (docTypeFilled && docCoFilled)
                //    {
                //        // Оба поля заполнены, выполните проверку
                //        // Далее можно выполнить необходимую логику проверки
                //    }
                //}

















                string columnName = "Doc_Type"; // Имя элемента, который вы хотите найти
                string columnName2 = "Doc_Co"; // Имя элемента, который вы хотите найти
                DataTemplate columnHeaderTemplate = Resources["Doc_TypeHeaderTemplate"] as DataTemplate;



                FrameworkElement textEdit = FindElementInTemplate(columnHeaderTemplate.LoadContent() as FrameworkElement, columnName) as FrameworkElement;

                if (textEdit != null)
                {
                    // Вы можете работать с найденным элементом TextEdit здесь
                    if (textEdit is TextEdit)
                    {
                        TextEdit foundTextEdit = textEdit as TextEdit;

                        var result = foundTextEdit.Text;

                    }
                }



                DataTemplate columnHeaderTemplate2 = Resources["Doc_CoHeaderTemplate"] as DataTemplate;
                FrameworkElement textEdit2 = FindElementInTemplate(columnHeaderTemplate2.LoadContent() as FrameworkElement, columnName2) as FrameworkElement;
                if (textEdit2 != null)
                {
                    // Вы можете работать с найденным элементом TextEdit здесь
                    if (textEdit2 is TextEdit)
                    {
                        TextEdit foundTextEdit2 = textEdit2 as TextEdit;

                        var result2 = foundTextEdit2.Text;

                    }
                }






                //TextEdit filterTextEdit = sender as TextEdit;


                //var resultxt = filterTextEdit.Text;

            }



        }




        private bool docTypeFilled = false; // Флаг для отслеживания заполнения поля Doc_Type
        private bool docCoFilled = false; // Флаг для отслеживания заполнения поля Doc_Co



        private void FilterTextEdit_LostFocus(object sender, RoutedEventArgs e)

        {
            if (sender is TextEdit textEdit)
            {
                string text = textEdit.Text; // Получение актуального текста из TextEdit
                                             // Далее можно обработать текст
            }
        }




        private FrameworkElement FindElementInTemplate(FrameworkElement parent, string elementName)
        {
            if (parent != null)
            {
                if (parent.Name == elementName)
                {
                    return parent;
                }

                int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

                for (int i = 0; i < childrenCount; i++)
                {
                    FrameworkElement child = VisualTreeHelper.GetChild(parent, i) as FrameworkElement;
                    FrameworkElement result = FindElementInTemplate(child, elementName);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
































        //string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //DatabaseHelper dbHelper = new DatabaseHelper(connectionString);

        //string storedProcedureName = "dbo.spUser_GetAll";
        //SqlParameter[] parameters = new SqlParameter[] { };

        //DataTable result = await dbHelper.GetDataFromStoredProcedureAsync(storedProcedureName, parameters);



        public void Qwe()
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            int userId = 2; //  нужный идентификатор пользователя.
            User user = dbHelper.GetUserById(userId);
            List<User> users = dbHelper.GetUsersByFirstName("qqq");


        }

        private void backspace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {

                string newText = (sender as TextEdit)?.Text + e.Key;
                // Пользователь нажал клавишу Backspace, текст будет удален
                // Вы можете выполнить дополнительные действия здесь, если нужно
            }
        }

       
    }
}
