type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec pizzaPrice (pizza: Pizza): int =
    match pizza with
    | Margherita -> 7
    | Caprese -> 9
    | Formaggio -> 10
    | ExtraSauce(pizza) -> pizzaPrice(pizza) + 1
    | ExtraToppings(pizza) -> pizzaPrice(pizza) + 2

let orderPrice(pizzas: Pizza list): int =
    let sum = pizzas |> List.map (fun i -> pizzaPrice(i)) |> List.sum
    match List.length (pizzas) with
    | 1 -> sum + 3
    | 2 -> sum + 2
    | _ -> sum

printfn "%i" (pizzaPrice Margherita)
printfn "%i" (pizzaPrice (ExtraToppings(Margherita)))
printfn "%i" (orderPrice [Margherita; Formaggio])
printfn "%i" (orderPrice [Caprese])