# EasyAPI

This is a .NET library that nobody uses and provides a simple and easy-to-use interface for making HTTP requests. It is built on top of the HttpClient class in the System.Net.Http namespace, but it simplifies the usage of the HttpClient by providing a set of methods that handle common use cases.

## Usage

### Creating an instance
To use the EasyAPI library, you first need to create an instance of the EasyAPI class:
```csharp
var api = new EasyAPI();
```

### Making a GET request
To make a GET request, you can use one of the **GetAsync** methods:
```csharp
var result = await api.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
Console.WriteLine(result);
```
The above code will make a GET request to the specified URL and return the response as a string.

You can also specify headers or a proxy:
```csharp
var headers = new Dictionary<string, string>
{
    { "Authorization", "Bearer YOUR_TOKEN" }
};

var proxyHost = "PROXY_HOST";
var proxyPort = 1234;

var result = await api.GetAsync("https://jsonplaceholder.typicode.com/todos/1", headers, proxyHost, proxyPort);
Console.WriteLine(result);
```

### Making a POST request
To make a POST request, you can use one of the **PostAsync** methods:
```csharp
var data = "{\"title\": \"foo\", \"body\": \"bar\", \"userId\": 1}";

var result = await api.PostAsync("https://jsonplaceholder.typicode.com/posts", data);
Console.WriteLine(result);
```
You can also specify a proxy:
```csharp
var data = "{\"title\": \"foo\", \"body\": \"bar\", \"userId\": 1}";
var proxyHost = "PROXY_HOST";
var proxyPort = 1234;

var result = await api.PostAsync("https://jsonplaceholder.typicode.com/posts", data, proxyHost, proxyPort);
Console.WriteLine(result);
```

### Making a PUT request
To make a PUT request, you can use one of the **PutAsync** methods:
```csharp
var data = "{\"id\": 1, \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1}";

var result = await api.PutAsync("https://jsonplaceholder.typicode.com/posts/1", data);
Console.WriteLine(result);
```
You can also specify a proxy:
```csharp
var data = "{\"id\": 1, \"title\": \"foo\", \"body\": \"bar\", \"userId\": 1}";
var proxyHost = "PROXY_HOST";
var proxyPort = 1234;

var result = await api.PutAsync("https://jsonplaceholder.typicode.com/posts/1", data, proxyHost, proxyPort);
Console.WriteLine(result);
```

### Making a DELETE request
To make a DELETE request, you can use one of the **DeleteAsync** methods:
```csharp
var result = await api.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");
Console.WriteLine(result);
```
You can also specify a proxy:
```csharp
var proxyHost = "PROXY_HOST";
var proxyPort = 1234;

var result = await api.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1", proxyHost, proxyPort);
Console.WriteLine(result);
```

### Uploading a file
To upload a file, you can use the **UploadFileAsync** method:
```csharp
var result = await api.UploadFileAsync("https://jsonplaceholder.typicode.com/posts/1");
Console.WriteLine(result);
```
You can also specify a proxy:
```csharp
var proxyHost = "PROXY_HOST";
var proxyPort = 1234;

var result = await api.UploadFileAsync("https://jsonplaceholder.typicode.com/posts/1", proxyHost, proxyPort);
Console.WriteLine(result);
```
