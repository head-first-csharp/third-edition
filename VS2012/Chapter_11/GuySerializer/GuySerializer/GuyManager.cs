using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuySerializer
{
    using System.ComponentModel;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using System.IO;
    using System.Runtime.Serialization;

    class GuyManager : INotifyPropertyChanged
    {
        private IStorageFile latestGuyFile;
        public IStorageFile LatestGuyFile { get { return latestGuyFile; } }

        private Guy joe = new Guy("Joe", 37, 176.22M);
        public Guy Joe
        {
            get { return joe; }
        }

        private Guy bob = new Guy("Bob", 45, 4.68M);
        public Guy Bob
        {
            get { return bob; }
        }

        private Guy ed = new Guy("Ed", 43, 37.51M);
        public Guy Ed
        {
            get { return ed; }
        }

        public Guy NewGuy { get; private set; }

        public string Path { get; set; }


        public async void ReadGuyAsync()
        {
            if (String.IsNullOrEmpty(Path))
                return;
            latestGuyFile = await StorageFile.GetFileFromPathAsync(Path);

            using (IRandomAccessStream stream =
                        await latestGuyFile.OpenAsync(FileAccessMode.Read))
            using (Stream inputStream = stream.AsStreamForRead())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                NewGuy = serializer.ReadObject(inputStream) as Guy;
            }
            OnPropertyChanged("NewGuy");
            OnPropertyChanged("LatestGuyFile");
        }

        public async void WriteGuyAsync(Guy guyToWrite)
        {
            IStorageFolder guysFolder =
                await KnownFolders.DocumentsLibrary.CreateFolderAsync("Guys",
                                                    CreationCollisionOption.OpenIfExists);
            latestGuyFile =
                    await guysFolder.CreateFileAsync(guyToWrite.Name + ".xml",
                                            CreationCollisionOption.ReplaceExisting);

            using (IRandomAccessStream stream =
                                await latestGuyFile.OpenAsync(FileAccessMode.ReadWrite))
            using (Stream outputStream = stream.AsStreamForWrite())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
                serializer.WriteObject(outputStream, guyToWrite);
            }

            Path = latestGuyFile.Path;

            OnPropertyChanged("Path");
            OnPropertyChanged("LatestGuyFile");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
