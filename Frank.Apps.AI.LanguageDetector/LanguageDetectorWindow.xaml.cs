using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Frank.Apps.AI.LanguageDetector
{
    public partial class LanguageDetectorWindow : Window
    {
        private readonly Libraries.AI.LanguageDetection.LanguageDetector _languageDetector;

        public LanguageDetectorWindow()
        {
            _languageDetector = new Libraries.AI.LanguageDetection.LanguageDetector();
            _languageDetector.AddAllLanguages();
            InitializeComponent();
        }

        private void InputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputTextBox.Text))
            {
                LanguageLabel.Content = "?";
                ProbabilityLabel.Content = "NaN";
            }
            else
            {
                var languages = _languageDetector.DetectAll(InputTextBox.Text);
                var language = languages.OrderByDescending(x => x.Probability).FirstOrDefault();
                if (language != null && language.Probability > 50)
                {
                    LanguageLabel.Content = language.Language;
                    ProbabilityLabel.Content = language.Probability;
                }
                else
                {
                    LanguageLabel.Content = "?";
                    ProbabilityLabel.Content = "NaN";
                }
            }
        }
    }
}
