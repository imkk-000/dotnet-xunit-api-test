using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Xunit;

namespace dotnet_xunit_api_test
{
    class Todo {
        public int userId;
        public int id;
        public string title;
        public bool completed;
    }

    public class APITest
    {
        static HttpClient callAPIHelper = new HttpClient();

        [Fact]
        public async void GivenCallAPITodosRouteShouldBeJSON()
        {
            //Arrange
            var expectedTodo = new Todo(){
                userId = 1,
                id = 1,
                title = "delectus aut autem",
                completed = false,
            };
            // Act
            var response = await callAPIHelper.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            var actualTodo = await response.Content.ReadAsStringAsync();

            // Assertion
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(actualTodo, actualTodo);
        }
    }
}
