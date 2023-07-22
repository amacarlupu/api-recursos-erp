using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using SupportPageApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupportPageApi.Services
{
    public class AuthenticateService
    {
        private readonly IMongoCollection<User> _userCollection; // lista con los datos de la db
     

        //Constructor para crear la conexión
        public AuthenticateService(
           IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                userDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                userDatabaseSettings.Value.DatabaseName);

            _userCollection = mongoDatabase.GetCollection<User>(
                userDatabaseSettings.Value.UserCollectionName);
        }

        public async Task CreateAsync(User usuario) =>
            await _userCollection.InsertOneAsync(usuario);


        public dynamic GenerateHash(User usuario)
        {
            string username = usuario.Username;
            string password = usuario.Password;
            string passwordHashed;

            IPasswordHasher<string> pw = new  PasswordHasher<string>();
            passwordHashed = pw.HashPassword(username, password);
            return passwordHashed;
        }

        public async Task<User> ValidateUser(string username)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Username, username);
            return await _userCollection.Find(filter).FirstOrDefaultAsync();

        }


        public dynamic ValidatePassword(User usuario, string password)
        {
            IPasswordHasher<string> pw = new PasswordHasher<string>();
            var valid = pw.VerifyHashedPassword(usuario.Username, usuario.Password, password);
            return valid.ToString();
        }
            
    }
}
