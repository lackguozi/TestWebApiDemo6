using SqlSugar;

namespace TestWebApiDemo6.Model
{
    [Tenant("db1")]
    public record Article
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long id { get; set; }
        /// <summary>
        /// 标题 也就是名称
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 详细介绍
        /// </summary>
        public string? descript { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string? summary { get; set; }
        /// <summary>
        /// 功效
        /// </summary>
        public string? effect { get; set; }
        public int IsDeleted { get; set; } = 0;
        public DateTime CreationTime { get; private set; }
        /// <summary>
        /// 封面图像
        /// </summary>
        public string? url { get; set; }
        [SugarColumn(IsIgnore = true)]
        public List<string>? urls { get; set; }
        public static Article Create(string title, string desc, string effect, string summary, string url)
        {
            Article item = new Article()
            {

                CreationTime = DateTime.Now,
                title = title,
                descript = desc,
                effect = effect,
                summary = summary,
                url = url
            };
            return item;
        }
    }
    public record ArticleUrl
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long id { get; set; }
        public long artid { get; set; }
        public string url { get; set; }
        //public int IsDeleted { get; set; } = 0;
        //public DateTime CreationTime { get; private set; }
        public static ArticleUrl Create(long id, string url)
        {
            ArticleUrl item = new ArticleUrl()
            {

                //CreationTime = DateTime.Now,
                artid = id,
                url = url,
            };
            return item;
        }
    }
}
