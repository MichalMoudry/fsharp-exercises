namespace Exercises

open System

module Program =
    [<EntryPoint>]
    let main args =
        (*let meetup_result =
            DateTimeExercises.meetup 2022 7 DateTimeExercises.Second DayOfWeek.Monday
        let meetup_result2 =
            DateTimeExercises.meetup 2022 7 DateTimeExercises.First DayOfWeek.Monday
        printfn $"{meetup_result}"
        printfn $"{meetup_result2}"*)
        let robot = RobotSimulator.create RobotSimulator.North (7, 3)
        let newPosition = RobotSimulator.move "RAALAL" robot
        printfn $"{newPosition.position}"
        0