﻿namespace DataCat.Core.Db
{
    using DataCat.Core.Entity;
    using MongoDB.Driver;

    public interface IDbContext
    {
        IMongoDatabase Database { get; }
        IMongoCollection<DataConnection> DataConnectionCollection { get; }
        IMongoCollection<Filter> FilterCollection { get; }
        IMongoCollection<Widget> WidgetCollection { get; }
        IMongoCollection<Dashboard> DashboardCollection { get; }
    }
}