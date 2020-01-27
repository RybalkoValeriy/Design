using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Behaviors
{
    public abstract class GameEventArgs : EventArgs
    {
        public abstract void Print();
    }


    public class PlayerScoredEventArgs : GameEventArgs
    {
        public string PlayerName { get; set; }
        public int GoalsScored { get; set; }

        public PlayerScoredEventArgs(string playerName, int goalsScored)
        {
            PlayerName = playerName;
            GoalsScored = goalsScored;
        }
        public override void Print()
            => Console.WriteLine($"Player: {PlayerName} goals: {GoalsScored}");
    }


    public class GameMediator
    {
        public event EventHandler<GameEventArgs> _ev;

        public void Fire(GameEventArgs gameEventArgs)
            => _ev?.Invoke(this, gameEventArgs);
    }


    public class Player
    {
        public string Name { get; set; }
        public int Goals { get; set; }

        private GameMediator gameMediator;

        public Player(string name, GameMediator gameMediator)
        {
            this.gameMediator = gameMediator;
            Name = name;
        }

        public void Scored()
        {
            Goals++;
            var args = new PlayerScoredEventArgs(Name,Goals);
            gameMediator.Fire(args);
        }
    }

    public class Coach
    {
        private GameMediator _gameMediator;

        public Coach(GameMediator gameMediator)
        {
            this._gameMediator = gameMediator;

            gameMediator._ev += (sender, args) =>
            {
                if (args is PlayerScoredEventArgs s && s.GoalsScored < 3)
                {
                    Console.WriteLine($"good job {s.PlayerName}");
                }
                args.Print();
            };
        } 
    }

}
