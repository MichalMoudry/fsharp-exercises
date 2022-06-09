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
    match languages with
    | "F#" :: _
    | [ _; "F#" ]
    | [ _; "F#"; _ ] -> true
    | _ -> false

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