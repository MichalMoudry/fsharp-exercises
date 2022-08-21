namespace Exercises

module RobotSimulator =
    type Direction = North | East | South | West
    type Position = int * int
    type Robot =
        { direction: Direction; position: Position }
        member this.updateDirection(dir: Direction) =
            { direction = dir; position = this.position }
    type Movement = TurnRight | TurnLeft | Advance

    let create direction position =
        { direction = direction; position = position }

    let matchInstruction (instruction: char): Movement =
        match instruction with
            | 'R' -> TurnRight
            | 'L' -> TurnLeft
            | _ -> Advance
    
    let handleTurnRight (robot: Robot) (origDirection: Direction) =
        let newDirection =
            match origDirection with
                | North -> East
                | East -> South
                | South -> West
                | _ -> North
        robot.updateDirection(newDirection)
    
    let handleTurnLeft (robot: Robot) (origDirection: Direction) =
        let newDirection =
            match origDirection with
                | North -> West
                | _ -> North
        robot.updateDirection(newDirection)
    
    let executeInstructions (robot: Robot) (instruction: char) =
        let movement = matchInstruction instruction
        match movement with
            | Advance -> robot
            | TurnRight -> handleTurnRight robot robot.direction
            | TurnLeft -> handleTurnLeft robot robot.direction

    let move (instructions: string) (robot: Robot) =
        let robotHistory = instructions |> Seq.map (fun i -> executeInstructions robot i)
        robotHistory |> Seq.last