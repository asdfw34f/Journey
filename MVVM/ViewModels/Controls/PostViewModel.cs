// This is a personal academic project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using Journey.Data.GetData;
using Journey.MVVM.Base;
using Journey.MVVM.Models.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace Journey.MVVM.ViewModels.Controls
{
    internal class PostViewModel : NotifyPropertyChanged
    {
        private Posts? _post;
        private string _Name = "Иван Иванов";
        private string _Description = "Описание поста";
        private string _Title = "Заголовок";
        private DateTime _Date = DateTime.Now.Date;
        private byte[]? _Image;
        private Visibility _VisImage = Visibility.Collapsed;

        public string Description
        {
            get => _Description;
            set => Set(ref _Description, value);
        }

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
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

        public byte[]? Image
        {
            get => _Image;
            set => Set(ref _Image, value);
        }

        public Visibility VisImage
        {
            get => _VisImage;
            set => Set(ref _VisImage, value);
        }

        ICommand LoadedCommand { get; }
        private bool CanLoaded(object p) => true;
        private void OnLoaded(object p)
        {
            Posts _post = PostBank.GetNextPost();

            Image = _post.Media;
            Title = _post.Title;
            Description = _post.Description;
            Date = (DateTime)_post.Created;
            Name = _post.Name;

        }

        public PostViewModel()
        {

        }
    }
}