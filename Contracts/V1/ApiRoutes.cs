namespace RestAPI.Contracts.V1
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Posts
        {
            private const string postsEndpoint = "/posts";
            public const string Get = Base + postsEndpoint + "/{postId}";
            public const string Update = Base + postsEndpoint + "/{postId}";
            public const string Delete = Base + postsEndpoint + "/{postId}";
            public const string GetAll = Base + postsEndpoint;
            public const string Create = Base + postsEndpoint;
        }
    }
}
