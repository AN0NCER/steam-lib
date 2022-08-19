using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamAuth
{
    public class ISteamUser
    {
        private SessionData _sessionData;

        /// <summary>
        /// Used to access information and interact with users.
        /// </summary>
        public ISteamUser(SessionData sessionData) => _sessionData = sessionData;

        /// <summary>
        /// Gets information about a Steam user
        /// </summary>
        /// <param name="steamids">Comma-delimited list of SteamIDs (max: 100)</param>
        public SteamResponseUsers GetPlayerSummaries(params string[] steamids)
        {
            string ids = String.Join(",", steamids);
            string url = $"{APIEndpoints.STEAMAPI_BASE}/ISteamUser/GetPlayerSummaries/v2/?access_token=" +
                $"{_sessionData.OAuthToken}&" +
                $"{nameof(steamids)}={ids}&key=";

            string response = SteamWeb.Request(url, "GET", "");
            return JsonConvert.DeserializeObject<SteamResponseUsers>(response);
        }
    }

    public partial class SteamResponseUsers
    {
        [JsonProperty("response")]
        public Response UserResponse { get; set; }

        public partial class Response
        {
            [JsonProperty("players")]
            public List<Player> Players { get; set; }
        }

        public partial class Player
        {
            [JsonProperty("steamid")]
            public string Steamid { get; set; }

            [JsonProperty("communityvisibilitystate")]
            public long Communityvisibilitystate { get; set; }

            [JsonProperty("profilestate")]
            public long Profilestate { get; set; }

            [JsonProperty("personaname")]
            public string Personaname { get; set; }

            [JsonProperty("profileurl")]
            public Uri Profileurl { get; set; }

            [JsonProperty("avatar")]
            public Uri Avatar { get; set; }

            [JsonProperty("avatarmedium")]
            public Uri Avatarmedium { get; set; }

            [JsonProperty("avatarfull")]
            public Uri Avatarfull { get; set; }

            [JsonProperty("avatarhash")]
            public string Avatarhash { get; set; }

            [JsonProperty("personastate")]
            public long Personastate { get; set; }

            [JsonProperty("realname")]
            public string Realname { get; set; }

            [JsonProperty("primaryclanid")]
            public string Primaryclanid { get; set; }

            [JsonProperty("timecreated")]
            public long Timecreated { get; set; }

            [JsonProperty("personastateflags")]
            public long Personastateflags { get; set; }
        }
    }
}