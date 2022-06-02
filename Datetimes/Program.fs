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

let add (beginDate: DateTime) =
    beginDate.AddSeconds(10**9)

open System.Globalization

type Week = First | Second | Third | Fourth | Last | Teenth

let getWeekNumber (week: Week) =
    match week with
        | First -> Some(0)
        | Second -> Some(1)
        | Third -> Some(2)
        | Fourth -> Some(3)
        | Last -> Some(4)
        | _ -> None

let meetup year month week dayOfWeek: DateTime =
    let weekNumber = getWeekNumber week
    let date = DateTime().AddYears(year - 1).AddMonths(month - 1)
    let mutable calendar = CultureInfo.InvariantCulture.Calendar
    let dayNumber = int(dayOfWeek)
    if weekNumber.IsSome then
        printfn $"{int(calendar.AddWeeks(date, weekNumber.Value).DayOfWeek)} {dayNumber}"
        let mutable diff = int(calendar.AddWeeks(date, weekNumber.Value).DayOfWeek)
        let mutable dayDiff = 0
        while diff <> dayNumber do
            if diff > dayNumber then
                diff <- diff - 1
                dayDiff <- dayDiff - 1
            else
                diff <- diff + 1
                dayDiff <- dayDiff + 1
        printfn $"{diff} {dayNumber} {dayDiff}"
        calendar.AddWeeks(date, weekNumber.Value).AddDays(dayDiff)
    else
        date

printfn $"{(meetup 2022 6 Last DayOfWeek.Saturday)}"