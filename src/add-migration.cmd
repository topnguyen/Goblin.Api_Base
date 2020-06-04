pushd Repository\Goblin.Api_Base.Repository
dotnet ef migrations add %1 -v --context DbContext
dotnet ef database update -v --context DbContext
popd