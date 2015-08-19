using Microsoft.Practices.Prism.Mvvm;

namespace PrismDemo.Models
{
    class MainModel: BindableBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
