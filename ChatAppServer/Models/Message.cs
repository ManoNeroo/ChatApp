//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatAppServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public string id { get; set; }
        public string conversationId { get; set; }
        public int senderId { get; set; }
        public string content { get; set; }
        public string messageType { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}