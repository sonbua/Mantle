﻿using System.Collections.Generic;

namespace Mantle.Messaging.Messages
{
    public class Message
    {
        public Message()
        {
            BodyTypeTokens = new List<string>();
            Properties = new Dictionary<string, string>();
        }

        public string Id { get; set; }
        public string CorrelationId { get; set; }
        public string Label { get; set; }

        public string Body { get; set; }
        public List<string> BodyTypeTokens { get; set; }

        public int TimeToLive { get; set; }

        public Dictionary<string, string> Properties { get; set; }
    }
}