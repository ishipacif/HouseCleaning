using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HouseCleanersApi.Helper
{
    public class ChallengeMiddleware
    {
        private static void writeErrorResponse(HttpContext Context, params string[] Errors)
        {
            Context.Response.ContentType = "application/json";
            using (var writer = new Utf8JsonWriter(Context.Response.BodyWriter))
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isValid", false);
                writer.WriteStartArray("errors");

                foreach (var error in Errors)
                {
                    writer.WriteStringValue(error);
                }

                writer.WriteEndArray();
                writer.WriteEndObject();
                writer.Flush();
            }
        }

        private readonly RequestDelegate _request;

        public ChallengeMiddleware(RequestDelegate RequestDelegate)
        {
            if (RequestDelegate == null)
            {
                throw new ArgumentNullException(nameof(RequestDelegate)
                    , nameof(RequestDelegate) + " is required");
            }

            _request = RequestDelegate;
        }

        public async Task InvokeAsync(HttpContext Context)
        {
            if (Context == null)
            {
                throw new ArgumentNullException(nameof(Context)
                    , nameof(Context) + " is required");
            }

            await _request(Context);

            if (Context.Response.StatusCode == 401)
            {
                writeErrorResponse(Context, "Request unauthorized, Please log in");
            }
        }

    }
}
