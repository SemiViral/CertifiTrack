#region

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using CertifiTrack.Model;
using CertifiTrack.Properties;
using Microsoft.Win32;

#endregion

namespace CertifiTrack.ViewModel {
    internal class MainViewModel {
        private readonly ObservableCollection<DeathCertificate> certificates = new ObservableCollection<DeathCertificate>();

        private readonly SortDescription dateOfDeathSortDescription = new SortDescription("DateOfDeath",
            ListSortDirection.Descending);

        private readonly bool loaded;

        private readonly SortDescription locationSwitchSortDescription = new SortDescription("LocationSwitch",
            ListSortDirection.Ascending);

        private readonly SortDescription nameSortDescription = new SortDescription("Name",
            ListSortDirection.Descending);

        private DateTime lastAccessed;

        public MainViewModel() {
            if (loaded ||
                (bool)
                    DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty,
                        typeof(DependencyObject)).Metadata.DefaultValue) return;
            loaded = true;

            DeathCertificateView = new CollectionViewSource {
                Source = certificates,
                SortDescriptions = {
                    locationSwitchSortDescription,
                    dateOfDeathSortDescription,
                    nameSortDescription
                }
            };

            LoadCertificatesDialouge();
            LoadCertificates();

            lastAccessed = DateTime.Now;

            BackgroundWorker fileChangedCheckerWorker = new BackgroundWorker();
            fileChangedCheckerWorker.DoWork += FileChangedChecker;
            fileChangedCheckerWorker.RunWorkerAsync();
        }

        public string FilePath { get; private set; }

        public CollectionViewSource DeathCertificateView { get; }

        private void FileChangedChecker(object sender, DoWorkEventArgs e) {
            while (Application.Current != null) {
                Thread.Sleep(2000);

                if (File.GetLastWriteTime(Settings.Default.statusFile).Ticks <= lastAccessed.Ticks) continue;

                DispatchAction(() => certificates.Remove(cert => true));

                LoadCertificates();
                lastAccessed = DateTime.Now;
            }
        }

        private void LoadCertificates() {
            foreach (DeathCertificate cert in ExcelData.GetCertificates(Settings.Default.statusFile)) {
                DispatchAction(() => certificates.Add(cert));
            }
        }

        private void LoadCertificatesDialouge() {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() != true) return;

            FilePath = open.FileName;
            Settings.Default.statusFile = FilePath;
            Settings.Default.Save();
        }

        private static void DispatchAction(Action action) {
            if (Application.Current == null) return;

            if (Application.Current.Dispatcher.CheckAccess()) action?.Invoke();
            else Application.Current.Dispatcher?.Invoke(DispatcherPriority.Normal, action);
        }
    }

    public static class ExtensionMethods {
        public static int Remove<T>(this ObservableCollection<T> collection, Func<T, bool> condition) {
            List<T> itemsToRemove = collection.Where(condition).ToList();

            foreach (T itemToRemove in itemsToRemove) {
                collection.Remove(itemToRemove);
            }

            return itemsToRemove.Count;
        }
    }
}