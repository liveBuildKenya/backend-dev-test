# How to run the project
1. Pull the code

``` bash

git pull https://github.com/liveBuildKenya/backend-dev-test.git

```

2. Ensure the data setting file in both the [Data Library](Libraries/Jambopay.Data/App_Data/dataSettings.json) and [Web Api](Presentation/Jambopay.Web.Api/App_Data/dataSettings.json) are pointing to your local instance of MSSQL.

``` json

{
  "DataConnectionString": "<connection-string>",
  "DataProvider": "sqlserver"
}

```

3. Run the migration on the [Data Library](Libraries/Jambopay.Data). View the [EfCore migration documentation](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) to know how to run the migrations.


4. Run the [Web Api project](Presentation/Jambopay.Web.Api)

``` bash
dotnet run
```

# Questions Asked
## How to ensure the application scales and performace is optimized.
1. Ensure the database tables have clustered indexes to speed up query processes in SQL Server.
2. Use asyncronous code ensures the application can use a new cpu thread to execute a request in the event that the executing thread has not completed the request.


The Generic [Repository](Libraries/Jambopay.Data/EfRepository.cs) file has the following implementations for Inserting using both synchronous and asynchronous methods:

``` C#

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _jambopayDataProvider.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual async Task InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                await Entities.AddAsync(entity);
                await _jambopayDataProvider.SaveChangesAsync();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

```

The [Transact Controller](Presentation/Jambopay.Web.Api/Controllers/AffiliateController.cs) is asynchronous so as to scale based on the amout to create transaction requests present:
``` C#

        public async Task<TransactResponseViewModel> Transact([FromBody] TransactViewModel transactViewModel)
        {
            return await _networkMarketingFactory.Transact(transactViewModel);
        }

```

## How to ensure the system and data.
1. How do we prevent a user from changing sensitive database values.

The file of interest is [Network Factory](Presentation/Jambopay.Web.Framework/Factories/NetworkMarketing/NetworkMarketingFactory.cs). The folowing code creates an instance of the data protector from the Microsoft.AspNetCore.DataProtection namespace

``` C#

        private readonly IDataProtector _dataProtector;

        public NetworkFactory(IDataProtectionProvider dataProtectionProvider) 
        {
            this._dataProtector = dataProtectionProvider.Create("Amount Protector");
        }

```

The folowing code encrypts the to the database
``` C#

        _dataProtector.Protect(transactViewModel.Amount.ToString())

```
The following code decrypts the data from the database

``` C#

        _dataProtector.Unprotect(ambassador.CommissionBalance)

```

2. Endpoint protection
The route to transact has been protected using the authorized attribute preventing users without a jwt token from accessing it. The jwt token is provided from the authorization header as:

``` 
        Bearer jwtToken
```


# Project Structure

The code is organized as follows:-


[Jambopay.Core](Libraries/Jambopay.Core) - Defines the domain model for the database stracture.

[Jambopay.Data](Libraries/Jambopay.Data) - Defines the database mappings and the database connection logic using the repository pattern.

[Jambopay.Service](Libraries/Jambopay.Service) - Defines the services that query the database.

[Jambopay.Web.Api](Presentation/Jambopay.Web.Api) - The API project which when run open the browser to display the swagger UI where you can test the urls

[Jambopay.Web.Framework](Presentation/Jambopay.Web.Framework) - Defines the models and project confogurations for the web api.

[Jambopay.Web.Framework.Tests](Presentation/Jambopay.Web.Tests) - Defines the tests for the web framework project.
