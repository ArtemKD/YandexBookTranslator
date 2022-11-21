using ConsoleTest.Models.YandexCloud;
using System.Text.Json;
using static ConsoleTest.Models.YandexCloud.YCTranslateData.GlossaryConfig.GlossaryData;

internal class Program
{
    private static void Main(string[] args)
    {
        YCTranslateData yCTranslateData = new YCTranslateData()
        {
            sourceLanguageCode = "ru",
            targetLanguageCode = "en",
            texts = new string[] {"Яблоко", "Слива"},
            glossaryConfig = new YCTranslateData.GlossaryConfig()
            {
                glossaryData = new YCTranslateData.GlossaryConfig.GlossaryData()
                {
                    glossaryPairs = new GlossaryPairs[]
                    {
                        new GlossaryPairs()
                        {
                            sourceText = "spor ayakkabı",
                            translatedText = "кроссовки"
                        },
                        new GlossaryPairs()
                        {
                            sourceText = "apple",
                            translatedText = "яблоко"
                        }
                    } 
                }
            }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var jsonString = JsonSerializer.Serialize(yCTranslateData, options);
        Console.WriteLine(jsonString);
    }

    public static void Test()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        Reply iamTokenReply = IamToken.Get(Environment.GetEnvironmentVariable("OAuthTokenYandexCloud"), cts.Token).Result;
        if (iamTokenReply.Code != 200)
        {
            Console.WriteLine($"Ошибка {iamTokenReply.Code}");
        }
        Console.WriteLine(iamTokenReply.Message);

        Translator translator = new Translator((string)iamTokenReply.Message);

        string[] texts =
        {
            "Привет!!",
            "Яблоко",
            "Персик"
        };

        Reply result = translator.Translate(texts, "ru", "en", cts.Token).Result;


        Console.WriteLine($"Code: {result.Code}");
        Console.WriteLine(result.Message);
    }
}