// Çıktı kodlarını (WriteLine vb. komutlar) ve girdi kodlarını (ReadLine vb. komutlar) kullanmak için gerekli sınıfları ekliyoruz.
using System;
// HTTP iletişimi için gerekli sınıfları ekliyoruz.
using System.Net.Http;
// JSON serileştirmesi ve serileştirme işlemleri (bir nesnenin veya veri yapısının JSON formatına dönüştürülmesi) için gerekli sınıfları ekliyoruz.
using System.Text.Json;
// Asenkron programlama işlemlerini desteklemek için gerekli olan sınıfları ekliyoruz.
using System.Threading.Tasks;

// Program sınıfı için WeatherApp alan adını kullanıyoruz.
namespace WeatherApp
{
    // Program adında bir sınıf tanımlıyoruz.
    internal class Program
    {
        // HttpClient sınıfından bir değişken oluşturuyoruz. Bu değişkeni, HTTP istekleri yapmak için kullanacağız.
        // Bu değişken oluşturulduktan sonra değiştiremeyen (readonly) ve static (statik) bir değişkendir.
        static readonly HttpClient client = new HttpClient();

        // Programın ana metodudur. Http işlemleri için Asenkron ve Task metod olarak tanımlıyoruz. 
        static async Task Main(string[] args)
        {
            // Json Formatı => temperature, wind, description, forecast[ day, temperature, wind ]

            // Api adreslerini tutmak için bir dizi tanımlıyoruz.
            string[] apiAddresses = new string[]
            {
                "https://goweather.herokuapp.com/weather/istanbul",
                "https://goweather.herokuapp.com/weather/izmir",
                "https://goweather.herokuapp.com/weather/ankara"
            };

            // Her bir api adresi için çalışacak bir döngü tanımlıyoruz.
            foreach (string apiAddress in apiAddresses)
            {
                // Çalıştırılacak kodda hata olur ise yakalamak için try catch yapısını kullanıyoruz.
                try
                {
                    // HttpClient sınıfının GetAsync metodunu kullanarak, asenkron bir HTTP GET isteği gönderiyoruz.
                    // Sonucu HttpResponseMessage türündeki response nesnesine aktarıyoruz.
                    // await anahtar kelimesi, GetAsync metodunun tamamlanmasını bekler ve ardından programın diğer işlemlerine geçer.
                    HttpResponseMessage response = await client.GetAsync(apiAddress);

                    // HTTP yanıtının başarılı olup olmadığını kontrol ediyoruz.
                    // HTTP yanıtı başarılı değil ise (404 Not Found vb.) catch bloğuna geçer.
                    response.EnsureSuccessStatusCode();

                    // Yanıtın içeriği okuruz ve responseBody nesnesine aktarıyoruz.
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // JsonDocument sınıfından jsonDocument adlı bir değişken oluşturuyoruz.
                    // responseBody değişkenini JsonDocument sınıfına dönüştürüyoruz.
                    JsonDocument jsonDocument = JsonDocument.Parse(responseBody);

                    // Json dosyasında bulunan "temperature" alanının değerini "temperature" adında bir değişkene aktarıyoruz.
                    string temperature = jsonDocument.RootElement.GetProperty("temperature").GetString();
                    // Json dosyasında bulunan "wind" alanının değerini "wind" adında bir değişkene aktarıyoruz.
                    string wind = jsonDocument.RootElement.GetProperty("wind").GetString();
                    // Json dosyasında bulunan "description" alanının değerini "description" adında bir değişkene aktarıyoruz.
                    string description = jsonDocument.RootElement.GetProperty("description").GetString();

                    // Weather sınıfından "weather" adlı bir değişken oluşturuyoruz.
                    // responseBody içeriğini (Json içeriğini) Weather sınıfına uygun bir biçime dönüştürüyoruz.
                    Weather weather = JsonSerializer.Deserialize<Weather>(responseBody);

                    // apiAddress değişkeni'nin sonunda bulunan şehir ismini bulmak için "/" sembolü ile metni bölüyoruz.
                    // En sonda elde edilen değeri "cityName" adlı değişkene aktarıyoruz.
                    // 0 => "https:"
                    // 1 => ""
                    // 2 => "goweather.herokuapp.com"
                    // 3 => "weather"
                    // 4 => "istanbul"
                    string cityName = apiAddress.Split('/')[4];

                    // Şehir ismini ekrana yazdırıyoruz.
                    Console.WriteLine("Şehir İsmi: " + cityName);
                    // Json verisinden gelen hava verilerini ekrana yazdırıyoruz.
                    Console.WriteLine("Sıcaklık: " + weather.Temperature + " Rüzgar Durumu: " + weather.Wind + " Tanım: " + weather.Description);

                    // Her bir gün verisi için çalışacak bir döngü tanımlıyoruz.
                    foreach (Forecast forecast in weather.Forecast)
                    {
                        // Json verisinden gelen gün ve o güne ait hava verilerini ekrana yazdırıyoruz.
                        Console.WriteLine(forecast.Day + ". Gün Sıcaklık: " + forecast.Temperature + " Rüzgar Durumu: " + forecast.Wind);
                    }
                    // Verilerin daha okunaklı olması için bir satır boşluk bırakıyoruz.
                    Console.WriteLine();
                }
                // Hata olur ise; hata HttpRequestException türünde e adında tanımladığımız değişkene aktarılacak.
                catch (HttpRequestException e)
                {
                    // Hatayı ekrana yazdırıyoruz.
                    Console.WriteLine("Exception: " + e.Message);
                }
            }

            // Programın hemen kapanmaması için ReadKey metodunu kullanıyoruz.
            // Artık program bir tuşa basıldığında kapanacak.
            Console.ReadKey();
        }
    }
}
