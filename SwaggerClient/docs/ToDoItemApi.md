# IO.Swagger.Api.ToDoItemApi

All URIs are relative to *http://localhost:55624*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ToDoItemDelete**](ToDoItemApi.md#todoitemdelete) | **DELETE** /api/ToDoItem/{id} | Delete Todo item
[**ToDoItemGet**](ToDoItemApi.md#todoitemget) | **GET** /api/ToDoItem/{id} | Get todo item by id
[**ToDoItemGetAll**](ToDoItemApi.md#todoitemgetall) | **GET** /api/ToDoItem | Getl all Todo items
[**ToDoItemMarkAsCompleted**](ToDoItemApi.md#todoitemmarkascompleted) | **PUT** /api/ToDoItem/{id} | Mark as completed
[**ToDoItemPost**](ToDoItemApi.md#todoitempost) | **POST** /api/ToDoItem | Insert Todo items
[**ToDoItemPut**](ToDoItemApi.md#todoitemput) | **PUT** /api/ToDoItem | 


<a name="todoitemdelete"></a>
# **ToDoItemDelete**
> Object ToDoItemDelete (int? id)

Delete Todo item

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var id = 56;  // int? | 

            try
            {
                // Delete Todo item
                Object result = apiInstance.ToDoItemDelete(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemget"></a>
# **ToDoItemGet**
> Object ToDoItemGet (int? id)

Get todo item by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemGetExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var id = 56;  // int? | 

            try
            {
                // Get todo item by id
                Object result = apiInstance.ToDoItemGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemgetall"></a>
# **ToDoItemGetAll**
> Object ToDoItemGetAll ()

Getl all Todo items

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();

            try
            {
                // Getl all Todo items
                Object result = apiInstance.ToDoItemGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemmarkascompleted"></a>
# **ToDoItemMarkAsCompleted**
> Object ToDoItemMarkAsCompleted (int? id)

Mark as completed

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemMarkAsCompletedExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var id = 56;  // int? | 

            try
            {
                // Mark as completed
                Object result = apiInstance.ToDoItemMarkAsCompleted(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemMarkAsCompleted: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **int?**|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitempost"></a>
# **ToDoItemPost**
> Object ToDoItemPost (ToDoItem item)

Insert Todo items

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemPostExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var item = new ToDoItem(); // ToDoItem | 

            try
            {
                // Insert Todo items
                Object result = apiInstance.ToDoItemPost(item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **item** | [**ToDoItem**](ToDoItem.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todoitemput"></a>
# **ToDoItemPut**
> Object ToDoItemPut (ToDoItem item)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoItemPutExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoItemApi();
            var item = new ToDoItem(); // ToDoItem | 

            try
            {
                // 
                Object result = apiInstance.ToDoItemPut(item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoItemApi.ToDoItemPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **item** | [**ToDoItem**](ToDoItem.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

