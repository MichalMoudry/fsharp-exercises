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

let steps (number: int): int option =
    if number > 0 then
        let mutable num = number
        let mutable res = 0
        while num > 1 do
            res <- res + 1
            if num % 2 = 0 then
                num <- num / 2
            else
                num <- 3 * num + 1
        Some(res)
    else
        None

printfn "CollatzConjecture: %i" ((steps 1).Value)

type Classification = Perfect | Abundant | Deficient

let classify n : Classification option =
    if n > 0 then
        let sum =
            { 1..(n - 1) }
                |> Seq.filter (fun x -> n % x = 0)
                |> Seq.sum
        match sum with
            | res when res = n -> Some(Perfect)
            | res when res > n -> Some(Abundant)
            | _ -> Some(Deficient)
    else
        None

printfn $"{classify 6}"
printfn $"{classify 12}"
printfn $"{classify 24}"
printfn $"{classify 8}"

let reply (guess: int): string =
    match guess with
        | 42 -> "Correct"
        | i when i = 41 || i = 43 -> "So close"
        | i when i < 41 -> "Too low"
        | _ -> "Too high"