# ServiceStack

ServiceStack is a simple, fast, versatile and highly-productive full-featured Web and Web Services Framework that’s thoughtfully-architected to reduce artificial complexity and promote remote services best-practices with a message-based design that allows for maximum re-use that can leverage an integrated Service Gateway for the creation of loosely-coupled Modularized Service Architectures.

ServiceStack provides a fast, simple, config-free, code-first POCO ORM for .NET called ServiceStack.OrmLite.
This ORM lets developers create schemas from code-first POCOs, supports foreign keys, indexes, multi-nested database connections, contains convenience API's for common data access patterns, querying with typed-expressions, whilst providing seamless access to raw SQL and ADO.NET transactions whenever needed.

OrmLite's goal is to provide a convenient, DRY, config-free, RDBMS-agnostic typed wrapper that retains a high affinity with SQL, exposing intuitive APIs that generate predictable SQL and maps cleanly to (DTO-friendly) disconnected POCO's. This approach makes easier to reason-about your data access making it obvious what SQL is getting executed at what time, whilst mitigating unexpected behavior, implicit N+1 queries and leaky data access prevalent in Heavy ORMs.

OrmLite was designed with a focus on the core objectives:

- Provide a set of light-weight C# extension methods around .NET's impl-agnostic System.Data.\* interfaces
- Map a POCO class 1:1 to an RDBMS table, cleanly by conventions, without any attributes required.
- Create/Drop DB Table schemas using nothing but POCO class definitions (IOTW a true code-first ORM)
- Simplicity - typed, wrist friendly API for common data access patterns.
- High performance - with support for indexes, text blobs, etc.
- Amongst the fastest Micro ORMs for .NET.
- Expressive power and flexibility - with access to IDbCommand and raw SQL
- Cross platform - runs on top of .NET Framework, .NET Core and Mono

## Supported Databases

OrmLite supports the following database providers:

- Sql Server
- Sqlite
- MySql
- PostgreSQL
- Firebird

## Libraries

There 8 flavours of OrmLite on NuGet:

- [ServiceStack.OrmLite.SqlServer](http://nuget.org/List/Packages/ServiceStack.OrmLite.SqlServer)
- [ServiceStack.OrmLite.SqlServer.Data](http://nuget.org/List/Packages/ServiceStack.OrmLite.SqlServer.Data) (uses [Microsoft.Data.SqlClient](https://devblogs.microsoft.com/dotnet/introducing-the-new-microsoftdatasqlclient/))
- [ServiceStack.OrmLite.Sqlite](http://nuget.org/packages/ServiceStack.OrmLite.Sqlite)
- [ServiceStack.OrmLite.Sqlite.Data](http://nuget.org/packages/ServiceStack.OrmLite.Sqlite.Data) (uses [Microsoft.Data.SQLite](https://stackoverflow.com/a/52025556/85785))
- [ServiceStack.OrmLite.PostgreSQL](http://nuget.org/List/Packages/ServiceStack.OrmLite.PostgreSQL)
- [ServiceStack.OrmLite.MySql](http://nuget.org/List/Packages/ServiceStack.OrmLite.MySql)
- [ServiceStack.OrmLite.MySqlConnector](http://nuget.org/List/Packages/ServiceStack.OrmLite.MySqlConnector) (uses [MySqlConnector](https://github.com/mysql-net/MySqlConnector))

These packages contain both **.NET Framework v4.5** and **.NET Standard 2.0** versions and supports both .NET Framework and .NET Core projects.

The `.Core` packages contain only **.NET Standard 2.0** versions which can be used in ASP.NET Core Apps running on the .NET Framework:

- [ServiceStack.OrmLite.SqlServer.Core](http://nuget.org/List/Packages/ServiceStack.OrmLite.SqlServer.Core)
- [ServiceStack.OrmLite.PostgreSQL.Core](http://nuget.org/List/Packages/ServiceStack.OrmLite.PostgreSQL.Core)
- [ServiceStack.OrmLite.MySql.Core](http://nuget.org/List/Packages/ServiceStack.OrmLite.MySql.Core)
- [ServiceStack.OrmLite.Sqlite.Core](http://nuget.org/packages/ServiceStack.OrmLite.Sqlite.Core)

There are unofficial releases maintained by the ServiceStack Community as well:

- [ServiceStack.OrmLite.Oracle](http://nuget.org/packages/ServiceStack.OrmLite.Oracle)
- [ServiceStack.OrmLite.Firebird](http://nuget.org/List/Packages/ServiceStack.OrmLite.Firebird)
- [ServiceStack.OrmLite.VistaDb](http://nuget.org/List/Packages/ServiceStack.OrmLite.VistaDb)

## Setup

To get started, check out the [usage documentation](https://github.com/ServiceStack/ServiceStack.OrmLite#usage).

## Documentation and Tutorials

The documentation and all related links are available as part of the [README.md](https://github.com/ServiceStack/ServiceStack.OrmLite/blob/master/README.md) in the source repository.

There is also an [extensive set of unit tests](https://github.com/ServiceStack/ServiceStack.OrmLite/tree/master/tests) available in the repository that can help to further address solving specific use-cases.

## Bug Reporting

Bugs can be reported on the [ServiceStack Forums](https://forums.servicestack.net/).

## Licensing

Since September 2013, ServiceStack source code is available under the GNU Affero General Public License/FOSS License Exception, see [license.txt](https://github.com/ServiceStack/ServiceStack.OrmLite/blob/master/license.txt) in the source repository.
Alternative [commercial licensing](https://servicestack.net/ormlite) is also available.
