namespace Exercises

open System

module Program =
    [<EntryPoint>]
    let main args =
        let meetup_result =
            DateTimeExercises.meetup 2022 7 DateTimeExercises.Second DayOfWeek.Tuesday
        let meetup_result2 =
            DateTimeExercises.meetup 2022 7 DateTimeExercises.First DayOfWeek.Tuesday
        printfn $"{meetup_result}"
        printfn $"{meetup_result2}"
        0