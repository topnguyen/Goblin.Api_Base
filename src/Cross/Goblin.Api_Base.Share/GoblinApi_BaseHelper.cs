using System;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Goblin.Core.Constants;
using Goblin.Core.Errors;
using Goblin.Api_Base.Share.Models;

namespace Goblin.Api_Base.Share
{
    public static class GoblinApi_BaseHelper
    {
        public static string Domain { get; set; } = string.Empty;

        public static async Task<GoblinApi_BaseSampleModel> CreateAsync(GoblinApi_BaseCreateSampleModel model,
            CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = Domain;

                var fileModel = await endpoint
                    .AppendPathSegment(GoblinApi_BaseEndpoints.CreateSample)
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
            var endpoint = Domain.Replace("{id}", model.Id.ToString());

            var fileModel =
                await endpoint
                    .AppendPathSegment(GoblinApi_BaseEndpoints.GetSample)
                    .WithHeader(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                    .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .SetQueryParam(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                    .SetQueryParam(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                    .GetJsonAsync<GoblinApi_BaseSampleModel>(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);

            return fileModel;
        }

        public static async Task DeleteAsync(GoblinApi_BaseDeleteSampleModel model,
            CancellationToken cancellationToken = default)
        {
            var endpoint = Domain.Replace("{id}", model.Id.ToString());

            await endpoint
                .AppendPathSegment(GoblinApi_BaseEndpoints.DeleteSample)
                .WithHeader(GoblinHeaderKeys.Authorization, model.AuthorizationKey)
                .WithHeader(GoblinHeaderKeys.UserId, model.LoggedInUserId)
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(true);
        }
    }
}