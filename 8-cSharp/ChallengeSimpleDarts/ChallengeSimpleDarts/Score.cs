using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Darts;

namespace ChallengeSimpleDarts
{
    public class Score
    {
        public static void ScoreDart(Player player, Dart dart)
        {
            int score = 0;

            if (dart.isDouble)
                score = dart.Score * 2;
            else if (dart.isTriple)
                score = dart.Score * 3;
            else
                score = dart.Score;

            if (dart.isBullsEye && dart.isTriple)
                score = 50;
            else if (dart.isBullsEye)
                score = 25;

            player.Score += score;
        }
    }
}