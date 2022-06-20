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