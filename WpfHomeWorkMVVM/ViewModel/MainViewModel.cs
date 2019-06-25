using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfHomeWorkMVVM.Helpes;
using WpfHomeWorkMVVM.Model;

namespace WpfHomeWorkMVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<ImageInfo> ImageInfos { get; set; }
        ImageInfo selectedImage;
        RelayCommand addImage;
        ICommand deleteImage;

        public MainViewModel()
        {
            ImageInfos = new ObservableCollection<ImageInfo>();
        }

        public ImageInfo SelectedImage { get => selectedImage; set
            {
                if (selectedImage != value)
                {
                    selectedImage = value;
                    OnPropertyChanged(nameof(SelectedImage));
                }
            } }
        private void DeleteImage(object obj)
        {
            if (obj != null && obj is ImageInfo)
            {
                ImageInfo image = obj as ImageInfo;
                ImageInfos.Remove(image);
            }
        }
        private bool CanDeleteImage(object obj)
        {
            return ImageInfos.Count > 0;
        }
        private void AddImage(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.bmp;*.jpeg;*jpg;*.ico";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                Uri uri = new Uri(openFileDialog.FileName);
                BitmapImage bitmapImage = new BitmapImage(uri);
                ImageInfo imageInfo = new ImageInfo
                {
                    FileName = fileInfo.Name,
                    FilePath = openFileDialog.FileName,
                    PictureImage = bitmapImage,
                    Size = $"{((double)fileInfo.Length / (1024 * 1024)).ToString("0.00")} MB"
                };
                ImageInfos.Add(imageInfo);
            }          
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addImage ?? (addImage = new RelayCommand (AddImage));
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                return deleteImage ?? (deleteImage = new RelayCommand(DeleteImage, CanDeleteImage));                  
            }
        }
    }
}
