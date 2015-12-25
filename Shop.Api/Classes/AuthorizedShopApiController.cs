using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Api.Classes
{
    public class AuthorizedShopApiController<TEntity, TKey> : ShopApiController<TEntity, TKey> where TEntity : class
    {
    }
}