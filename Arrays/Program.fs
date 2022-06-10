let lastWeek: int[] =
   [| 0; 2; 5; 3; 7; 8; 4 |]

let yesterday(counts: int[]): int =
    let length = Array.length counts
    counts[length - 2]

let total(counts: int[]): int =
    Array.sum counts

let dayWithoutBirds(counts: int[]): bool =
    counts |> Array.exists (fun i -> i = 0)

let incrementTodaysCount(counts: int[]): int[] =
    let lastItemIndex = (Array.length counts) - 1
    counts[lastItemIndex] <- counts[lastItemIndex] + 1
    counts

let oddWeek(counts: int[]): bool =
    match counts with
    | [| mon; _; wed; _; fri; _; sun |] when mon = 5 && wed = 5 && fri = 5 && sun = 5 -> true
    | [| _; tue; _; thu; _; sat; _ |] when (tue = 10 || tue = 0) && (thu = 10 || thu = 0) && (sat = 10 || sat = 0) -> true
    | _ -> false


printfn "%i" (yesterday [| 3; 5; 0; 7; 4; 1 |])
printfn "%i" (total [| 3; 5; 0; 7; 4; 1 |])
printfn "%b" (dayWithoutBirds [| 3; 5; 7; 4; 1 |])
printfn "%A" (incrementTodaysCount [| 3; 5; 7; 4; 1 |])
printfn "%b" (oddWeek [| 5; 0; 5; 12; 5; 3; 5|])
printfn "%b" (oddWeek [| 1; 0; 5; 0; 12; 0; 2 |])
printfn "%b" (oddWeek [| 5; 0; 5; 12; 5; 3; 5|])