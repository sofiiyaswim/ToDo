using System;
using System.Collections.Generic;
using System.Printing;
using System.Text;
using System.Windows.Input;
using ToDo.Command;
using ToDo.Model;

namespace ToDo.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private List<string> listItems = new List<string>();
        public List<string> ListItems
        {
            get => listItems;
            set
            {
               
                listItems = value;
                NotifyPropertyChanged(nameof(ListItems));

            }
        }

        public ICommand AddButton { get; set; }

        private bool CanSelectedItemCommandExecute(object p) => true;
        private void OnSelectedItemCommand(object p)
        {
            ListBoxLeft listBoxLeft = new ListBoxLeft();
            listBoxLeft.listItems.Add("Новый список");
            listBoxLeft.Save();
        }

        public MainWindowViewModel()
        {
            AddButton = new LambdaCommand(OnSelectedItemCommand, CanSelectedItemCommandExecute);

            ListBoxLeft listBoxLeft = new ListBoxLeft();
            ListItems = listBoxLeft.listItems;
            NotifyPropertyChanged();
        }
    }
}
