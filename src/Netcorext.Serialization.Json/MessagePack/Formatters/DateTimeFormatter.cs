using System.Text;
using MessagePack;
using MessagePack.Formatters;

namespace Netcorext.Serialization.Json.MessagePack.Formatters;

public class DateTimeFormatter : IMessagePackFormatter<DateTime>
{
    public void Serialize(ref MessagePackWriter writer, DateTime value, MessagePackSerializerOptions options)
    {
        writer.WriteString(Encoding.ASCII.GetBytes(value.ToString("O")));
    }

    public DateTime Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        return DateTime.Parse(reader.ReadString());
    }
}

public class NullableDateTimeFormatter : IMessagePackFormatter<DateTime?>
{
    public void Serialize(ref MessagePackWriter writer, DateTime? value, MessagePackSerializerOptions options)
    {
        if (!value.HasValue)
        {
            writer.WriteNil();

            return;
        }
        
        writer.WriteString(Encoding.ASCII.GetBytes(value.Value.ToString("O")));
    }

    public DateTime? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
            return null;
        
        return DateTime.Parse(reader.ReadString());
    }
}

public class DateTimeOffsetFormatter : IMessagePackFormatter<DateTimeOffset>
{
    public void Serialize(ref MessagePackWriter writer, DateTimeOffset value, MessagePackSerializerOptions options)
    {
        writer.WriteString(Encoding.ASCII.GetBytes(value.ToString("O")));
    }

    public DateTimeOffset Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        return DateTimeOffset.Parse(reader.ReadString());
    }
}

public class NullableDateTimeOffsetFormatter : IMessagePackFormatter<DateTimeOffset?>
{
    public void Serialize(ref MessagePackWriter writer, DateTimeOffset? value, MessagePackSerializerOptions options)
    {
        if (!value.HasValue)
        {
            writer.WriteNil();

            return;
        }
        
        writer.WriteString(Encoding.ASCII.GetBytes(value.Value.ToString("O")));
    }

    public DateTimeOffset? Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        if (reader.TryReadNil())
            return null;
        
        return DateTimeOffset.Parse(reader.ReadString());
    }
}