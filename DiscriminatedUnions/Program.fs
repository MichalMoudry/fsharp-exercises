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