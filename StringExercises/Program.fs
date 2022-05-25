open System

let isIsogram (str: string) =
    let mutable result = true
    for character in str.ToCharArray() do
        if character <> '-' && character <> ' ' then
            if str.IndexOf(character, StringComparison.OrdinalIgnoreCase) <> str.LastIndexOf(character) then
                result <- false
    result

let mutable isogramResult = isIsogram "lumberjacks"
printfn "lumberjacks: %b" isogramResult

isogramResult <- isIsogram "isograms"
printfn "isograms: %b" isogramResult

isogramResult <- isIsogram "background"
printfn "background: %b" isogramResult

isogramResult <- isIsogram "down stream"
printfn "down stream: %b" isogramResult

isogramResult <- isIsogram "apple"
printfn "apple: %b" isogramResult

isogramResult <- isIsogram "alphAbet"
printfn "alphAbet: %b" isogramResult

isogramResult <- isIsogram "Alphabet"
printfn "Alphabet: %b" isogramResult