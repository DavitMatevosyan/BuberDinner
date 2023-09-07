
namespace BuberDinner.Application.Common.Interfaces.IDateTimeProvider;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

}
