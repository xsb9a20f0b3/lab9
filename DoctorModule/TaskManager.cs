namespace DoctorModule;

public class TaskManager
{
    public static void FirstTask(IEnumerable<Doctor> doctors)
    {
        var result = doctors
            .Where(doctor => doctor.dayOfReception == DayOfWeek.Friday)
            .Where(doctor => doctor.startReceptionTime > new TimeOnly(12, 0));
        Print(result.ToArray());
    }

    public static void SecondTask(IEnumerable<Doctor> doctors)
    {
        var dayOfWeek = DatetimeToDayOfWeek(DateTime.Now);
        
        var result = doctors
            .Where(doctor => doctor.dayOfReception == dayOfWeek)
            .MaxBy(doctor => doctor.endReceptionTime)!;

        Console.WriteLine($"Последним сегодня в {dayOfWeek} свой прием заканчивает:");
        result.Print('\n'.ToString());
    }

    public static void ThirdTask(IEnumerable<Doctor> doctors)
    {
        var currentTime = DateTime.Now;
        var tomorrowDayOfWeek = DatetimeToDayOfWeek(currentTime.AddDays(1));

        var result = doctors
            .Where(doctor => doctor.dayOfReception == tomorrowDayOfWeek)
            .Where(doctor => doctor.startReceptionTime <= new TimeOnly(12, 0))
            .Where(doctor => doctor.endReceptionTime >= new TimeOnly(12, 0));
        
        WriteToFile(result.ToArray(), currentTime);
    }

    private static DayOfWeek DatetimeToDayOfWeek(DateTime datetime)
    {
        return (DayOfWeek)Enum.Parse(typeof(DayOfWeek), datetime.DayOfWeek.ToString());
    }

    private static async void WriteToFile(Doctor[] doctors, DateTime datetime)
    {
        var prologue = $"Завтра начинают свой прием до полудня, а заканчивают до полудня {doctors.Length} врачей:\n\n";
        var resultString = doctors.Aggregate(prologue, (current, doctor) => current + doctor.DataToFile());
        await File.WriteAllTextAsync($"../../../../results/{datetime:hh.mm.ss-hh.mm.ss}.txt", resultString);
        Console.WriteLine("Файл был успешно создан.");
    }

    private static void Print(Doctor[] doctors)
    {
        foreach (var doctor in doctors)
        {
            doctor.Print();
        }
    }
}