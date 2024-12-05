using System;
using System.IO;
using System.Windows;
using System.Reflection;

namespace MultiNationalsSample
{
    public class MainWindowViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private static readonly string languagesResourceScheme = @"pack://application:,,,/MultiNationalsSample;component/Languages";

        public static System.Collections.ObjectModel.ObservableCollection<Country> Countries => new(Enum.GetValues(typeof(Country)).Cast<Country>());

        public Country CurrentCountry
        {
            get => currentCountry;
            set
            {
                SetProperty(ref currentCountry, value);
                ChangeLanguage(value);
            }
        }
        private Country currentCountry = Country.KR;

        public string? Amount
        {
            get => amount;
            set
            {
                SetProperty(ref amount, value);
                OnPropertyChanged(nameof(EnteredAmount));
            }
        }
        private string? amount;

        public double? EnteredAmount => double.TryParse(Amount, out double parsedAmount) ? parsedAmount : null;

        public MainWindowViewModel()
        {
            Amount = "1000.10"; // Sample code
        }

        private static void ChangeLanguage(Country country)
        {
            try
            {
                if (typeof(Country).GetField(country.ToString())?.GetCustomAttribute(typeof(CountryAttribute)) is not CountryAttribute attribute)
                    return;

                var currentMergedDictionaries = App.Current.Resources.MergedDictionaries;

                var languageResourceDictionary = new ResourceDictionary()
                {
                    Source = new Uri(Path.Combine(languagesResourceScheme, $"{attribute.Language}.xaml"), UriKind.RelativeOrAbsolute)
                };

                var mergedLanguageResources = new List<ResourceDictionary>();
                foreach (var resourceDictionary in currentMergedDictionaries)
                {
                    if (resourceDictionary?.Source?.OriginalString?.Contains(languagesResourceScheme, StringComparison.OrdinalIgnoreCase) != true)
                        continue;

                    mergedLanguageResources.Add(resourceDictionary);
                }

                foreach (var resourceDictionary in mergedLanguageResources)
                    currentMergedDictionaries.Remove(resourceDictionary);

                currentMergedDictionaries.Add(languageResourceDictionary);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Language resource replacement failed. {ex.StackTrace} >> {ex.Message}");
            }
        }
    }
}
