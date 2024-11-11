using Xunit;

namespace CommonDotNet.DateTimes;

public class DateTimeKindTests
{
    [Fact]
    public void CompareDateTimesWithAnyKinds()
    {
        DateTime localDateTime = DateTime.Now;
        DateTime unspecifiedDateTime = DateTime.SpecifyKind(localDateTime, DateTimeKind.Unspecified);
        DateTime utcDateTime = unspecifiedDateTime.ToUniversalTime();

        Assert.Equal(localDateTime, unspecifiedDateTime);
        Assert.NotEqual(utcDateTime, unspecifiedDateTime);
    }

    [Fact]
    public void CompareDateTimesCreatedFromUnixTime()
    {
        DateTimeOffset utcNowOffset = DateTimeOffset.UtcNow;

        long unixTime = utcNowOffset.ToUnixTimeSeconds();

        DateTime date = DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;

        Assert.Equal(utcNowOffset.DateTime.Hour, date.Hour);
        Assert.Equal(utcNowOffset.DateTime.Minute, date.Minute);
        Assert.Equal(utcNowOffset.DateTime.Second, date.Second);
        Assert.NotEqual(utcNowOffset.DateTime.Millisecond, date.Millisecond);

        // оказывается, DateTimeOffset.DateTime возвращает Kind = Unspecified
        Assert.Equal(DateTimeKind.Unspecified, date.Kind);
    }

    [Fact]
    public void CompareDateTimeOffsetsCreatedFromUnspecifiedAndUts()
    {
        DateTime localNow = DateTime.Now;
        var localOffset = new DateTimeOffset(localNow);

        DateTime unspecifiedNow = DateTime.SpecifyKind(localNow, DateTimeKind.Unspecified);
        var unspecifiedOffset = new DateTimeOffset(unspecifiedNow);

        DateTime utcNow = DateTime.SpecifyKind(localNow, DateTimeKind.Utc);
        var utcOffset = new DateTimeOffset(utcNow);

        Assert.Equal(localOffset, unspecifiedOffset);
        Assert.NotEqual(utcOffset, unspecifiedOffset);
    }
}