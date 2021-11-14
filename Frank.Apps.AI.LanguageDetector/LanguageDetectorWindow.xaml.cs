using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Frank.Libraries.AI.LanguageDetection;

namespace Frank.Apps.AI.LanguageDetector;

public partial class LanguageDetectorWindow : Window
{
    private readonly LanguageDetectionService _languageDetector;

    public LanguageDetectorWindow()
    {
        _languageDetector = new LanguageDetectionService(new LanguageDetectionOptions());
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
            if (language != null && language.Probability > 0.5)
            {
                LanguageLabel.Content = language.Name;
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