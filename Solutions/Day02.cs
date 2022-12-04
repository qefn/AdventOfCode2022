namespace AdventOfCode2022.Solutions {
    public class Day02 : Solution {
        public override List<Action> Stages => new List<Action> { Stage1And2 };

        public void Stage1And2() {
            List<RpsRound> rounds = ReadInputFile("D2").Select(i => new RpsRound(i[0], i[2], i[2])).ToList();
            int totalScoreMySign = rounds.Sum(r => r.GetScoreMySign());
            Console.WriteLine($"My total RPS score based on my sign is: {totalScoreMySign}");

            int totalScoreExpectedOutcome = rounds.Sum(r => r.GetScoreExpectedOutcome());
            Console.WriteLine($"My total RPS score based on expected outcome is: {totalScoreExpectedOutcome}");
        }

        private class RpsRound {
            public RpsRound(char opponent, char my, char expectedOutcome) {
                Opponent = Translate(opponent);
                My = Translate(my);
                ExpectedOutcome = expectedOutcome;
            }

            private RpsSigns Opponent { get; }

            private RpsSigns My { get; }

            private char ExpectedOutcome { get; }

            internal int GetScoreExpectedOutcome() {
                if (ExpectedOutcome == 'Y') {
                    return GetScore(Opponent, Opponent);
                }

                if (ExpectedOutcome == 'X') {
                    RpsSigns losingSign = (int)Opponent - 1 > 0 ? Opponent - 1 : Opponent + 2;
                    return GetScore(Opponent, losingSign);
                }

                RpsSigns winningSign = (int)Opponent + 1 <= 3 ? Opponent + 1 : Opponent - 2;
                return GetScore(Opponent, winningSign);
            }

            internal int GetScoreMySign() {
                return GetScore(Opponent, My);
            }

            private int GetScore(RpsSigns opponent, RpsSigns my) {
                int score = (int)my;
                if (opponent == my) {
                    return score + 3;
                }
                if (opponent == RpsSigns.Rock) {
                    return my == RpsSigns.Scissors ? score + 0 : score + 6;
                }
                if (opponent == RpsSigns.Scissors) {
                    return my == RpsSigns.Rock ? score + 6 : score + 0;
                }


                return opponent > my ? score + 0 : score + 6;
            }

            private RpsSigns Translate(char c) {
                switch (c) {
                    case 'A':
                    case 'X':
                        return RpsSigns.Rock;
                    case 'B':
                    case 'Y':
                        return RpsSigns.Paper;
                    case 'C':
                    case 'Z':
                        return RpsSigns.Scissors;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            private enum RpsSigns {
                Rock = 1,
                Paper = 2,
                Scissors = 3
            }
        }
    }
}
