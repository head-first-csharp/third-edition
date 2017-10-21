using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcuseManagerApp
{
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.Serialization;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.Storage.FileProperties;
    using Windows.Storage.Pickers;
    using Windows.UI.Popups;

    class ExcuseManager : INotifyPropertyChanged
    {
        public Excuse CurrentExcuse { get; set; }

        public string FileDate { get; private set; }

        private Random random = new Random();

        private IStorageFolder excuseFolder = null;

        private IStorageFile excuseFile;

        public ExcuseManager()
        {
            NewExcuseAsync();
        }


        async public void NewExcuseAsync()
        {
            CurrentExcuse = new Excuse();
            excuseFile = null;
            OnPropertyChanged("CurrentExcuse");
            await UpdateFileDateAsync();
        }


        public async Task<bool> ChooseNewFolderAsync()
        {
            FolderPicker folderPicker = new FolderPicker()
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            folderPicker.FileTypeFilter.Add(".xml");
            IStorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                excuseFolder = folder;
                return true;
            }
            MessageDialog warningDialog = new MessageDialog("No excuse folder chosen");
            await warningDialog.ShowAsync();
            return false;
        }

        public async void OpenExcuseAsync()
        {
            FileOpenPicker picker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                CommitButtonText = "Open Excuse File"
            };
            picker.FileTypeFilter.Add(".xml");
            excuseFile = await picker.PickSingleFileAsync();
            if (excuseFile != null)
                await ReadExcuseAsync();
        }

        public async void OpenRandomExcuseAsync()
        {
            IReadOnlyList<IStorageFile> files = await excuseFolder.GetFilesAsync();
            if (files.Count() == 0)
            {
                await new MessageDialog("The current excuse folder is empty.").ShowAsync();
                return;
            }
            excuseFile = files[random.Next(0, files.Count())];
            await ReadExcuseAsync();
        }

        public async Task UpdateFileDateAsync()
        {
            if (excuseFile != null)
            {
                BasicProperties basicProperties = await excuseFile.GetBasicPropertiesAsync();
                FileDate = basicProperties.DateModified.ToString();
            }
            else
                FileDate = "(no file loaded)";
            OnPropertyChanged("FileDate");
        }

        public async void SaveCurrentExcuseAsync()
        {
            if (CurrentExcuse == null)
            {
                await new MessageDialog("No excuse loaded").ShowAsync();
                return;
            }
            if (String.IsNullOrEmpty(CurrentExcuse.Description))
            {
                await new MessageDialog("Current excuse does not have a description").ShowAsync();
                return;
            }
            if (excuseFile == null)
                excuseFile = await excuseFolder.CreateFileAsync(CurrentExcuse.Description + ".xml",
                                   CreationCollisionOption.ReplaceExisting);

            await WriteExcuseAsync();
        }

        public async Task ReadExcuseAsync()
        {
            try
            {
                using (IRandomAccessStream stream =
                        await excuseFile.OpenAsync(FileAccessMode.Read))
                using (Stream inputStream = stream.AsStreamForRead())
                {
                    DataContractSerializer serializer
                                = new DataContractSerializer(typeof(Excuse));
                    CurrentExcuse = serializer.ReadObject(inputStream) as Excuse;
                }

                await new MessageDialog("Excuse read from to "
                                            + excuseFile.Name).ShowAsync();
                await UpdateFileDateAsync();
            }
            catch (SerializationException)
            {
                new MessageDialog("Unable to read " + excuseFile.Name).ShowAsync();
                NewExcuseAsync();
            }
            finally
            {
                OnPropertyChanged("CurrentExcuse");
            }
        }

        public async Task WriteExcuseAsync()
        {
            using (IRandomAccessStream stream =
                    await excuseFile.OpenAsync(FileAccessMode.ReadWrite))
            using (Stream outputStream = stream.AsStreamForWrite())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Excuse));
                serializer.WriteObject(outputStream, CurrentExcuse);
            }
            await new MessageDialog("Excuse written to " + excuseFile.Name).ShowAsync();
            await UpdateFileDateAsync();
        }

        public async void SaveCurrentExcuseAsAsync()
        {
            FileSavePicker picker = new FileSavePicker
            {
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                SuggestedFileName = CurrentExcuse.Description,
                CommitButtonText = "Save Excuse File"
            };
            picker.FileTypeChoices.Add("XML File", new List<string>() { ".xml" });
            IStorageFile newExcuseFile = await picker.PickSaveFileAsync();
            if (newExcuseFile != null)
            {
                excuseFile = newExcuseFile;
                await WriteExcuseAsync();
            }
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
