# IO.Swagger.Api.UserApi

All URIs are relative to *http://localhost:55624*

Method | HTTP request | Description
------------- | ------------- | -------------
[**UserDelete**](UserApi.md#userdelete) | **DELETE** /api/User/{id} | Delete user
[**UserGetAll**](UserApi.md#usergetall) | **GET** /api/User | Get all users
[**UserGetById**](UserApi.md#usergetbyid) | **GET** /api/User/{id} | Get by id
[**UserPost**](UserApi.md#userpost) | **POST** /api/User | Insert user
[**UserPut**](UserApi.md#userput) | **PUT** /api/User | Update user


<a name="userdelete"></a>
# **UserDelete**
> Object UserDelete (int? id)

Delete user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var id = 56;  // int? | 

            try
            {
                // Delete user
                Object result = apiInstance.UserDelete(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserDelete: " + e.Message );
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

<a name="usergetall"></a>
# **UserGetAll**
> List<User> UserGetAll ()

Get all users

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserGetAllExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();

            try
            {
                // Get all users
                List&lt;User&gt; result = apiInstance.UserGetAll();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserGetAll: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<User>**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="usergetbyid"></a>
# **UserGetById**
> User UserGetById (int? id)

Get by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserGetByIdExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var id = 56;  // int? | 

            try
            {
                // Get by id
                User result = apiInstance.UserGetById(id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserGetById: " + e.Message );
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

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userpost"></a>
# **UserPost**
> Object UserPost (User user)

Insert user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPostExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var user = new User(); // User | 

            try
            {
                // Insert user
                Object result = apiInstance.UserPost(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="userput"></a>
# **UserPut**
> Object UserPut (User user)

Update user

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UserPutExample
    {
        public void main()
        {
            
            var apiInstance = new UserApi();
            var user = new User(); // User | 

            try
            {
                // Update user
                Object result = apiInstance.UserPut(user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.UserPut: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user** | [**User**](User.md)|  | 

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

