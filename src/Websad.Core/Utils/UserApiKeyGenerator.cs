using System;
using System.Text;
using Websad.Core.Contracts;
using Websad.Core.Extensions;
using Websad.Core.Models;

namespace Websad.Core.Utils
{
    public class UserApiKeyGenerator : IUserApiKeyGenerator
    {
        private static readonly string ValidCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private static string GenerateRandomApiKey() {
            const int MaxSize = 40;
            var random = new Random();
            var builder = new StringBuilder();
            for (int i = 0; i < MaxSize; i++) {
                var nextCharIndex = random.Next(0, ValidCharacters.Length);
                builder.Append(ValidCharacters[nextCharIndex]);
            }

            return builder.ToString();
        }

        public string GenerateApiKey(User user) {
            user.CheckArgumentIsNull();
            string newKey = string.Empty;
            do {
                newKey = GenerateRandomApiKey();
            }
            while (newKey != user.ApiKey);

            user.ApiKey = newKey;
            return newKey;
        }

        public string GetNewApiKey() {
            return GenerateRandomApiKey();
        }
    }
}
