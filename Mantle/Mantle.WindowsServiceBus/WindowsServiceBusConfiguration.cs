﻿using System;
using System.Configuration;
using Mantle.Configuration;


namespace Mantle.WindowsServiceBus
{
    public class WindowsServiceBusConfiguration : IWindowsServiceBusConfiguration, IConfigurable
    {
        public string ConnectionString { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(ConnectionString))
                throw new ConfigurationErrorsException("Windows service bus connection string is required.");
        }

        public void Configure(IConfigurationMetadata metadata)
        {
            if (metadata == null)
                throw new ArgumentNullException("metadata");

            if (metadata.Properties.ContainsKey(ConfigurationProperties.ConnectionString))
                ConnectionString = metadata.Properties[ConfigurationProperties.ConnectionString];

            Validate();
        }

        public void Configure(string connectionString)
        {
            ConnectionString = connectionString;

            Validate();
        }

        public static class ConfigurationProperties
        {
            public const string ConnectionString = "ConnectionString";
        }
    }
}