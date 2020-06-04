namespace Goblin.Microservice_Base.Share
{
    public static class Microservice_Base_Endpoints
    {
        public const string Base = "~/sample";

        public const string AddEndpoint = Base; // POST
        public const string GetEndpoint = Base + "/{id}";// GET
        public const string UpdateEndpoint = Base + "/{id}"; // PUT
        public const string DeleteEndpoint = Base + "/{id}"; // Delete
        public const string GetPagedEndpoint = Base; //GET
    }
}
