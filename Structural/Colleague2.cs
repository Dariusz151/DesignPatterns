using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDesignPattern.Structural
{
    public class Colleague2 : Colleague
    {
        //public Colleague2()
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague2 receives notification message: {message}");
        }
    }
}
