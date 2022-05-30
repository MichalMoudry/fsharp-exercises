type Approval =
    | Yes
    | No
    | Maybe

type Cuisine =
    | Korean
    | Turkish

type Genre =
    | Crime
    | Horror
    | Romance
    | Thriller

type Activity =
    | BoardGame
    | Chill
    | Movie of Genre
    | Restaurant of Cuisine
    | Walk of int

let rateActivity (activity: Activity): Approval =
    match activity with
        | Movie(Genre.Romance) -> Approval.Yes
        | Restaurant(Cuisine.Korean) -> Approval.Yes
        | Restaurant(Cuisine.Turkish) -> Approval.Maybe
        | Walk w when w < 3 -> Approval.Yes
        | Walk w when w < 5 -> Approval.Maybe
        | _ -> Approval.No

let rating = rateActivity (Activity.Movie(Genre.Thriller))
printfn $"{rating}"


open System.Text

type Plant =
    | Grass
    | Clover
    | Radishes
    | Violets

let getPlantType (plantChar: char) =
    match plantChar with
        | 'G' -> Some(Grass)
        | 'C' -> Some(Clover)
        | 'R' -> Some(Radishes)
        | 'V' -> Some(Violets)
        | _ -> None

let plantStringToList (plantString: string) =
    [
        getPlantType(plantString[0]).Value
        getPlantType(plantString[1]).Value
        getPlantType(plantString[2]).Value
        getPlantType(plantString[3]).Value
    ]

let plants (diagram: string) (student: string) =
    let str = new StringBuilder(4)
    let columns = 
        match student with
            | "Alice" -> [0; 1]
            | "Bob" -> [2; 3]
            | "Charlie" -> [4; 5]
            | "David" -> [6; 7]
            | "Eve" -> [8; 9]
            | "Fred" -> [10; 11]
            | "Ginny" -> [12; 13]
            | "Harriet" -> [14; 15]
            | "Ileana" -> [16; 17]
            | "Joseph" -> [18; 19]
            | "Kincaid" -> [20; 21]
            | "Larry" -> [22; 23]
            | _ -> []
    let rows = diagram.Split("\n")
    columns |> List.iter (fun i -> str.Append(rows[0][i]) |> ignore)
    columns |> List.iter (fun i -> str.Append(rows[1][i]) |> ignore)
    plantStringToList(str.ToString())

let plantsResult = plants "VRCGVVRVCGGCCGVRGCVCGCGV\nVRCCCGCRRGVCGCRVVCVGCGCV" "Eve"
printfn $"{plantsResult}"