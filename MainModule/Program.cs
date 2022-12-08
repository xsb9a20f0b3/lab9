using DoctorModule;
using DayOfWeek = DoctorModule.DayOfWeek;

var cabinetNames = new[] { "Психиатр", "Хирург", "Терапевт", "Педиатр", "Фармаевт"};
var doctorNames = new[] { "Daniil", "Thomas", "Alex", "Tony", "Alexandra" };

const int doctorsNumber = 1000; 
var random = new Random();

var doctorsContainer = new Doctor[doctorsNumber];
for (var doctorIndex = 0; doctorIndex < doctorsNumber; doctorIndex++)
{
    var endReceptionTime = new TimeOnly(random.Next(6, 19), random.Next(0, 60));
    var startReceptionTime = new TimeOnly(random.Next(5, endReceptionTime.Hour), random.Next(0, 60));
    var cabinetName = cabinetNames[random.Next(0, cabinetNames.Length)];
    var cabinetNumber = random.Next(10, 30) * 10;
    var doctorName = doctorNames[random.Next(0, doctorNames.Length)];

    var values = Enum.GetValues(typeof(DayOfWeek));
    doctorsContainer[doctorIndex] = new Doctor(
        cabinetName,
        cabinetNumber,
        doctorName,
        (DayOfWeek) values.GetValue(random.Next(values.Length))!,
        startReceptionTime,
        endReceptionTime);
}

void Main()
{
    TaskManager.FirstTask(doctorsContainer);
    TaskManager.SecondTask(doctorsContainer);
    TaskManager.ThirdTask(doctorsContainer);
}

Main();