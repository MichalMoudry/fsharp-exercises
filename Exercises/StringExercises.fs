namespace Exercises

open System

module StringExercises =
    let isIsogram (str: string) =
        let mutable result = true
        for character in str.ToCharArray() do
            if character <> '-' && character <> ' ' then
                if str.IndexOf(character, StringComparison.OrdinalIgnoreCase) <> str.LastIndexOf(character) then
                    result <- false
        result