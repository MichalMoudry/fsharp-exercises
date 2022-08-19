namespace Exercises

open System

module Program =
    [<EntryPoint>]
    let main args =
        let meetup_result =
            DateTimeExercises.meetup 2022 7 DateTimeExercises.Fourth DayOfWeek.Friday
        printfn $"{meetup_result}"
        0