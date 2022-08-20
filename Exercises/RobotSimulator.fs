namespace Exercises

module RobotSimulator =
    type Direction = North | East | South | West
    type Position = int * int
    type Robot = { direction: Direction; position: Position }
    type Movement = TurnRight | TurnLeft | Advance

    let matchInstructions (instruction: char): Movement =
        match instruction with
            | 'R' -> TurnRight
            | 'L' -> TurnLeft
            | _ -> Advance
    
    let changePosition (robot: Robot) (instruction: char) =
        let movement = matchInstructions instruction
        0

    let create direction position =
        { direction = direction; position = position }

    let move (instructions: string) (robot: Robot) =
        instructions |> Seq.iter (fun i -> printfn "%c %s" i ((matchInstructions i).ToString()))
        robot