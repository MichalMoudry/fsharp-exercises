namespace Exercises

open System

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

    let meetup year month week (dayOfWeek: DayOfWeek): DateTime =
        let weekNumber = getWeekNumber week
        if weekNumber.IsSome then
            (*let dayNumber = getDayNumber dayOfWeek
            let mutable dateWithMonths = DateTime().AddYears(year - 1).AddMonths(month - 1).AddDays(float(7 * weekNumber.Value))
            let initDayNumber = getDayNumber dateWithMonths.DayOfWeek
            dateWithMonths <- dateWithMonths.AddDays(-initDayNumber.Value);
            printfn $"Day of the week: {dateWithMonths.DayOfWeek} | {dayNumber.Value}"*)
            let mutable initDate = DateTime().AddYears(year - 1).AddMonths(month - 1)
            let initDayNumber = (getDayNumber initDate.DayOfWeek).Value
            initDate <- initDate.AddDays(-initDayNumber)
            let isMonday = initDate.DayOfWeek = DayOfWeek.Monday
            //let isFirstWeekOverlap = not(isMonday) // && dayOfWeek < initDate.DayOfWeek
            printfn $"Is monday: {isMonday} | {initDate.DayOfWeek} | {not(isMonday)}"
            initDate
        else
            DateTime.Now