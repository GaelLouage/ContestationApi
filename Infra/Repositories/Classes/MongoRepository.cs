﻿using Infra.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infra.Repositories.Classes
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public MongoRepository(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _collection = database.GetCollection<T>(collectionName);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        // Create
        public async Task<bool> InsertAsync(T item)
        {
            var oldCount = (await GetAllAsync()).Count();

            await _collection.InsertOneAsync(item);

            var newCount = (await GetAllAsync()).Count();
            return oldCount < newCount;
        }
        // Update
        public async Task UpdateAsync(ObjectId id, T item)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, item);
        }
        // update
        // Delete
        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }
        // Read by Id
        public async Task<T> GetByIdAsync(ObjectId id)
        {

            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<T> GetByFieldAsync(string fieldName, string name)
        {
            try
            {
                var filter = Builders<T>.Filter.Eq(fieldName, name);
                return await _collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }
        // Read by filter expression
        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
