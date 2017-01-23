/* 
 * webApiTask
 *
 * No descripton provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing UserApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class UserApiTests
    {
        private UserApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new UserApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of UserApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' UserApi
            //Assert.IsInstanceOfType(typeof(UserApi), instance, "instance is a UserApi");
        }

        
        /// <summary>
        /// Test UserDelete
        /// </summary>
        [Test]
        public void UserDeleteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //var response = instance.UserDelete(id);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test UserGetAll
        /// </summary>
        [Test]
        public void UserGetAllTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.UserGetAll();
            //Assert.IsInstanceOf<List<User>> (response, "response is List<User>");
        }
        
        /// <summary>
        /// Test UserGetById
        /// </summary>
        [Test]
        public void UserGetByIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int? id = null;
            //var response = instance.UserGetById(id);
            //Assert.IsInstanceOf<User> (response, "response is User");
        }
        
        /// <summary>
        /// Test UserPost
        /// </summary>
        [Test]
        public void UserPostTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //User user = null;
            //var response = instance.UserPost(user);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
        /// <summary>
        /// Test UserPut
        /// </summary>
        [Test]
        public void UserPutTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //User user = null;
            //var response = instance.UserPut(user);
            //Assert.IsInstanceOf<Object> (response, "response is Object");
        }
        
    }

}