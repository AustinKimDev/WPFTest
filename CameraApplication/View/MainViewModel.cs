using CameraApplication.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CameraApplication
{
    internal class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            InitalizeCommands();
        }

        private void InitalizeCommands() {
            TempCommand = new RelayCommand(Temp);
        }

        public RelayCommand TempCommand { get => GetValue<RelayCommand>(); set => SetValue(value); }

        private void Temp(object obj)
        {
            MessageBox.Show("귀엽고 깜찍한 버튼");
        }
    }
}
