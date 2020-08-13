using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorDesignPattern.Structural
{
    public abstract class Colleague
    {
        protected Mediator _mediator;

        //public Colleague(Mediator mediator)
        //{
        //    this._mediator = mediator;
        //}

       
        internal void SetMediator(Mediator mediator)
        {
            _mediator = mediator;
        }

        public virtual void Send(string message)
        {
            this._mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}
