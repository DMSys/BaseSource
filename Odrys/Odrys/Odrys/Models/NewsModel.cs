using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Odrys.Helpers;

namespace Odrys.Models
{
    public class NewsContext : Odrys.Models.MSSQLContext
    {
        public NewsContext()
        { }

        public List<NewsModel> GetNews(int category = 0)
        {
            List<NewsModel> news = new List<NewsModel>();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = base.SQLConnection;
                command.CommandText =
@"SELECT ns.ID
      , ns.N_GUID
      , ns.N_TITLE
      , ns.N_DESCRIPTION
      , ns.N_BODY
      , ns.N_PUB_DATE
      , ns.N_CATEGORY_ID
      , ns.N_SAIT_ID
      , ns.N_LINK
  FROM NEWS ns";
                using (SqlDataReader dReader = command.ExecuteReader())
                {
                    if (dReader.HasRows)
                    {
                        while (dReader.Read())
                        {
                            NewsModel item = new NewsModel();
                            item.ID = TryParse.ToInt32(dReader["ID"]);
                            item.Title = dReader["N_TITLE"].ToString();
                            item.Description = dReader["N_DESCRIPTION"].ToString();
                            item.Body = dReader["N_BODY"].ToString();

                            news.Add(item);
                        }
                    }
                }
            }
            return news;
        }
    }

    public class NewsModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }
    }
}