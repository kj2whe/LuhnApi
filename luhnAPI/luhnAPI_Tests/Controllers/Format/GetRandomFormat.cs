﻿using LuhnAlgorithim.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LuhnAlgorithim.Controllers.Tests
{
    [TestClass()]
    [ExcludeFromCodeCoverage]
    public class GetRandomFormat
    {
        private readonly FormatController _formatController;

        private readonly List<FormatType> _formatTypes;

        public GetRandomFormat()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<FormatController>();

            _formatController = new FormatController(logger);
            _formatTypes = GetFormatTypes_All();
        }

        [TestMethod()]
        public void GetRandomFormat_RandomFormatTypeIsFoundInList_True()
        {
            var expected = JsonConvert.DeserializeObject<FormatType>(_formatController.GetRandomFormat()); 

            var actual = JsonConvert.SerializeObject(_formatTypes.SingleOrDefault(x => x.abbr.Equals(expected.abbr, StringComparison.CurrentCultureIgnoreCase)));

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void GetRandomFormat_FormatTypeIsNotFoundInList_Fail()
        {
            var expected = "q";

            var actual = _formatTypes.SingleOrDefault(x => x.abbr.Equals(expected, StringComparison.CurrentCultureIgnoreCase));

            Assert.IsNull(actual);
        }

        private List<FormatType> GetFormatTypes_All()
        {

            var results = new List<FormatType>
            {
                new FormatType()
                {
                    abbr = "ve",
                    Issuer = "Visa Electron",
                    IINRange = new List<int> { 4026, 417500, 4508, 4844, 4913, 4917 },
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "v",
                    Issuer = "Visa",
                    IINRange = new List<int> { 4 },
                    LengthOfDigits = new int[] { 13, 16, 19 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 13,
                        DigitSpacingFormat = " dddd dddd dddd d"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 19,
                        DigitSpacingFormat = " dddd dddd dddd dddd ddd"
                    },
                }
                },

                new FormatType()
                {
                    abbr = "mc",
                    Issuer = "MasterCard",
                    IINRange = new List<int> { 51, 52, 53, 54, 55 },
                    IINMetaRangeStart = 222100,
                    IINMetaRangeEnd = 272099,
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "m",
                    Issuer = "Maestro",
                    IINRange = new List<int> { 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763 },
                    LengthOfDigits = new int[] { 13, 15, 16, 19 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 13,
                        IINMetaRangeStart = 500000,
                        IINMetaRangeEnd = 509999,
                        DigitSpacingFormat = " dddd dddd ddddd"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 15,
                        IINMetaRangeStart = 560000,
                        IINMetaRangeEnd = 589999,
                        DigitSpacingFormat = " dddd dddddd ddddd"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        IINMetaRangeStart = 600000,
                        IINMetaRangeEnd = 699999,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 19,
                        DigitSpacingFormat = " dddd dddd dddd dddd ddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "jcb",
                    Issuer = "JCB",
                    IINMetaRangeStart = 3528,
                    IINMetaRangeEnd = 3589,
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "ip",
                    Issuer = "InstaPayment",
                    IINRange = new List<int> { 637, 638, 639 },
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "d",
                    Issuer = "Discover",
                    IINRange = new List<int> { 6011, 644, 645, 646, 647, 648, 649, 65 },
                    IINMetaRangeStart = 622126,
                    IINMetaRangeEnd = 622925,
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "cup",
                    Issuer = "China Union Pay",
                    IINRange = new List<int> { 62 },
                    LengthOfDigits = new int[] { 16, 19 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    },
                    new FormatTypeSpacing{
                        FormatLength = 19,
                        DigitSpacingFormat = " dddddd ddddddddddddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "dcuc",
                    Issuer = "Diners Club - USA & Canada",
                    IINRange = new List<int> { 54, 644, 645, 646, 647, 648, 649, 65 },
                    IINMetaRangeStart = 622126,
                    IINMetaRangeEnd = 622925,
                    LengthOfDigits = new int[] { 16 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 16,
                        DigitSpacingFormat = " dddd dddd dddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "dci",
                    Issuer = "Diners Club - International",
                    IINRange = new List<int> { 36 },
                    LengthOfDigits = new int[] { 14 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 14,
                        DigitSpacingFormat = " dddd dddddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "dccb",
                    Issuer = "Diners Club - Carte Blanche",
                    IINRange = new List<int> { 300, 301, 302, 303, 304, 305 },
                    LengthOfDigits = new int[] { 14 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 14,
                        DigitSpacingFormat = " dddd dddddd dddd"
                    }
                }
                },

                new FormatType()
                {
                    abbr = "ae",
                    Issuer = "American Express",
                    IINRange = new List<int> { 34, 37 },
                    LengthOfDigits = new int[] { 15 },
                    DisplayFormat = new List<FormatTypeSpacing>(){
                    new FormatTypeSpacing{
                        FormatLength = 15,
                        DigitSpacingFormat = " dddd dddddd ddddd"
                    }
                }
                }
            };

            return results;
        }
    }
}