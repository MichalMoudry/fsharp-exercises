type Coach = {
    Name: string
    FormerPlayer: bool
}

type Stats = {
    Wins: int
    Losses: int
}

type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

let createCoach (name: string) (formerPlayer: bool): Coach =
    { Name = name; FormerPlayer = formerPlayer }

let createStats(wins: int) (losses: int): Stats =
   { Wins = wins; Losses = losses }

let createTeam(name: string) (coach: Coach)(stats: Stats): Team =
  { Name = name; Coach = coach; Stats = stats }

let replaceCoach(team: Team) (coach: Coach): Team =
   { team with Coach = coach }

let isSameTeam(homeTeam: Team) (awayTeam: Team): bool =
   homeTeam = awayTeam

let rootForTeam(team: Team): bool =
    let { Coach = coach; Stats = stats } = team
    let mutable res = false
    if coach.Name.Equals("Gregg Popovich") || coach.FormerPlayer || team.Name.Equals("Chicago Bulls") || stats.Wins >= 60 || stats.Wins < stats.Losses then
        res <- true
    res