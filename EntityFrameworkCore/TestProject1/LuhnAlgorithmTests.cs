using EntityFrameworkCore.Luhncheckdigit;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class LuhnAlgorithmTests
    {
        [Theory]
        [InlineData("5558555555554444")]    // MasterCard test card number with single digit transcription error 5 -> 8
        [InlineData("5558555555554434")]    // MasterCard test card number with single digit transcription error 4 -> 3
        [InlineData("3059630009020004")]    // Diners Club test card number with two digit transposition error 69 -> 96 
        [InlineData("3056930009002004")]    // Diners Club test card number with two digit transposition error 20 -> 02
        [InlineData("5559955555554444")]    // MasterCard test card number with two digit twin error 55 -> 99
        [InlineData("3566111144111113")]    // JCB test card number with two digit twin error 11 -> 44
        public void ValidateCheckDigit_ShouldReturnTrue_WhenInputContainsValidCheckDigit(String value)
        {
            LuhnAlgorithm.ValidateCheckDigit(value).Should().BeTrue();
        }

        [Fact]
        public void ValidateCheckDigit_ShouldReturnFalse_WhenInputDoesNotContainValidCheckDigit()
        {
            LuhnAlgorithm.ValidateCheckDigit("1234567890");
        }
    }
}
