using System;
using System.Threading.Tasks;
using Flurl.Http;
using Goblin.Core.Errors;

namespace Goblin.Api_Base.Share
{
    public static class FlurlHttpExceptionHelper
    {
        public static async Task HandleErrorAsync(FlurlHttpException ex)
        {
            var goblinErrorModel = await ex.GetResponseJsonAsync<GoblinErrorModel>().ConfigureAwait(true);

            if (goblinErrorModel != null)
            {
                throw new GoblinException(goblinErrorModel);
            }

            var responseString = await ex.GetResponseStringAsync().ConfigureAwait(true);

            var message = string.IsNullOrWhiteSpace(responseString) ? ex.Message : responseString;

            throw new Exception(message);
        }
    }
}