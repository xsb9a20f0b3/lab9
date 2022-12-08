namespace DoctorModule;

public enum DayOfWeek
{
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6,
    Sunday = 7,
}

public class Doctor
{
    public string cabinetName;
    public int cabinetNumber;

    public string doctorName;
    public DayOfWeek dayOfReception;

    public TimeOnly startReceptionTime;
    public TimeOnly endReceptionTime;

    public Doctor(string cabinetName, int cabinetNumber, string doctorName, DayOfWeek dayOfReception,
        TimeOnly startReceptionTime, TimeOnly endReceptionTime)
    {
        this.cabinetName = cabinetName;
        this.cabinetNumber = cabinetNumber;
        this.doctorName = doctorName;
        this.dayOfReception = dayOfReception;
        this.startReceptionTime = startReceptionTime;
        this.endReceptionTime = endReceptionTime;
    }

    public void Print(string? postfix = "")
    {
        Console.WriteLine($"Имя врача: {doctorName}");
        Console.WriteLine($"- Принимает:");
        Console.WriteLine($"-- Только в {dayOfReception}");
        Console.WriteLine($"-- С {startReceptionTime} до {endReceptionTime}");
        Console.WriteLine($"-- В кабинете {cabinetName}а {cabinetNumber}\n{postfix}");
    }

    public string DataToFile()
    {
        return $"Имя врача: {doctorName}\n- Принимает:\n" +
               $"-- Только в {dayOfReception}\n-- С {startReceptionTime} до {endReceptionTime}\n" +
               $"-- В кабинете {cabinetName}а {cabinetNumber}\n\n";
    }
}