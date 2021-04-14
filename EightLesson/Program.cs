using System;
using System.Collections.Generic;

namespace EightLesson
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var footballGame = new FootballGame();

            footballGame.GenerateMatches();
            footballGame.ShowMatchResults();
        }
    }

    internal class FootballGame
    {
        private readonly List<Match> _playedMatches = new List<Match>();

        public List<FootballTeam> FootballTeams { get; } =
            new List<FootballTeam>
            {
                new FootballTeam
                {
                    Name = "Liverpool"
                },
                new FootballTeam
                {
                    Name = "Chelsea"
                },
                new FootballTeam
                {
                    Name = "Barcelona"
                },
                new FootballTeam
                {
                    Name = "Real Madrid"
                },
                new FootballTeam
                {
                    Name = "Dnipro"
                },
                new FootballTeam
                {
                    Name = "Roma"
                }
            };

        public void GenerateMatches()
        {
            for (var i = 0; i < FootballTeams.Count; i++)
            {
                for (var j = i + 1; j < FootballTeams.Count; j++)
                {
                    var match = new Match(FootballTeams[i], FootballTeams[j]);
                    match.Play();

                    _playedMatches.Add(match);
                }
            }
        }

        public void ShowMatchResults()
        {
            foreach (var playedMatch in _playedMatches)
                Console.WriteLine(playedMatch.ToString());
        }
    }

    internal class FootballTeam
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }

    internal class Match
    {
        private readonly FootballTeam _team1;
        private readonly FootballTeam _team2;
        private (int ScoreTeam1, int ScoreTeam2) _score;

        public Match(FootballTeam team1, FootballTeam team2)
        {
            _team1 = team1;
            _team2 = team2;
        }

        public void Play()
        {
            var random = new Random();

            _score.ScoreTeam1 = random.Next(0, 8);
            _score.ScoreTeam2 = random.Next(0, 8);

            _team1.Score += _score.ScoreTeam1;
            _team2.Score += _score.ScoreTeam2;
        }

        public override string ToString() =>
            $"Match result: {_team1.Name} {_score.ScoreTeam1} : {_team2.Name} {_score.ScoreTeam2}";
    }
}