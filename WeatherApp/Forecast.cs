// JSON serileştirmesi (bir nesnenin veya veri yapısının JSON formatına dönüştürülmesi) için gerekli sınıfları ekliyoruz.
using System.Text.Json.Serialization;

// Forecast sınıfı için WeatherApp alan adını kullanıyoruz.
namespace WeatherApp
{
    // Forecast adında bir sınıf tanımlıyoruz.
    public class Forecast
    {
        // "day" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Day" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("day")]
        public string Day { get; set; }

        // "temperature" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Temperature" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        // "wind" adlı JSON özelliğini temsil eden ve serileştirilebilir bir şekilde kullanılabilen "Wind" adında bir değişken tanımlıyoruz.
        [JsonPropertyName("wind")]
        public string Wind { get; set; }
    }
}
