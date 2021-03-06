﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VaultSharp.Backends.Authentication.Models;
using VaultSharp.Backends.Authentication.Models.Token;
using VaultSharp.Backends.System.Models;
using Xunit;

namespace VaultSharp.UnitTests
{
    public class VaultClientTests
    {
        private static readonly Uri VaultUri = new Uri("http://dummy");

        private static readonly IAuthenticationInfo DummyAuthenticationInfo = new TokenAuthenticationInfo("test");

        [Fact]
        public void ConstructorThrowsOnInvalidInputs()
        {
            Assert.Throws<ArgumentNullException>(() => new VaultClient(null, DummyAuthenticationInfo));
        }

        [Fact]
        public void CanInstantiateWithMinimalParameters()
        {
            var client1 = new VaultClient(VaultUri, null);
            Assert.NotNull(client1);

            var client2 = new VaultClient(VaultUri, DummyAuthenticationInfo);
            Assert.NotNull(client2);

            var client3 = new VaultClient(VaultUri, DummyAuthenticationInfo, true);
            Assert.NotNull(client3);

            var client4 = new VaultClient(VaultUri, DummyAuthenticationInfo, true, TimeSpan.FromMinutes(3));
            Assert.NotNull(client4);
        }

        [Fact]
        public async Task NullTests()
        {
            var client = new VaultClient(VaultUri, DummyAuthenticationInfo, true, TimeSpan.FromMinutes(3));

            await Assert.ThrowsAsync<ArgumentNullException>(() => client.QuickUnsealAsync(null));
            await
                Assert.ThrowsAsync<ArgumentNullException>(() => client.GetMountedSecretBackendConfigurationAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.MountSecretBackendAsync(null));
            await
                Assert.ThrowsAsync<ArgumentNullException>(
                    () => client.TuneSecretBackendConfigurationAsync(null, new MountConfiguration()));

            await Assert.ThrowsAsync<ArgumentNullException>(() => client.UnmountSecretBackendAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RemountSecretBackendAsync(null, "a"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RemountSecretBackendAsync("a", null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.EnableAuthenticationBackendAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.DisableAuthenticationBackendAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.EnableMultiFactorAuthenticationAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.WriteDuoAccessAsync(null, "a", "a", "a"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.WriteDuoConfigurationAsync(null, "a", "a"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetPolicyAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.WritePolicyAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.WritePolicyAsync(new Policy()));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.DeletePolicyAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.EnableAuditBackendAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.DisableAuditBackendAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.HashWithAuditBackendAsync(null, "a"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RenewSecretAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RevokeSecretAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RevokeAllSecretsOrTokensUnderPrefixAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ForceRevokeAllSecretsOrTokensUnderPrefixAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ContinueRekeyAsync(null, "nonce"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ContinueRekeyAsync("masterShareKey", null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ReadRawSecretAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ContinueRootTokenGenerationAsync(null, "nonce"));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ContinueRootTokenGenerationAsync("masterShareKey", null));

            await
                Assert.ThrowsAsync<ArgumentNullException>(
                    () => client.WriteRawSecretAsync(null, new Dictionary<string, object>()));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.WriteRawSecretAsync("a", null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.DeleteRawSecretAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.ReadSecretAsync(null));
            await
                Assert.ThrowsAsync<ArgumentNullException>(
                    () => client.WriteSecretAsync(null, new Dictionary<string, object>()));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.DeleteSecretAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetTokenInfoAsync(null));
            await Assert.ThrowsAsync<ArgumentNullException>(() => client.RevokeTokenAsync(null, true));
        }
    }
}