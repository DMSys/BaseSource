using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Odrys.Models;

namespace System.Web.Mvc
{
    public static class NewsHelpers
    {
        public static List<NewsModel> NewsList(this HtmlHelper helper, int category = 0)
        {
            List<NewsModel> news = null;
            using (Odrys.Models.NewsContext context = new Odrys.Models.NewsContext())
            {
                news = context.GetNews(category);
            }
            return news;
        }
    }
}