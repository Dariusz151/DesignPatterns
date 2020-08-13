using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorDesignPattern.ChatApp
{
    public class TeamChatroom : Chatroom
    {
        private List<TeamMember> members = new List<TeamMember>();

        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            this.members.Add(member);
        }

        public override void Send(string from, string message)
        {
            this.members.ForEach(m=> m.Receive(from, message));
        }

        //public override void SendTo<T>(string @from, string message)
        //{
        //    var name = typeof(T).Name;
        //    var memberTo = this.members.Single(m => m.Name.Equals(name));
        //    var memberFrom = this.members.Single(m => m.Name.Equals(@from));

        //    memberTo.Receive(memberFrom.Name, message);

        //}

        public override void SendTo<T>(string @from, string message)
        {
            this.members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] teamMembers)
        {
            foreach (var member in teamMembers)
            {
                this.Register(member);
            }
        }
    }
}
