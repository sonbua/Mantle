﻿using Mantle.Extensions;
using Mantle.Messaging.Interfaces;
using Mantle.Messaging.Messages;

namespace Mantle.Messaging.Contexts
{
    public class SubscriptionMessageContext<T> : IMessageContext<T>
        where T : class
    {
        public SubscriptionMessageContext(IMessageContext<MessageEnvelope> originalMessageContext, T message, ISubscription<T> subscription) 
        {
            originalMessageContext.Require("originalMessageContext");
            message.Require("message");
            subscription.Require("subscription");

            OriginalMessageContext = originalMessageContext;
            Message = message;
            Subscription = subscription;
        }

        public int? DeliveryCount
        {
            get { return OriginalMessageContext.DeliveryCount; }
        }

        public T Message { get; private set; }
        public IMessageContext<MessageEnvelope> OriginalMessageContext { get; private set; }
        public ISubscription<T> Subscription { get; private set; } 

        public bool TryToAbandon()
        {
            return (IsAbandoned = OriginalMessageContext.TryToAbandon());
        }

        public bool TryToComplete()
        {
            return (IsCompleted = OriginalMessageContext.TryToComplete());
        }

        public bool TryToDeadLetter()
        {
            return (IsDeadLettered = OriginalMessageContext.TryToDeadLetter());
        }

        public bool TryToRenewLock()
        {
            return OriginalMessageContext.TryToRenewLock();
        }

        public bool IsAbandoned { get; private set; }
        public bool IsCompleted { get; private set; }
        public bool IsDeadLettered { get; private set; }
    }
}