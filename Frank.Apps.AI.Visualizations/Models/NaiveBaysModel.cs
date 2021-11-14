using System.Linq;
using Frank.Libraries.AI.LanguageDetection;
using Microsoft.ML;
using Newtonsoft.Json;

namespace Frank.Apps.AI.Visualizations.Models;

public class NaiveBaysModel
{
    private MLContext _context;
    private readonly LanguageModels _languageModels;

    public NaiveBaysModel()
    {
        _context = new MLContext();
        _languageModels = new LanguageModels();
    }

    public string Run()
    {
        var records = _languageModels.List.SelectMany(x => x.Frequency.Select(y => new InputModel() { Label = x.LanguageCode.ToString(), Ngram = y.Key }));
        var data = _context.Data.LoadFromEnumerable<InputModel>(records);
        var partitions = _context.Data.TrainTestSplit(data, 0.2);

        var model =
            _context.Transforms.Conversion.MapValueToKey("Label", "Label")
                .Append(_context.Transforms.Text.FeaturizeText("Ngram", "Ngram"))
                .Append(_context.MulticlassClassification.Trainers.NaiveBayes("Label", "Ngram"))
                //.Append(_context.Transforms.Conversion.MapKeyToValue("Label"))
                .Fit(partitions.TrainSet);
        var testMetrics = _context.MulticlassClassification.Evaluate(model.Transform(partitions.TestSet));

        var output = new { testMetrics.MicroAccuracy, testMetrics.MacroAccuracy, testMetrics.TopKPredictionCount, testMetrics.TopKAccuracy };

        return JsonConvert.SerializeObject(output, Formatting.Indented);
    }

    private class InputModel
    {
        public string Label { get; set; }

        public string Ngram { get; set; }
        //public int Count { get; set; }
    }

    private void GenerateInvoices()
    {

    }

    private class InvoiceLine
    {
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int SupplierId { get; set; }
        public int AccountingCode { get; set; }
        public int BuyerId { get; set; }
        public int Id { get; set; }
    }
}