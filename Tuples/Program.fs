let getCoordinate (line: string * string): string =
    snd line

let convertCoordinate (coordinate: string): int * char =
    (int(coordinate[0].ToString()), coordinate[1])

let compareRecords (azarasData: string * string) (ruisData: string * (int * char) * string) : bool =
    let azarasCoords = convertCoordinate (snd azarasData)
    let (name, ruisCoords, quadrants) = ruisData
    azarasCoords = ruisCoords

let createRecord (azarasData: string * string) (ruisData: string * (int * char) * string) : (string * string * string * string) =
    let doCoordsMatch = compareRecords azarasData ruisData
    if doCoordsMatch then
        let (name, ruisCoords, quadrant) = ruisData
        (snd azarasData, name, quadrant, fst azarasData)
    else
        ("", "", "", "")

printfn "%s" (getCoordinate ("Scrimshaw Whale's Tooth", "2A"))
let convertedCoords = convertCoordinate "2A"
printfn $"{convertedCoords}"
printfn "%b" (compareRecords ("Model Ship in Large Bottle", "8A") ("Harbor Managers Office", (8, 'A'), "purple"))
let createdRecord = createRecord ("Brass Spyglass", "4B") ("Abandoned Lighthouse", (4, 'B'), "Blue")
printfn $"{createdRecord}"