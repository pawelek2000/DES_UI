using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM.Core;
using WpfMVVM.MVVM.Model;

namespace WpfMVVM.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public RelayCommand SzyfrujCommand { get; set; }
        public RelayCommand OdszyfrujCommand { get; set; }
        public DES MojDES { get; set; }
        public MainViewModel()
        {
            MojDES = new DES();

            SzyfrujCommand = new RelayCommand(o =>
            {
                var output = MojDES.EncryptText(TextBoxValue, klucz1);
                Zawartosc = MojDES.toStringBitArray(output);
            });
            OdszyfrujCommand = new RelayCommand(o => 
            {
                var input = MojDES.StringToBitArray(TextBoxValue2);
                var output = MojDES.DecryptText(input, klucz2);
                Zawartosc2 = output;
            });

        }

        public string Zawartosc
        {
            get { return _zawartosc; }
            set
            {
                _zawartosc = value;
                OnPropertyChanged();
            }
        }
        private string _zawartosc;

        public string TextBoxValue
        {
            get { return _textBoxValue; }
            set
            {
                _textBoxValue = value;
                OnPropertyChanged();
            }
        }
        private string _textBoxValue;



        public string Zawartosc2
        {
            get { return _zawartosc2; }
            set
            {
                _zawartosc2 = value;
                OnPropertyChanged();
            }
        }
        private string _zawartosc2;

        public string TextBoxValue2
        {
            get { return _textBoxValue2; }
            set
            {
                _textBoxValue2 = value;
                OnPropertyChanged();
            }
        }
        private string _textBoxValue2;

        //tutaj

        public string klucz1
        {
            get { return _klucz1; }
            set
            {
                _klucz1 = value;
                OnPropertyChanged();
            }
        }
        private string _klucz1;

        public string klucz2
        {
            get { return _klucz2; }
            set
            {
                _klucz2 = value;
                OnPropertyChanged();
            }
        }
        private string _klucz2;

        //tutaj 2

    
    }
}
