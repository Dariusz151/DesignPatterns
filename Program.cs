using System;
using MediatorDesignPattern.ChatApp;
using MediatorDesignPattern.Structural;

namespace MediatorDesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var mediator = new ConcreteMediator();

            //var c1 = new Colleague1();
            //var c2 = new Colleague2();

            //mediator.Register(c1);
            //mediator.Register(c2);

            //c1.Send("siema");
            //c2.Send("Elo");

            //Console.ReadLine();

            var teamChat = new TeamChatroom();

            var steve = new Developer("Steve");
            var dariusz = new Developer("Darius");
            var adam = new Tester("Adam");

            teamChat.RegisterMembers(steve, dariusz, adam);

            dariusz.Send("siema wszyscy");
            adam.Send("eldo all");

            steve.SendTo<Developer>("siema developerzy");

            Console.ReadLine();
        }
    }
}
