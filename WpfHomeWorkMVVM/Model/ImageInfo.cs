using System.Windows.Media.Imaging;
using WpfHomeWorkMVVM.Helpes;

namespace WpfHomeWorkMVVM.Model
{
    public class ImageInfo : ObservableObject
    {
        string filePath, fileName, size;       
        BitmapImage pictureImage;  
        public string FilePath { get => filePath; set {
                if (filePath != value)
                {
                    filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }
        public string FileName { get => fileName; set {
                if (fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        public string Size { get => size; set {
                if (size != value)
                {
                    size = value;
                    OnPropertyChanged("Size");
                }
            }
        }
        public BitmapImage PictureImage { get => pictureImage; set {
                if (pictureImage != value)
                {
                    pictureImage = value;
                    OnPropertyChanged("PictureImage");
                }
            }
        }
    }
}
