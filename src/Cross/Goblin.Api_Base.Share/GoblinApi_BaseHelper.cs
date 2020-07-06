using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Goblin.Core.Constants;
using Goblin.Core.Errors;
using Goblin.Api_Base.Share.Models;
using Goblin.Core.Settings;

namespace Goblin.Api_Base.Share
{
    public static class GoblinApi_BaseHelper
    {
        public static string Domain { get; set; } = string.Empty;
        
        public static string AuthorizationKey { get; set; } = string.Empty;
        
        public static readonly ISerializer JsonSerializer = new NewtonsoftJsonSerializer(GoblinJsonSetting.JsonSerializerSettings);

        public static async Task<GoblinApi_BaseSampleModel> CreateAsync(GoblinApi_BaseCreateSampleModel model,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = Domain
                    .WithHeader(GoblinHeaderKeys.Authorization, AuthorizationKey)
                    .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .AppendPathSegment(GoblinApi_BaseEndpoints.CreateSample);

                var fileModel = await endpoint
                    .ConfigureRequest(x =>
                    {
                        x.JsonSerializer = JsonSerializer;
                    })
                    .PostJsonAsync(model, cancellationToken: cancellationToken)
                    .ReceiveJson<GoblinApi_BaseSampleModel>()
                    .ConfigureAwait(true);

                return fileModel;
            }
            catch (FlurlHttpException ex)
            {
                var goblinErrorModel = await ex.GetResponseJsonAsync<GoblinErrorModel>().ConfigureAwait(true);

                if (goblinErrorModel != null)
                {
                    throw new GoblinException(goblinErrorModel);
                }

                var responseString = await ex.GetResponseStringAsync().ConfigureAwait(true);

                var message = responseString ?? ex.Message;

                throw new Exception(message);
            }
        }

        public static async Task<GoblinApi_BaseSampleModel> GetAsync(GoblinApi_BaseGetFileModel model,
            CancellationToken cancellationToken = default)
        {
            var endpoint =
                Domain
                    .WithHeader(GoblinHeaderKeys.Authorization, AuthorizationKey)
                    .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .AppendPathSegment(GoblinApi_BaseEndpoints.GetSample.Replace("{id}", model.Id.ToString()));

            var fileModel =
                await endpoint
                    .ConfigureRequest(x =>
                    {
                        x.JsonSerializer = JsonSerializer;
                    })
                    .GetJsonAsync<GoblinApi_BaseSampleModel>(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);

            return fileModel;
        }

        public static async Task DeleteAsync(GoblinApi_BaseDeleteSampleModel model,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Domain
                .WithHeader(GoblinHeaderKeys.Authorization, AuthorizationKey)
                .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                .AppendPathSegment(GoblinApi_BaseEndpoints.DeleteSample.Replace("{id}", model.Id.ToString()));

            await endpoint
                .ConfigureRequest(x =>
                {
                    x.JsonSerializer = JsonSerializer;
                })
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(true);
        }
    }
}