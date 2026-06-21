using POS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.Services
{
    public class CodeGenerator : ICodeGenerator
    {
        public string GenerateCode()
        {
            var random = new Random();

            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";

            // Generate 4 random letters
            var letterPart = new string(Enumerable.Range(0, 4)
                .Select(_ => letters[random.Next(letters.Length)])
                .ToArray());

            // Generate 4 random digits
            var numberPart = new string(Enumerable.Range(0, 4)
                .Select(_ => numbers[random.Next(numbers.Length)])
                .ToArray());

            return $"{letterPart}-{numberPart}";
        }
    }
}
