let leapYear (year: int): bool =
    if year % 4 = 0 && (not(year % 100 = 0) || year % 400 = 0) then
        true
    else
        false

printfn "%b" (leapYear 1997)
printfn "%b" (leapYear 1996)
printfn "%b" (leapYear 1900)
printfn "%b" (leapYear 2000)

let create hours minutes =
    failwith "You need to implement this function."

let add minutes clock =
    failwith "You need to implement this function."

let subtract minutes clock =
    failwith "You need to implement this function."

let display clock =
    failwith "You need to implement this function."