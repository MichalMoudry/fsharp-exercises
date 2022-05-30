let successRate (speed: int): float =
    match speed with
        | input when input >= 1 && input <= 4 -> 1.0
        | input when input >= 5 && input <= 8 -> 0.9
        | 9 -> 0.8
        | 10 -> 0.77
        | _ -> 0.0

let productionRatePerHour (speed: int): float =
    float(speed * 221) * (successRate speed)

let workingItemsPerMinute (speed: int): int =
    int(productionRatePerHour speed) / 60

printfn "%f" (successRate 10)
printfn "%f" (productionRatePerHour 6)
printfn "%i" (workingItemsPerMinute 6)