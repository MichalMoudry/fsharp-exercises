open System.Linq

let newList: string list =
    []

let existingList: string list =
    ["F#"; "Clojure"; "Haskell"]

let addLanguage (language: string) (languages: string list): string list =
    language::languages

let countLanguages (languages: string list): int =
    languages |> List.length

let reverseList(languages: string list): string list =
    languages |> List.rev

let excitingList (languages: string list): bool =
    let listLength = countLanguages languages
    if listLength = 4 && languages[1].Equals("F#") then
        false
    else
        if listLength = 0 then
            false
        elif languages.Head.Equals("F#") || (listLength > 1 && languages[1].Equals("F#")) then
            true
        else
            false

printfn $"{newList}"
printfn $"{existingList}"
let addLanguageResult = addLanguage "Typescript" ["JS"; "C#"]
printfn $"{addLanguageResult}"
printfn "%i" (countLanguages addLanguageResult)
printfn $"{(reverseList addLanguageResult)}"
printfn "%b" (excitingList ["Nim"; "F#"])
printfn "%b" (excitingList [ "Java"; "F#"; "C#" ])
printfn "%b" (excitingList [])
printfn "%b" (excitingList ["C#"])
printfn "%b" (excitingList [ "Elm"; "F#"; "C#"; "Scheme" ])