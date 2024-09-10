using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace CommonDotNet;

public class DateTimeSerializationTests
{
    [Fact]
    public void TestLocalDatesSerialization()
    {
        var dateStr1 = "{\"Date\": \"2024-09-10T12:30:46.8656853Z\"}";
        var dateInfo1 = JsonSerializer.Deserialize<DateInfo>(dateStr1);

        var dateStr2 = "{\"Date\": \"2024-09-10T12:30:46.8656853+00:00\"}";
        var dateInfo2 = JsonSerializer.Deserialize<DateInfo>(dateStr2);

        var customOptions = new JsonSerializerOptions();
        customOptions.Converters.Add(new CustomDateTimeConverter());
        
        var dateStr3 = "{\"Date\": \"2024-09-10T12:30:46.8656853+0000\"}";
        var dateInfo3 = JsonSerializer.Deserialize<DateInfo>(dateStr3, customOptions);
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Очень строгое совпадение формата и никак не задать RegExp
            // return DateTime.ParseExact(reader.GetString(), "yyyy-MM-ddThh:mm:ss.fffffff+0000", null);
            
            // Такая нестрогая конвертация читает даже некорректный формат с +0000
            return DateTime.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
    
    public class DateInfo
    {
        public DateInfo()
        {
        }
        
        public DateInfo(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
    }
}