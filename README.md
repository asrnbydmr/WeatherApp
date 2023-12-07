# WeatherApp

Bu proje, belirli şehirlerin hava durumu bilgilerini JSON dosyasından almak için bir HTTP istemcisi kullanır.

## Kullanılan Kütüphaneler

- System
- System.Net.Http
- System.Text.Json
- System.Threading.Tasks

## Sınıfar İçin Kullanılan Kütüphaneler

- System.Text.Json.Serialization;

## Kullanılan NuGet Paketleri

- System.Text.Json (Microsoft)

## Nasıl Çalışır

1. HttpClient nesnesi oluşturulur.
2. API adreslerinden oluşan bir dizi tanımlanır.
3. Her bir API için döngü oluşturulur ve API isteği gönderilir.
4. İstek başarılı ise, JSON içeriği okunur ve havadurumu sınıfındaki alanlara çevrilir.
5. Şehir için veriler yazdırılır ve önümüzdeki günlerin tahminleri ekrana yazdırılır.

## Sınıflar

- WeatherData: JSON belgesinde bulunan alan isimlerine göre değişkenler oluşturulur. JSON içeriği sıcaklık, rüzgar hızı, tanım ve gün bilgileri dizisidir. Bu sınıf kök JSON verisidir.
- ForecastData: JSON belgesinde bulunan alan isimlerine göre değişkenler oluşturulur. JSON içeriği gün, sıcaklık ve rüzgar hızı bilgisidir.