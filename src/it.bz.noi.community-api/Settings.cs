﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace it.bz.noi.community_api
{
    public class Settings
    {
        private readonly Uri serviceUri;
        private readonly string clientId;
        private readonly string tenantId;
        private readonly string clientSecret;
        private readonly string[] scopes;

        private Settings()
        {
            serviceUri = new Uri(GetEnv("SERVICE_URL"));
            clientId = GetEnv("CLIENT_ID")!;
            tenantId = GetEnv("TENANT_ID")!;
            clientSecret = GetEnv("CLIENT_SECRET")!;
            scopes = new[] { GetEnv("SERVICE_SCOPE")! };
        }

        private static string GetEnv(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? throw new Exception($"Environment variable {key} not set.");
        }

        public Uri ServiceUri => serviceUri;

        public string ClientId => clientId;

        public string TenantId => tenantId;

        public string ClientSecret => clientSecret;

        public string[] Scopes => scopes;

        public static Settings Initialize()
        {
            return new Settings();
        }
    }
}
