namespace ConsoleTest.Models.YandexCloud
{
    internal class YCTranslateData
    {
        public string sourceLanguageCode { get; set; }
        public string targetLanguageCode { get; set; }
        public string[] texts { get; set; }
        public GlossaryConfig glossaryConfig { get; set; }
        public struct GlossaryConfig
        {
            public GlossaryData glossaryData { get; set; }
            public struct GlossaryData
            {
                public GlossaryPairs[] glossaryPairs { get; set; }

                public struct GlossaryPairs
                {
                    public string sourceText { get; set; }
                    public string translatedText { get; set; }
                }
            }
        }
    }
}
