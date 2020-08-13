using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDesignPattern.Structural
{
    public class Colleague1 : Colleague
    {
        //public Colleague1() 
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague1 receives notification message: {message}");
        }
    }
}
