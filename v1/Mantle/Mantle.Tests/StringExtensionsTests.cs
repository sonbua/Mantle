﻿using System;
using Mantle.Extensions;
using NUnit.Framework;

namespace Mantle.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Should_merge_data_into_target_string()
        {
            const string sourceString = "My name is {FirstName} {LastName} and I am {Age}.";
            const string expectedString = "My name is Casey Watson and I am 33.";

            var testObj = new {FirstName = "Casey", LastName = "Watson", Age = 33};

            var mergedString = sourceString.Merge(testObj);

            Assert.IsNotNull(mergedString);
            Assert.AreEqual(expectedString, mergedString);
        }

        [Test]
        public void Should_parse_string_to_Date_Time_value()
        {
            var dateTimeResult = "1/11/1981".TryParseDateTime();

            Assert.IsNotNull(dateTimeResult);
            Assert.AreEqual(dateTimeResult.Value, DateTime.Parse("1/11/1981"));
        }

        [Test]
        public void Should_parse_string_to_Guid_value()
        {
            var testGuid = Guid.NewGuid();
            var guidResult = testGuid.ToString().TryParseGuid();

            Assert.IsNotNull(guidResult);
            Assert.AreEqual(guidResult.Value, testGuid);
        }

        [Test]
        public void Should_parse_string_to_boolean_value()
        {
            var boolResult = "true".TryParseBoolean();

            Assert.IsNotNull(boolResult);
            Assert.IsTrue(boolResult.Value);
        }

        [Test]
        public void Should_parse_string_to_double_value()
        {
            var doubleResult = "1.0".TryParseDouble();

            Assert.IsNotNull(doubleResult);
            Assert.AreEqual(doubleResult.Value, 1.0);
        }

        [Test]
        public void Should_parse_string_to_int_value()
        {
            var intResult = "1".TryParseInt();

            Assert.IsNotNull(intResult);
            Assert.AreEqual(intResult.Value, 1);
        }

        [Test]
        public void Should_parse_string_to_long_value()
        {
            var longResult = "1".TryParseLong();

            Assert.IsNotNull(longResult);
            Assert.AreEqual(longResult.Value, 1);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_Date_Time_string()
        {
            var dateTimeResult = "invalid".TryParseDateTime();

            Assert.IsNull(dateTimeResult);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_Guid_string()
        {
            var guidResult = "invalid".TryParseGuid();

            Assert.IsNull(guidResult);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_boolean_string()
        {
            var boolResult = "invalid".TryParseBoolean();

            Assert.IsNull(boolResult);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_double_string()
        {
            var doubleResult = "invalid".TryParseDouble();

            Assert.IsNull(doubleResult);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_int_string()
        {
            var intResult = "invalid".TryParseInt();

            Assert.IsNull(intResult);
        }

        [Test]
        public void Should_return_null_if_unable_to_parse_long_string()
        {
            var longResult = "invalid".TryParseLong();

            Assert.IsNull(longResult);
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_Date_Time_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseDateTime());
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_Guid_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseGuid());
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_boolean_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseBoolean());
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_double_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseDouble());
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_int_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseInt());
        }

        [Test]
        public void Should_throw_ArgumentNullException_if_attempting_to_parse_null_string_to_long_value()
        {
            Assert.Throws<ArgumentNullException>(() => default(string).TryParseLong());
        }

        [Test]
        public void When_merging_data_into_a_string_should_ignore_fields_not_included_in_data_object()
        {
            const string sourceString = "My name is {FirstName} {LastName} and I am {Age}.";
            const string expectedString = "My name is Casey Watson and I am {Age}.";

            var testObj = new {FirstName = "Casey", LastName = "Watson"};

            var mergedString = sourceString.Merge(testObj);

            Assert.IsNotNull(mergedString);
            Assert.AreEqual(expectedString, mergedString);
        }

        [Test]
        public void When_merging_data_into_a_string_should_ignore_fields_not_included_in_string()
        {
            const string sourceString = "My name is {FirstName} {LastName} and I am {Age}.";
            const string expectedString = "My name is Casey Watson and I am 33.";

            var testObj =
                new {FirstName = "Casey", LastName = "Watson", Age = 33, Birthdate = DateTime.Parse("1/11/1981")};

            var mergedString = sourceString.Merge(testObj);

            Assert.IsNotNull(mergedString);
            Assert.AreEqual(expectedString, mergedString);
        }

        [Test]
        public void When_merging_data_into_a_string_should_throw_ArgumentNullException_if_data_is_null()
        {
            const string sourceString = "My name is {FirstName} {LastName} and I am {Age}.";

            var ex = Assert.Throws<ArgumentNullException>(() => sourceString.Merge(null));

            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.ParamName, "data");
        }

        [Test]
        public void When_merging_data_into_a_string_should_throw_ArgumentNullException_if_source_is_null()
        {
            var testObj = new {FirstName = "Casey", LastName = "Watson"};

            var ex = Assert.Throws<ArgumentNullException>(() => default(string).Merge(testObj));

            Assert.IsNotNull(ex);
            Assert.AreEqual(ex.ParamName, "source");
        }

        [Test]
        public void When_merging_data_into_a_string_should_use_custom_delimiters_if_provided()
        {
            const string sourceString = "My name is |FirstName| |LastName| and I am |Age|.";
            const string expectedString = "My name is Casey Watson and I am 33.";

            var testObj = new {FirstName = "Casey", LastName = "Watson", Age = 33};

            var mergedString = sourceString.Merge(testObj, '|', '|');

            Assert.IsNotNull(mergedString);
            Assert.AreEqual(expectedString, mergedString);
        }
    }
}