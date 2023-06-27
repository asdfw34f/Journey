using Journey.MVVM.Base;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Journey.MVVM.ViewModels.Controls
{
    class PostViewModel: NotifyPropertyChanged
    {
        private string _Name = "Иван Иванов";
        private string _Description = "Описание поста";
        private string _Title = "Заголовок";
        private DateTime _Date = DateTime.Now.Date;
        private Image _Image;
        private Visibility _VisImage = Visibility.Collapsed;
 
        public string Name
        {
            get => _Description;
            set=>Set(ref _Description, value);
        }

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        public DateTime Date
        {
            get => _Date;
            set => Set(ref _Date, value);
        }

        public Image Image
        {
            get => _Image;
            set => Set(ref _Image, value);
        }

        public Visibility VisImage
        {
            get => _VisImage;
            set => Set(ref _VisImage, value);
        }
    }
}