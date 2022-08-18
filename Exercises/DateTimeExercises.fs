namespace Exercises

open System.Globalization

module DateTimeExercises =
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

    let add (beginDate: DateTime) =
        beginDate.AddSeconds(10**9)

    type Week = First | Second | Third | Fourth | Last | Teenth

    let getWeekNumber (week: Week) =
        match week with
            | First -> Some(0)
            | Second -> Some(1)
            | Third -> Some(2)
            | Fourth -> Some(3)
            | Last -> Some(4)
            | _ -> None

    let getDayNumber (day: DayOfWeek): option<int> =
        match day with
            | DayOfWeek.Monday -> Some(0)
            | DayOfWeek.Tuesday -> Some(1)
            | DayOfWeek.Wednesday -> Some(2)
            | DayOfWeek.Thursday -> Some(3)
            | DayOfWeek.Friday -> Some(4)
            | DayOfWeek.Saturday -> Some(5)
            | DayOfWeek.Sunday -> Some(6)
            | _ -> None

    (*
    let weekNumber = getWeekNumber week
    let date = DateTime().AddYears(year - 1).AddMonths(month - 1)
    let mutable calendar = CultureInfo.InvariantCulture.Calendar
    if weekNumber.IsSome then
        printfn $"{int(calendar.AddWeeks(date, weekNumber.Value).DayOfWeek)} {dayOfWeek}"
        let mutable diff = int(calendar.AddWeeks(date, weekNumber.Value).DayOfWeek)
        let mutable dayDiff = 0
        while diff <> dayOfWeek do
            if diff > dayOfWeek then
                diff <- diff - 1
                dayDiff <- dayDiff - 1
            else
                diff <- diff + 1
                dayDiff <- dayDiff + 1
        printfn $"{diff} {dayOfWeek} {dayDiff}"
        calendar.AddWeeks(date, weekNumber.Value).AddDays(dayDiff)
    else
        date
    *)  

    let meetup year month week (dayOfWeek: DayOfWeek): DateTime =
        let weekNumber = getWeekNumber week
        if weekNumber.IsSome then
            let date = DateTime().AddYears(year - 1).AddMonths(month - 1)
            let calendar = CultureInfo.InvariantCulture.Calendar
            calendar.AddWeeks(date, weekNumber.Value).AddDays((getDayNumber dayOfWeek).Value)
        else
            DateTime.Now
            
    //printfn $"{(meetup 2022 8 Last DayOfWeek.Friday)}"