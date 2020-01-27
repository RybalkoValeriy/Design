using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Behaviors
{
    public abstract class AbstractMediator
    {
        public abstract void Send(string msg, AbstractColleague colleague);
    }

    public abstract class AbstractColleague
    {
        protected AbstractMediator mediator;

        public AbstractColleague(AbstractMediator mediator)
        {
            this.mediator = mediator;
        }
    }

    public class ConcreteMediator : AbstractMediator
    {
        public Farmer Farmer { get; set; }
        public Cannery Cannery { get; set; }
        public Shop Shop { get; set; }

        public override void Send(string msg, AbstractColleague colleague)
        {
            if(colleague == Farmer)
                Cannery.MakeKetchup(msg);
            else if(colleague == Cannery)
                Shop.SellKetchup(msg);
        }
    }


    public class Farmer : AbstractColleague
    {
        public Farmer(AbstractMediator mediator) : base(mediator) { }

        public void GrowTomato()
        {
            string tomato = "Tomato";

            var mess = $"{this.GetType()} grows {tomato}";

            Console.WriteLine(mess);

            mediator.Send(mess, this);

        }
    }

    public class Cannery : AbstractColleague
    {
        public Cannery(AbstractMediator mediator) : base(mediator) { }

        public void MakeKetchup(string message)
        {
            var typeKetchup = message + " ketchup";
            Console.WriteLine(typeKetchup);
            mediator.Send(typeKetchup, this);
        }
    }

    public class Shop : AbstractColleague
    {
        public Shop(AbstractMediator mediator) : base(mediator) { }

        public void SellKetchup(string message)
        {
            Console.WriteLine("sold "+ message);
        }
    }
}
