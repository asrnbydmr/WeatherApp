// JSON serileştirmesi (bir nesnenin veya veri yapısının JSON formatına dönüştürülmesi) için gerekli sınıfları ekliyoruz.
using System.Text.Json.Serialization;

// Weather sınıfı için WeatherApp alan adını kullanıyoruz.
namespace WeatherApp
{
    // Weather adında bir sınıf tanımlıyoruz.
    public class Weather
    {
        // "temperature" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Temperature" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        // "wind" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Wind" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("wind")]
        public string Wind { get; set; }

        // "description" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Description" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("description")]
        public string Description { get; set; }

        // "forecast" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Forecast" adında bir dizi tanımlıyoruz.
        [JsonPropertyName("forecast")]
        public Forecast[] Forecast { get; set; }
    }
}
