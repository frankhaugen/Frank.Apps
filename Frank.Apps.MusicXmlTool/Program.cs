using Kohoutech.Score.MusicXML;

namespace Frank.Apps.MusicXmlTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var score = MusicXMLReader.loadFromMusicXML("mars.musicxml");

            //score.Parts.First().Measures.First().MeasureElements.First().Element
        }
    }
}
