﻿using System;
using Mantle.Cache.Interfaces;
using Mantle.Configuration.Attributes;
using Mantle.Extensions;
using Microsoft.ApplicationServer.Caching;

namespace Mantle.Sample.SubscriberConsole.Mantle.Platforms.Azure.Cache.Clients
{
    public class AzureManagedCacheClient<T> : ICacheClient<T>
        where T : class
    {
        private DataCache dataCache;

        [Configurable]
        public string CacheName { get; set; }

        public DataCache DataCache
        {
            get { return GetDataCache(); }
        }

        public T Get(string objectId)
        {
            objectId.Require("objectId");

            var cachedObject = DataCache.Get(objectId);

            if (cachedObject == null)
                return default(T);

            return ((T) (cachedObject));
        }

        public void Put(T @object, string objectId, TimeSpan? cacheDuration = null)
        {
            @object.Require("object");
            objectId.Require("objectId");

            if (cacheDuration == null)
                DataCache.Put(objectId, @object);
            else
                DataCache.Put(objectId, @object, cacheDuration.Value);
        }

        private DataCache GetDataCache()
        {
            return (dataCache = (dataCache ?? (new DataCache(CacheName ?? "default"))));
        }
    }
}