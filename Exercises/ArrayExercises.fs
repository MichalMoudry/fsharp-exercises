namespace Exercises

module ArrayExercises =
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

    let find (input: int array) (value: int) =
        match input.Length with
        | 0 -> None
        | _ -> 
            let pivotIndex = input.Length / 2
            let pivot = input[pivotIndex]
            if pivot = value then
                Some(pivotIndex)
            else
                let firstHalf = input |> Array.take pivotIndex
                if value < pivot then
                    firstHalf |> Array.tryFindIndex (fun i -> i = value)
                else
                    let secondHalf = input |> Array.skip (pivotIndex + 1)
                    let indexOption = secondHalf |> Array.tryFindIndex (fun i -> i = value)
                    if indexOption.IsSome then
                        Some(indexOption.Value + firstHalf.Length + 1)
                    else
                        None

    let keep pred xs =
        xs |> Seq.where (pred)

    let discard pred xs =
        let itemsToExclude = xs |> Seq.where (pred)
        xs |> Seq.except (itemsToExclude)