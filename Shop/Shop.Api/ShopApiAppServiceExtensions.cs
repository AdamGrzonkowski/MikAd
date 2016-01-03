using System;
using System.Net.Http;
using Microsoft.Azure.AppService;

namespace Shop
{
    public static class ShopApiAppServiceExtensions
    {
        public static ShopApi CreateShopApi(this IAppServiceClient client)
        {
            return new ShopApi(client.CreateHandler());
        }

        public static ShopApi CreateShopApi(this IAppServiceClient client, params DelegatingHandler[] handlers)
        {
            return new ShopApi(client.CreateHandler(handlers));
        }

        public static ShopApi CreateShopApi(this IAppServiceClient client, Uri uri, params DelegatingHandler[] handlers)
        {
            return new ShopApi(uri, client.CreateHandler(handlers));
        }

        public static ShopApi CreateShopApi(this IAppServiceClient client, HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
        {
            return new ShopApi(rootHandler, client.CreateHandler(handlers));
        }
    }
}
