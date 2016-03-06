﻿namespace GW2NET.Miscellaneous
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class MockColorMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.Run(() => new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    "{\"id\":10,\"name\":\"Himmel\",\"base_rgb\":[128,26,26],\"cloth\":{\"brightness\":22,\"contrast\":1.25,\"hue\":196,\"saturation\":0.742188,\"lightness\":1.32813,\"rgb\":[54,130,160]},\"leather\":{\"brightness\":22,\"contrast\":1.25,\"hue\":196,\"saturation\":0.664063,\"lightness\":1.32813,\"rgb\":[61,129,156]},\"metal\":{\"brightness\":22,\"contrast\":1.28906,\"hue\":196,\"saturation\":0.546875,\"lightness\":1.32813,\"rgb\":[65,123,146]},\"item\":20370,\"categories\":[\"Blue\",\"Vibrant\",\"Rare\"]}")
                {
                    Headers = { ContentLanguage = { "de" } }
                },
                Headers = { Date = DateTimeOffset.Now },
                RequestMessage = request
            }, cancellationToken);
        }
    }
}
