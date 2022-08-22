namespace Exercises

module RobotSimulator =
    type Direction = North | East | South | West
    type Position = int * int
    type Robot =
        { mutable direction: Direction; mutable position: Position }
        member this.updateDirection(dir: Direction) =
            this.direction <- dir
            this
    type Movement = TurnRight | TurnLeft | Advance

    let create direction position =
        { direction = direction; position = position }

    let matchInstruction (instruction: char): Movement =
        match instruction with
            | 'R' -> TurnRight
            | 'L' -> TurnLeft
            | _ -> Advance

    let handleTurnRight (robot: Robot) =
        let newDirection =
            match robot.direction with
                | North -> East
                | East -> South
                | South -> West
                | _ -> North
        robot.updateDirection(newDirection)

    let handleTurnLeft (robot: Robot) =
        let newDirection =
            match robot.direction with
                | North -> West
                | West -> South
                | South -> East
                | _ -> North
        robot.updateDirection(newDirection)

    let handleAdvance (robot: Robot) =
        let x = fst robot.position
        let y = snd robot.position
        robot.position <-
            match robot.direction with
                | North -> (x, y + 1)
                | East -> (x + 1, y)
                | South -> (x, y - 1)
                | _ -> (x - 1, y)
        robot

    let executeInstructions (robot: Robot) (instruction: char) =
        let movement = matchInstruction instruction
        match movement with
            | Advance -> handleAdvance robot
            | TurnRight -> handleTurnRight robot
            | TurnLeft -> handleTurnLeft robot

    let move (instructions: string) (robot: Robot) =
        instructions |> Seq.fold executeInstructions robot