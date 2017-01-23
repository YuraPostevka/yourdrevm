# IO.Swagger.Api.ToDoListApi

All URIs are relative to *http://localhost:55624*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ToDoListDelete**](ToDoListApi.md#todolistdelete) | **DELETE** /api/ToDoList/{id} | Delete Todo list
[**ToDoListGet**](ToDoListApi.md#todolistget) | **GET** /api/ToDoList/{id} | Get Todo list by id
[**ToDoListGetAll**](ToDoListApi.md#todolistgetall) | **GET** /api/ToDoList | Get all Todo lists
[**ToDoListPost**](ToDoListApi.md#todolistpost) | **POST** /api/ToDoList | Insert Todo list
[**ToDoListPut**](ToDoListApi.md#todolistput) | **PUT** /api/ToDoList | Update Todo list


<a name="todolistdelete"></a>
# **ToDoListDelete**
> Object ToDoListDelete (int? id)

Delete Todo list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var id = 56;  // int? | 

            try
            {
                // Delete Todo list
                Object result = apiInstance.ToDoListDelete(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListDelete: " + e.Message );
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

<a name="todolistget"></a>
# **ToDoListGet**
> ToDoList ToDoListGet (int? id)

Get Todo list by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListGetExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var id = 56;  // int? | 

            try
            {
                // Get Todo list by id
                ToDoList result = apiInstance.ToDoListGet(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListGet: " + e.Message );
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

[**ToDoList**](ToDoList.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistgetall"></a>
# **ToDoListGetAll**
> List<ToDoList> ToDoListGetAll ()

Get all Todo lists

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();

            try
            {
                // Get all Todo lists
                List&lt;ToDoList&gt; result = apiInstance.ToDoListGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<ToDoList>**](ToDoList.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistpost"></a>
# **ToDoListPost**
> Object ToDoListPost (ToDoList toDoList)

Insert Todo list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListPostExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var toDoList = new ToDoList(); // ToDoList | 

            try
            {
                // Insert Todo list
                Object result = apiInstance.ToDoListPost(toDoList);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **toDoList** | [**ToDoList**](ToDoList.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="todolistput"></a>
# **ToDoListPut**
> Object ToDoListPut (ToDoList toDoList)

Update Todo list

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ToDoListPutExample
    {
        public void main()
        {
            
            var apiInstance = new ToDoListApi();
            var toDoList = new ToDoList(); // ToDoList | 

            try
            {
                // Update Todo list
                Object result = apiInstance.ToDoListPut(toDoList);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ToDoListApi.ToDoListPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **toDoList** | [**ToDoList**](ToDoList.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

