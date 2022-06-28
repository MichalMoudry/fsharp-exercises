let interestRate (balance: decimal): single =
    match balance with
    | value when value < 0m -> 3.213f
    | value when value < 1000m -> 0.5f
    | value when value >= 1000m && value < 5000m -> 1.621f
    | value when value >= 5000m -> 2.475f
    | _ -> 0f

let interest (balance: decimal): decimal =
    decimal(interestRate balance / 100f) * balance

let annualBalanceUpdate(balance: decimal): decimal =
    balance + (interest balance)

let amountToDonate(balance: decimal) (taxFreePercentage: float): int =
    if balance < 1m then
        0
    else
        let onepercent = balance / 100m
        int((onepercent * decimal(taxFreePercentage)) * 2m)

printfn "%f" (interestRate 200.75m)
printfn "%f" (interest 200.75m)
printfn "%f" (annualBalanceUpdate 200.75m)
let balance = 550.5m
let taxFreePercentage = 2.5
printfn "%i" (amountToDonate balance taxFreePercentage)

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let age (planet: Planet) (seconds: int64): float =
    let minutes = seconds / int64(60)
    let hours = minutes / int64(60)
    let days = hours / int64(24)
    let orbitalPeriod =
        match planet with
        | Mercury -> 0.2408467
        | Venus -> 0.61519726
        | Earth -> 1.0
        | Mars -> 1.8808158
        | Jupiter -> 11.862615
        | Saturn -> 29.447498
        | Uranus -> 84.016846
        | Neptune -> 164.79132
    float(days) / (orbitalPeriod * 365.25)

printfn "Age: %f (expected -> 280.88)" (age Mercury 2134835688L)
printfn "Age: %f (expected -> 31.69)" (age Earth 1000000000L)

let score (x: double) (y: double): int =
    let distance = sqrt(x * x + y * y)
    if distance <= 1.0 then
        10
    elif distance <= 5.0 then
        5
    elif distance <= 10.0 then
        1
    else
        0

printfn "%i" (score -3.6 -3.6)