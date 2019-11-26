﻿using CatFactory.SqlServer;
using Xunit;

namespace CatFactory.EntityFrameworkCore.Tests
{
    public class ScaffoldingTests
    {
        [Fact]
        public void ProjectScaffoldingForOnlineStoreDatabaseTest()
        {
            // Create database factory
            var databaseFactory = new SqlServerDatabaseFactory
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=OnlineStore;integrated security=yes;",
                    ImportTableFunctions = true,
                    Exclusions =
                    {
                        "dbo.sysdiagrams",
                        "dbo.fn_diagramobjects"
                    }
                }
            };

            // Import database
            var database = databaseFactory.Import();

            // Create instance of Entity Framework Core project
            var project = EntityFrameworkCoreProject.Create("OnlineStore.Core", database, @"C:\Temp\CatFactory.EntityFrameworkCore\OnlineStore.Core");

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.ConcurrencyToken = "Timestamp";
                settings.AuditEntity = new AuditEntity
                {
                    CreationUserColumnName = "CreationUser",
                    CreationDateTimeColumnName = "CreationDateTime",
                    LastUpdateUserColumnName = "LastUpdateUser",
                    LastUpdateDateTimeColumnName = "LastUpdateDateTime"
                };
            });

            project.Selection("Sales.OrderHeader", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Add event handlers to before and after of scaffold

            project.ScaffoldingDefinition += (source, args) =>
            {
                // Add code to perform operations with code builder instance before to create code file
            };

            project.ScaffoldedDefinition += (source, args) =>
            {
                // Add code to perform operations after of create code file
            };

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingWithDataAnnotationsForOnlineStoreDatabaseTest()
        {
            // Import database
            var database = SqlServerDatabaseFactory
                .Import(SqlServerDatabaseFactory.GetLogger(), "server=(local);database=OnlineStore;integrated security=yes;", "dbo.sysdiagrams");

            // Create instance of Entity Framework Core Project
            var project = EntityFrameworkCoreProject
                .Create("OnlineStoreWithDataAnnotations.Core", database, @"C:\Temp\CatFactory.EntityFrameworkCore\OnlineStoreWithDataAnnotations.Core");

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings =>
            {
                settings.ForceOverwrite = true;
                settings.UseDataAnnotations = true;
                settings.ConcurrencyToken = "Timestamp";
                settings.AuditEntity = new AuditEntity
                {
                    CreationUserColumnName = "CreationUser",
                    CreationDateTimeColumnName = "CreationDateTime",
                    LastUpdateUserColumnName = "LastUpdateUser",
                    LastUpdateDateTimeColumnName = "LastUpdateDateTime"
                };
            });

            project.Selection("Sales.OrderHeader", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForNorthwindDatabaseTest()
        {
            // Import database
            var factory = new SqlServerDatabaseFactory
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=Northwind;integrated security=yes;",
                    ImportScalarFunctions = true,
                    ImportTableFunctions = true,
                    ImportStoredProcedures = true,
                    Exclusions =
                    {
                        "dbo.sysdiagrams",
                        "dbo.sp_alterdiagram",
                        "dbo.sp_creatediagram",
                        "dbo.sp_dropdiagram",
                        "dbo.sp_helpdiagramdefinition",
                        "dbo.sp_helpdiagrams",
                        "dbo.sp_renamediagram",
                        "dbo.sp_upgraddiagrams",
                        "dbo.fn_diagramobjects"
                    }
                }
            };

            var database = factory.Import();

            // Create instance of Entity Framework Core Project
            var project = EntityFrameworkCoreProject.Create("Northwind.Core", database, @"C:\Temp\CatFactory.EntityFrameworkCore\Northwind.Core");

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings => settings.ForceOverwrite = true);

            project.Selection("dbo.Orders", settings => settings.EntitiesWithDataContracts = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForAdventureWorksDatabaseTest()
        {
            // Create instance of factory for SQL Server
            var databaseFactory = new SqlServerDatabaseFactory(SqlServerDatabaseFactory.GetLogger())
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=AdventureWorks2017;integrated security=yes;",
                    ImportScalarFunctions = true,
                    ImportTableFunctions = true,
                    Exclusions =
                    {
                        "dbo.sysdiagrams",
                        "Production.Document",
                        "Production.ProductDocument"
                    },
                    ExclusionTypes =
                    {
                        "hierarchyid",
                        "geography"
                    }
                }
            };

            // Import database
            var database = databaseFactory.Import();

            // Create instance of Entity Framework Core Project
            var project = EntityFrameworkCoreProject.Create("AdventureWorks", database, @"C:\Temp\CatFactory.EntityFrameworkCore\AdventureWorks.Core");

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings => settings.ForceOverwrite = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }

        [Fact]
        public void ProjectScaffoldingForWideWorldImportersDatabaseTest()
        {
            // Create database factory
            var databaseFactory = new SqlServerDatabaseFactory
            {
                DatabaseImportSettings = new DatabaseImportSettings
                {
                    ConnectionString = "server=(local);database=WideWorldImporters;integrated security=yes;",
                    ImportTableFunctions = true,
                    Exclusions =
                    {
                        "dbo.sysdiagrams",
                        "dbo.fn_diagramobjects"
                    }
                }
            };

            // Import database
            var database = databaseFactory.Import();

            // Create instance of Entity Framework Core project
            var project = EntityFrameworkCoreProject.Create("WideWorldImporters.Core", database, @"C:\Temp\CatFactory.EntityFrameworkCore\WideWorldImporters.Core");

            // Apply settings for Entity Framework Core project
            project.GlobalSelection(settings => settings.ForceOverwrite = true);

            // Build features for project, group all entities by schema into a feature
            project.BuildFeatures();

            // Scaffolding =^^=
            project
                .ScaffoldEntityLayer()
                .ScaffoldDataLayer();
        }
    }
}
