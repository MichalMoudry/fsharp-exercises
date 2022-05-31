open System

let schedule (appointmentDateDescription: string): DateTime =
    Convert.ToDateTime(appointmentDateDescription)

let hasPassed (appointmentDate: DateTime): bool =
    appointmentDate.CompareTo(DateTime.Now) < 0

let isAfternoonAppointment (appointmentDate: DateTime): bool =
    appointmentDate.Hour >= 12 && appointmentDate.Hour < 18

let description (appointmentDate: DateTime): string =
    let date = appointmentDate.ToString("G")
    $"You have an appointment on {date}."

let anniversaryDate(): DateTime =
    DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0)

let scheduleResult = schedule "25/7/2019 13:45:00"
printfn $"{scheduleResult}"
printfn "%b" (hasPassed (DateTime(1999, 12, 31, 9, 0, 0)))
printfn "%b" (isAfternoonAppointment (DateTime(2019, 03, 29, 15, 0, 0)))
printfn "%s" (description (DateTime(2019, 03, 29, 15, 0, 0)))