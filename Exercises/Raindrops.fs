namespace Exercises

open System.Text

module Raindrops =
    let convert (number: int): string =
        let sb = new StringBuilder()
        if number % 3 = 0 then
            sb.Append("Pling") |> ignore
        if number % 5 = 0 then
            sb.Append("Plang") |> ignore
        if number % 7 = 0 then
            sb.Append("Plong") |> ignore

        if number % 3 <> 0 && number % 5 <> 0 && number % 7 <> 0 then
            sprintf "%i" number
        else
            sb.ToString()