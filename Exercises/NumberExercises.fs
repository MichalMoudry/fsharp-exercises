namespace Exercises

module NumberExercises =
    let leapYear (year: int): bool =
        if year % 4 = 0 && (not(year % 100 = 0) || year % 400 = 0) then
            true
        else
            false

    let create hours minutes : string =
        let mutable mins = minutes
        let minutesOverlap = minutes / 60
        let mutable hrs = (minutesOverlap + hours) % 24
        mins <- mins - (minutesOverlap * 60)
        if mins < 0 then
            mins <- 60 + mins
            hrs <- hrs - 1
        if hrs < 0 then
            hrs <- 24 + hrs
        sprintf "%02i:%02i" hrs mins

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

    let reply (guess: int): string =
        match guess with
            | 42 -> "Correct"
            | i when i = 41 || i = 43 -> "So close"
            | i when i < 41 -> "Too low"
            | _ -> "Too high"