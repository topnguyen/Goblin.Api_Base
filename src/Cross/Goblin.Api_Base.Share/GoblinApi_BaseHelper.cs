using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using Goblin.Core.Constants;
using Goblin.Api_Base.Share.Models;
using Goblin.Core.Settings;

namespace Goblin.Api_Base.Share
{
    public static class GoblinApi_BaseHelper
    {
        public static string Domain { get; set; } = string.Empty;

        public static string AuthorizationKey { get; set; } = string.Empty;

        public static readonly ISerializer JsonSerializer = new NewtonsoftJsonSerializer(GoblinJsonSetting.JsonSerializerSettings);

        private static IFlurlRequest GetRequest(long? loggedInUserId)
        {
            var request = Domain.WithHeader(GoblinHeaderKeys.Authorization, AuthorizationKey);

            if (loggedInUserId != null)
            {
                request = request.WithHeader(GoblinHeaderKeys.UserId, loggedInUserId);
            }

            request = request.ConfigureRequest(x => { x.JsonSerializer = JsonSerializer; });

            return request;
        }

        public static async Task<GoblinApi_BaseSampleModel> CreateAsync(GoblinApi_BaseCreateSampleModel model, CancellationToken cancellationToken = default)
        {
            try
            {
                var endpoint = GetRequest(model.LoggedInUserId).AppendPathSegment(GoblinApi_BaseEndpoints.CreateSample);

                var fileModel = await endpoint
                    .PostJsonAsync(model, cancellationToken: cancellationToken)
                    .ReceiveJson<GoblinApi_BaseSampleModel>()
                    .ConfigureAwait(true);

                return fileModel;
            }
            catch (FlurlHttpException ex)
            {
                await FlurlHttpExceptionHelper.HandleErrorAsync(ex).ConfigureAwait(true);

                return null;
            }
        }

        public static async Task<GoblinApi_BaseSampleModel> GetAsync(GoblinApi_BaseGetFileModel model, CancellationToken cancellationToken = default)
        {
            var endpoint = GetRequest(model.LoggedInUserId).AppendPathSegment(GoblinApi_BaseEndpoints.GetSample.Replace("{id}", model.Id.ToString()));

            var fileModel =
                await endpoint
                    .GetJsonAsync<GoblinApi_BaseSampleModel>(cancellationToken: cancellationToken)
                    .ConfigureAwait(true);

            return fileModel;
        }

        public static async Task DeleteAsync(GoblinApi_BaseDeleteSampleModel model, CancellationToken cancellationToken = default)
        {
            var endpoint = GetRequest(model.LoggedInUserId).AppendPathSegment(GoblinApi_BaseEndpoints.DeleteSample.Replace("{id}", model.Id.ToString()));

            await endpoint
                .DeleteAsync(cancellationToken)
                .ConfigureAwait(true);
        }
    }
}