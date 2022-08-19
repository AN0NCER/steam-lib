using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace SteamAuth
{
    public class IEconService
    {
        private SessionData _sessionData;

        /// <summary>
        /// Additional Steam Economy methods that provide access to Steam Trading.
        /// </summary>
        public IEconService(SessionData session)
        {
            _sessionData = session;
        }

        /// <summary>
        /// Gets a specific trade offer
        /// </summary>
        /// <param name="tradeofferid">ID offer</param>
        /// <param name="get_descriptions">If set, the item display data for the items included in the returned trade offers will also be returned. If one or more descriptions can't be retrieved, then your request will fail.</param>
        public TradeResponseOffer GetTradeOffer(ulong tradeofferid,bool get_descriptions = true)
        {
            string url = $"{APIEndpoints.STEAMAPI_BASE}/IEconService/GetTradeOffer/v1/?access_token=" +
                $"{_sessionData.OAuthToken}&" +
                $"{nameof(tradeofferid)}={tradeofferid}&" +
                $"{nameof(get_descriptions)}={get_descriptions}";

            string response = SteamWeb.Request(url, "GET", "");
            return JsonConvert.DeserializeObject<TradeResponseOffer>(response);
        }


        /// <summary>
        /// Get a list of sent or received trade offers
        /// </summary>
        /// <param name="get_sent_offers">Request the list of sent offers.</param>
        /// <param name="get_received_offers">Request the list of sent offers.</param>
        /// <param name="get_descriptions">If set, the item display data for the items included in the returned trade offers will also be returned. If one or more descriptions can't be retrieved, then your request will fail.</param>
        /// <param name="active_only">Indicates we should only return offers which are still active, or offers that have changed in state since the time_historical_cutoff</param>
        /// <param name="historical_only">Indicates we should only return offers which are not active.</param>
        public TradeResponseOffers GetTradeOffers(bool get_sent_offers = false,bool get_received_offers = false,bool get_descriptions = true,bool active_only = false,bool historical_only = false)
        {
            string url = $"" +
                $"{APIEndpoints.STEAMAPI_BASE}/IEconService/GetTradeOffers/v1/?access_token=" +
                $"{_sessionData.OAuthToken}&" +
                $"{nameof(get_sent_offers)}={get_sent_offers}&" +
                $"{nameof(get_received_offers)}={get_received_offers}&" +
                $"{nameof(get_descriptions)}={get_descriptions}&" +
                $"{nameof(active_only)}={active_only}&" +
                $"{nameof(historical_only)}={historical_only}";

            string response = SteamWeb.Request(url, "GET", "");
            return JsonConvert.DeserializeObject<TradeResponseOffers>(response);
        }
    }

    /// <summary>
    /// Response All Offers
    /// </summary>
    public partial class TradeResponseOffers : TradeResponseOffer
    {
        [JsonProperty("response")]
        public Response TradeResponse { get; set; }

        public partial class Response
        {
            [JsonProperty("trade_offers_sent")]
            public List<TradeOffersSent> TradeOffersSent { get; set; }

            [JsonProperty("descriptions")]
            public List<ResponseDescription> Descriptions { get; set; }

            [JsonProperty("next_cursor")]
            public long NextCursor { get; set; }
        }

        public partial class TradeOffersSent
        {
            [JsonProperty("tradeofferid")]
            public string Tradeofferid { get; set; }

            [JsonProperty("accountid_other")]
            public long AccountidOther { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("expiration_time")]
            public long ExpirationTime { get; set; }

            [JsonProperty("trade_offer_state")]
            public long TradeOfferState { get; set; }

            [JsonProperty("items_to_give")]
            public List<ItemsToGive> ItemsToGive { get; set; }

            [JsonProperty("is_our_offer")]
            public bool IsOurOffer { get; set; }

            [JsonProperty("time_created")]
            public long TimeCreated { get; set; }

            [JsonProperty("time_updated")]
            public long TimeUpdated { get; set; }

            [JsonProperty("from_real_time_trade")]
            public bool FromRealTimeTrade { get; set; }

            [JsonProperty("escrow_end_date")]
            public long EscrowEndDate { get; set; }

            [JsonProperty("confirmation_method")]
            public long ConfirmationMethod { get; set; }
        }
    }

    /// <summary>
    /// Response Offer Information
    /// </summary>
    public partial class TradeResponseOffer
    {
        [JsonProperty("response")]
        public Response TradeResponse { get; set; }

        public partial class Response
        {
            [JsonProperty("offer")]
            public Offer Offer { get; set; }

            [JsonProperty("descriptions")]
            public List<ResponseDescription> Descriptions { get; set; }
        }

        public partial class ResponseDescription
        {
            [JsonProperty("appid")]
            public long Appid { get; set; }

            [JsonProperty("classid")]
            public string Classid { get; set; }

            [JsonProperty("instanceid")]
            public long Instanceid { get; set; }

            [JsonProperty("currency")]
            public bool Currency { get; set; }

            [JsonProperty("background_color")]
            public string BackgroundColor { get; set; }

            [JsonProperty("icon_url")]
            public string IconUrl { get; set; }

            [JsonProperty("icon_url_large")]
            public string IconUrlLarge { get; set; }

            [JsonProperty("descriptions")]
            public List<DescriptionDescription> Descriptions { get; set; }

            [JsonProperty("tradable")]
            public bool Tradable { get; set; }

            [JsonProperty("owner_actions")]
            public List<OwnerAction> OwnerActions { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("market_name")]
            public string MarketName { get; set; }

            [JsonProperty("market_hash_name")]
            public string MarketHashName { get; set; }

            [JsonProperty("market_fee_app")]
            public long MarketFeeApp { get; set; }

            [JsonProperty("commodity")]
            public bool Commodity { get; set; }

            [JsonProperty("market_tradable_restriction")]
            public long MarketTradableRestriction { get; set; }

            [JsonProperty("market_marketable_restriction")]
            public long MarketMarketableRestriction { get; set; }

            [JsonProperty("marketable")]
            public bool Marketable { get; set; }

            [JsonProperty("tags")]
            public List<Tag> Tags { get; set; }
        }

        public partial class DescriptionDescription
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }

        public partial class OwnerAction
        {
            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public partial class Tag
        {
            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("internal_name")]
            public string InternalName { get; set; }

            [JsonProperty("localized_category_name")]
            public string LocalizedCategoryName { get; set; }

            [JsonProperty("localized_tag_name")]
            public string LocalizedTagName { get; set; }
        }

        public partial class Offer
        {
            [JsonProperty("tradeofferid")]
            public string Tradeofferid { get; set; }

            [JsonProperty("accountid_other")]
            public long AccountidOther { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("expiration_time")]
            public long ExpirationTime { get; set; }

            [JsonProperty("trade_offer_state")]
            public long TradeOfferState { get; set; }

            [JsonProperty("items_to_give")]
            public List<ItemsToGive> ItemsToGive { get; set; }

            [JsonProperty("is_our_offer")]
            public bool IsOurOffer { get; set; }

            [JsonProperty("time_created")]
            public long TimeCreated { get; set; }

            [JsonProperty("time_updated")]
            public long TimeUpdated { get; set; }

            [JsonProperty("from_real_time_trade")]
            public bool FromRealTimeTrade { get; set; }

            [JsonProperty("escrow_end_date")]
            public long EscrowEndDate { get; set; }

            [JsonProperty("confirmation_method")]
            public long ConfirmationMethod { get; set; }
        }

        public partial class ItemsToGive
        {
            [JsonProperty("appid")]
            public long Appid { get; set; }

            [JsonProperty("contextid")]
            public long Contextid { get; set; }

            [JsonProperty("assetid")]
            public string Assetid { get; set; }

            [JsonProperty("classid")]
            public string Classid { get; set; }

            [JsonProperty("instanceid")]
            public long Instanceid { get; set; }

            [JsonProperty("amount")]
            public long Amount { get; set; }

            [JsonProperty("missing")]
            public bool Missing { get; set; }

            [JsonProperty("est_usd")]
            public long EstUsd { get; set; }
        }
    }
}