namespace Exercises

module TupleExercises =
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