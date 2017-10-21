using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmysComics
{
    using Windows.Storage;
    class SuspensionManager
    {
        public static string CurrentQuery { get; set; }

        private const string filename = "_sessionState.txt";

        static async public Task SaveAsync()
        {
            if (String.IsNullOrEmpty(CurrentQuery))
                CurrentQuery = String.Empty;
            IStorageFile storageFile =
                   await ApplicationData.Current.LocalFolder.CreateFileAsync(
                                filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, CurrentQuery);
        }

        static async public Task RestoreAsync()
        {
            IStorageFile storageFile =
                   await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            CurrentQuery = await FileIO.ReadTextAsync(storageFile);
        }
    }
}
