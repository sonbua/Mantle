﻿using Mantle.Messaging;
using Mantle.Messaging.Msmq;
using Ninject.Modules;

namespace Mantle.Sample.AddressBook.Web.Mantle
{
    public class MsmqModule : NinjectModule
    {
        public override void Load()
        {
            LoadPublisherEndpoints();
            LoadSubscriberEndpoints();
        }

        private void LoadPublisherEndpoints()
        {
            // TODO: Setup publisher endpoints.

            Bind<IPublisherEndpoint>()
                .To<MsmqPublisherEndpoint>()
                .InSingletonScope()
                .OnActivation(
                    c => c.Setup("PersonQueue",
                                 "Replace this text with the path to your MSMQ queue."));
        }

        private void LoadSubscriberEndpoints()
        {
            // TODO: Setup subscriber endpoints.
        }
    }
}