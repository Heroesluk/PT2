﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT2.data;

namespace Tests.data
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public void UserConstructor_ShouldSetProperties()
        {
            // Given
            string expectedUsername = "testUser";
            string expectedPassword = "securePass";
            string expectedEmail = "test@example.com";

            // When
            User user = new User(expectedUsername, expectedPassword, expectedEmail);

            // Then
            Assert.AreEqual(expectedUsername, user.Username);
            Assert.AreEqual(expectedPassword, user.Password);
            Assert.AreEqual(expectedEmail, user.Email);
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectFormat()
        {
            // Given
            User user = new User("testUser", "securePass", "test@example.com");
            string expectedOutput = "Username: testUser, Email: test@example.com";

            // When
            string actualOutput = user.ToString();

            // Then
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }



}
