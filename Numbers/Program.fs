let leapYear (year: int): bool =
    if year % 4 = 0 && (not(year % 100 = 0) || year % 400 = 0) then
        true
    else
        false

printfn "%b" (leapYear 1997)
printfn "%b" (leapYear 1996)
printfn "%b" (leapYear 1900)
printfn "%b" (leapYear 2000)

open System.Text

let create hours minutes : string =
    let mutable hrs = hours
    let mutable mins = minutes
    while hrs >= 24 do
        hrs <- hrs - 24
    if minutes >= 60 then
        let numberOfHours = int(float(minutes) / 60.0)
        hrs <- hrs + numberOfHours
        mins <- mins - (numberOfHours * 60)
    let hours_sb = new StringBuilder(2)
    let minutes_sb = new StringBuilder(2)
    if hrs < 10 && hrs >= 0 then
        hours_sb.Append("0") |> ignore
    if mins < 10 then
        minutes_sb.Append(0) |> ignore
    hours_sb.Append($"{hrs}") |> ignore
    minutes_sb.Append($"{mins}") |> ignore
    $"{hours_sb}:{minutes_sb}"

let add (minutes: int) (clock: string) =
    let split = clock.Split(":")
    let hours = int(split[0])
    let mins = int(split[1])
    create hours (mins + minutes)

let subtract minutes (clock: string) =
    let split = clock.Split(":")
    let hours = int(split[0])
    let mins = int(split[1])
    create hours (mins - minutes)

let display (clock: string) =
    let split = clock.Split(":")
    create (int(split[0])) (int(split[1]))

printfn "Create: %s" (create -1 15)
printfn "Create: %s" (create 56 15)
printfn "Add: %s" (add 3 "10:00")
printfn "Add: %s" (add 157 "10:00")
printfn "Display: %s" (display "16:151")