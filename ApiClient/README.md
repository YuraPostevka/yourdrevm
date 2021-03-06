# IO.Swagger - the C# library for the webApiTask

No descripton provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)

This C# SDK is automatically generated by the [Swagger Codegen](https://github.com/swagger-api/swagger-codegen) project:

- API version: v1
- SDK version: 1.0.0
- Build date: 2017-01-20T11:49:20.774+02:00
- Build package: class io.swagger.codegen.languages.CSharpClientCodegen

## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommned using [NuGet] (https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
```

NOTE: RestSharp versions greater than 105.1.0 have a bug which causes file uploads to fail. See [RestSharp#742](https://github.com/restsharp/RestSharp/issues/742)

## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using IO.Swagger.Api;
using IO.Swagger.Client;
using Model;
```

## Getting Started

```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using Model;

namespace Example
{
    public class Example
    {
        public void main()
        {
            
            var apiInstance = new AccountApi();
            var model = new AddExternalLoginBindingModel(); // AddExternalLoginBindingModel | 

            try
            {
                Object result = apiInstance.AccountAddExternalLogin(model);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling AccountApi.AccountAddExternalLogin: " + e.Message );
            }
        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *http://localhost:55624*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*AccountApi* | [**AccountAddExternalLogin**](docs/AccountApi.md#accountaddexternallogin) | **POST** /api/Account/AddExternalLogin | 
*AccountApi* | [**AccountChangePassword**](docs/AccountApi.md#accountchangepassword) | **POST** /api/Account/ChangePassword | 
*AccountApi* | [**AccountGetExternalLogin**](docs/AccountApi.md#accountgetexternallogin) | **GET** /api/Account/ExternalLogin | 
*AccountApi* | [**AccountGetExternalLogins**](docs/AccountApi.md#accountgetexternallogins) | **GET** /api/Account/ExternalLogins | 
*AccountApi* | [**AccountGetManageInfo**](docs/AccountApi.md#accountgetmanageinfo) | **GET** /api/Account/ManageInfo | 
*AccountApi* | [**AccountGetUserInfo**](docs/AccountApi.md#accountgetuserinfo) | **GET** /api/Account/UserInfo | 
*AccountApi* | [**AccountLogout**](docs/AccountApi.md#accountlogout) | **POST** /api/Account/Logout | 
*AccountApi* | [**AccountRegister**](docs/AccountApi.md#accountregister) | **POST** /api/Account/Register | 
*AccountApi* | [**AccountRegisterExternal**](docs/AccountApi.md#accountregisterexternal) | **POST** /api/Account/RegisterExternal | 
*AccountApi* | [**AccountRemoveLogin**](docs/AccountApi.md#accountremovelogin) | **POST** /api/Account/RemoveLogin | 
*AccountApi* | [**AccountSetPassword**](docs/AccountApi.md#accountsetpassword) | **POST** /api/Account/SetPassword | 
*ClaimsApi* | [**ClaimsGetClaims**](docs/ClaimsApi.md#claimsgetclaims) | **GET** /api/Claims | 
*ToDoItemApi* | [**ToDoItemDelete**](docs/ToDoItemApi.md#todoitemdelete) | **DELETE** /api/ToDoItem/{id} | Delete Todo item
*ToDoItemApi* | [**ToDoItemGet**](docs/ToDoItemApi.md#todoitemget) | **GET** /api/ToDoItem/{id} | Get todo item by id
*ToDoItemApi* | [**ToDoItemGetAll**](docs/ToDoItemApi.md#todoitemgetall) | **GET** /api/ToDoItem | Getl all Todo items
*ToDoItemApi* | [**ToDoItemMarkAsCompleted**](docs/ToDoItemApi.md#todoitemmarkascompleted) | **PUT** /api/ToDoItem/{id} | Mark as completed
*ToDoItemApi* | [**ToDoItemPost**](docs/ToDoItemApi.md#todoitempost) | **POST** /api/ToDoItem | Insert Todo items
*ToDoItemApi* | [**ToDoItemPut**](docs/ToDoItemApi.md#todoitemput) | **PUT** /api/ToDoItem | 
*ToDoListApi* | [**ToDoListDelete**](docs/ToDoListApi.md#todolistdelete) | **DELETE** /api/ToDoList/{id} | Delete Todo list
*ToDoListApi* | [**ToDoListGet**](docs/ToDoListApi.md#todolistget) | **GET** /api/ToDoList/{id} | Get Todo list by id
*ToDoListApi* | [**ToDoListGetAll**](docs/ToDoListApi.md#todolistgetall) | **GET** /api/ToDoList | Get all Todo lists
*ToDoListApi* | [**ToDoListPost**](docs/ToDoListApi.md#todolistpost) | **POST** /api/ToDoList | Insert Todo list
*ToDoListApi* | [**ToDoListPut**](docs/ToDoListApi.md#todolistput) | **PUT** /api/ToDoList | Update Todo list
*UserApi* | [**UserDelete**](docs/UserApi.md#userdelete) | **DELETE** /api/User/{id} | Delete user
*UserApi* | [**UserGetAll**](docs/UserApi.md#usergetall) | **GET** /api/User | Get all users
*UserApi* | [**UserGetById**](docs/UserApi.md#usergetbyid) | **GET** /api/User/{id} | Get by id
*UserApi* | [**UserPost**](docs/UserApi.md#userpost) | **POST** /api/User | Insert user
*UserApi* | [**UserPut**](docs/UserApi.md#userput) | **PUT** /api/User | Update user


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.AddExternalLoginBindingModel](docs/AddExternalLoginBindingModel.md)
 - [Model.ChangePasswordBindingModel](docs/ChangePasswordBindingModel.md)
 - [Model.ExternalLoginViewModel](docs/ExternalLoginViewModel.md)
 - [Model.ManageInfoViewModel](docs/ManageInfoViewModel.md)
 - [Model.RegisterBindingModel](docs/RegisterBindingModel.md)
 - [Model.RegisterExternalBindingModel](docs/RegisterExternalBindingModel.md)
 - [Model.RemoveLoginBindingModel](docs/RemoveLoginBindingModel.md)
 - [Model.SetPasswordBindingModel](docs/SetPasswordBindingModel.md)
 - [Model.ToDoItem](docs/ToDoItem.md)
 - [Model.ToDoList](docs/ToDoList.md)
 - [Model.User](docs/User.md)
 - [Model.UserInfoViewModel](docs/UserInfoViewModel.md)
 - [Model.UserLoginInfoViewModel](docs/UserLoginInfoViewModel.md)


## Documentation for Authorization

All endpoints do not require authorization.
