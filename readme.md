# How to run the project
1. Pull the code

``` bash

git pull https://github.com/liveBuildKenya/backend-dev-test.git

```

2. Ensure the data setting file in both the [Data Library](Libraries/Jambopay.Data/App_Data/dataSettings.json) and [Web Api](Presentation/Jambopay.Web.Api/App_Data/dataSettings.json) data settings are pointing to your local instance of MSSQL.

``` json

{
  "DataConnectionString": "<connection-string>",
  "DataProvider": "sqlserver"
}

```

3. Run the migration on the [Data Library](Libraries/Jambopay.Data). For more information on how to run migration consult [EfCore migration documentstion](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)


4. Run the [Web Api project](Presentation/Jambopay.Web.Api)

``` bash
dontet run
```

## Project Structure
[Jambopay.Core](Libraries/Jambopay.Core) - Defines the domain model for the database stracture.

[Jambopay.Data](Libraries/Jambopay.Data) - Defines the database mappings and the database connection logic using the repository pattern.

[Jambopay.Service](Libraries/Jambopay.Service) - Defines the services that query the database.

[Jambopay.Web.Api](Presentation/Jambopay.Web.Api) - The API project which when run open the browser to display the swagger UI where you can test the urls

[Jambopay.Web.Framework](Presentation/Jambopay.Web.Framework) - Defines the models and project confogurations for the web api.

[Jambopay.Web.Framework.Tests](Presentation/Jambopay.Web.Tests) - Defines the tests for the web framework project.
