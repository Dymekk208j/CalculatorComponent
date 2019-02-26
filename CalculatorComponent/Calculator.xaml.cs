using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace CalculatorComponent
{
    public partial class Calculator
    {
        private enum OperationType
        {
            [Description("+")]
            Add,
            [Description("-")]
            Sub,
            [Description("*")]
            Multi,
            [Description("/")]
            Div,
            [Description("√")]
            Sqr
        }

        private string _txtOperation = "";

        private string TxtNumber { get; set; }

        private double? _firstNumber;

        private double? _secondNumber;

        public double? Result { get; set; }

        private OperationType? _selectedOperation;

        public Calculator()
        {
            InitializeComponent();
        }

        private void UpdateTextControls()
        {
            TextBoxResult.Text = TxtNumber;
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            TxtNumber += "0";
            UpdateTextControls();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TxtNumber += "1";
            UpdateTextControls();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TxtNumber += "2";
            UpdateTextControls();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TxtNumber += "3";
            UpdateTextControls();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TxtNumber += "4";
            UpdateTextControls();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TxtNumber += "5";
            UpdateTextControls();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TxtNumber += "6";
            UpdateTextControls();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            TxtNumber += "7";
            UpdateTextControls();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            TxtNumber += "8";
            UpdateTextControls();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            TxtNumber += "9";
            UpdateTextControls();
        }
        
        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (TxtNumber.Contains(",")) return;
            TxtNumber += ",";
            UpdateTextControls();
        }

        private void Button_Click_Sign(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNumber)) return;

            TxtNumber = TxtNumber.StartsWith("-") ? TxtNumber.Substring(1) : '-' + TxtNumber;
            UpdateTextControls();
        }

        private void Button_Click_Remove_Number(object sender, RoutedEventArgs e)
        {
            TxtNumber = "";
            UpdateTextControls();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Operation(OperationType.Add);
        }

        private void Update_Operation_Text()
        {
            _txtOperation = "";

            if (_firstNumber != null)
            {
                _txtOperation += _firstNumber.ToString();
            }

            if (_selectedOperation != null)
            {
                _txtOperation += ' ' + GetEnumDescription(_selectedOperation) + ' ';
            }

            if (_secondNumber != null)
            {
                _txtOperation += _secondNumber < 0 ? $"({_secondNumber.ToString()})" : _secondNumber.ToString(); 
            }

            if (Result != null)
            {
                _txtOperation += " = " + Result;
            }

            LblOperation.Content = _txtOperation;
        }
        
        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        private void Button_Click_Sub(object sender, RoutedEventArgs e)
        {
            Operation(OperationType.Sub);
        }

        private void Button_Click_Multi(object sender, RoutedEventArgs e)
        {
            Operation(OperationType.Multi);
        }

        private void Button_Click_Div(object sender, RoutedEventArgs e)
        {
           
            Operation(OperationType.Div);
        }

        private void Operation(OperationType type)
        {
           if (_firstNumber != null && _selectedOperation != null )
            {
                if (!string.IsNullOrEmpty(TxtNumber))  GetResult();
                _firstNumber = Result;
                _secondNumber = null;
                Result = null;                
                TxtNumber = "";
               
            }

            if (TxtNumber.EndsWith(",")) TxtNumber += "0";

            if (_selectedOperation == null)
            {
                _firstNumber = double.Parse(TxtNumber);
                TxtNumber = "";
            }

            _selectedOperation = type;

            Update_Operation_Text();
            UpdateTextControls();
        }

        private void GetResult()
        {
            if (TxtNumber.EndsWith(",")) TxtNumber += "0";
            if (string.IsNullOrEmpty(TxtNumber)) TxtNumber = "0";
            _secondNumber = double.Parse(TxtNumber);
            TxtNumber = "";

            switch (_selectedOperation)
            {
                case OperationType.Add:
                    Result = _firstNumber + _secondNumber;
                    break;
                case OperationType.Div:
                    Result = _firstNumber / _secondNumber;
                    break;
                case OperationType.Multi:
                    Result = _firstNumber * _secondNumber;
                    break;
                case OperationType.Sqr:
                    break;
                case OperationType.Sub:
                    Result = _firstNumber - _secondNumber;

                    break;
            }

            Update_Operation_Text();
            UpdateTextControls();
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            GetResult();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            _firstNumber = null;
            _secondNumber = null;
            Result = null;
            _selectedOperation = null;
            TxtNumber = "";

            Update_Operation_Text();
            UpdateTextControls();
        }
    }
}
