# IdentityServer4

## OAuth2.0的四种授权模式

http://www.ruanyifeng.com/blog/2014/05/oauth_2_0.html

### 客户端凭证模式：client credentials

/.well-known/openid-configuration
查看配置

#### 该方法通常用于服务器之间的通讯

（比如一个部署在后台自动运行定时任务的应用服务，需要访问授权数据）

#### 客户端凭证模式无需User的授权，授权仅发生在Client与IdentityServer之间

#### 流程

##### 配置IdentityServer

###### IdentityServer初始定义保护的Api资源列表

```
return new List<ApiResource>
    {
        new ApiResource("api1", "My API")
    };
```

###### IdentityServer初始预置允许访问的Client

```
new Client {
    ClientId = "client",

    // no interactive user, use the clientid/secret for authentication
    AllowedGrantTypes = GrantTypes.ClientCredentials,

    // secret for authentication
    ClientSecrets = {
        new Secret("secret".Sha256())
    },

    // scopes that client has access to
    AllowedScopes = {
        "api1"
    }
}
```

####### ClientId

####### ClientSecrets

####### AllowedScopes

##### 配置Resource

###### 定义受保护的WebApi

###### 配置认证中间件

```

services.AddAuthentication("Bearer").AddIdentityServerAuthentication(options = >{
    options.Authority = "http://localhost:5000";
    options.RequireHttpsMetadata = false;

    options.ApiName = "api1";
});

-------------
app.UseAuthentication();

```

##### Client使用凭证申请令牌访问资源

```
// discover endpoints from metadata
var disco = await DiscoveryClient.GetAsync("http://localhost:5000");
if (disco.IsError) {
    Console.WriteLine(disco.Error);
    return;
}

// request token
var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

if (tokenResponse.IsError) {
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.Json);
Console.WriteLine("\n\n");

// call api
var client = new HttpClient();
client.SetBearerToken(tokenResponse.AccessToken);

var response = await client.GetAsync("http://localhost:5001/identity");
```

### 密码模式：resource owner password credentials

在这种模式中，用户必须把自己的密码给客户端，但是客户端不得储存密码。这通常用在用户对客户端高度信任的情况下，比如客户端是操作系统的一部分，或者由一个著名公司出品。而认证服务器只有在其他授权模式无法执行的情况下，才能考虑使用这种模式。

#### 通过User的用户名和密码申请访问令牌

#### 该模式仅推荐应用于“受信任的应用”,否则容易造成密码泄漏

#### 流程同客户端凭证模式：区别在于GrandType的类型，及访问令牌的申请

```
// resource owner password grant client
new Client
{
    ClientId = "ro.client",
    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
    ClientSecrets = 
    {
        new Secret("secret".Sha256())
    },
    AllowedScopes = { "api1" }
}


------------------
// request token
var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");
```


### 授权码（混合）模式：authorization code

授权码模式（authorization code）是功能最完整、流程最严密的授权模式。它的特点就是通过客户端的后台服务器，与"服务提供商"的认证服务器进行互动。

http://www.cnblogs.com/sheng-jie/p/6564520.html

使用OpenId Connect&OAuth2.0 完成认证和授权

#### Client与Identity Server之间分两步进行认证和授权

##### 1. 通过认证后，Identity Server颁发【Authorization Code】

##### 2. Client使用【Authorization Code】向Identity Server申请【Access Token

### 简化模式：implicit

简化模式（implicit grant type）不通过第三方应用程序的服务器，直接在浏览器中向认证服务器申请令牌，跳过了"授权码"这个步骤，因此得名。所有步骤在浏览器中完成，令牌对访问者是可见的，且客户端不需要认证。

交互式身份验证

对于申请【身份令牌】没有问题



#### 直接在浏览器中向认证服务器申请令牌，跳过了第三方客户端服务器

#### 通过跳转至认证服务器登录界面进行认证

#### 流程

##### 配置IdentityServer

###### 定义IdentityResource

```
// scopes define the resources in your system
public static IEnumerable<IdentityResource> GetIdentityResources()
{
    return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile()
    };
}
```

###### 配置Client

```
// OpenID Connect implicit flow client (MVC)
new Client
{
    ClientId = "mvc",
    ClientName = "MVC Client",
    AllowedGrantTypes = GrantTypes.Implicit,
    RedirectUris = { "http://localhost:5002/signin-oidc" },
    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
    AllowedScopes =
    {
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile
    }
}
```

####### 设置登录跳转链接

####### 设置退出登录链接

##### 配置客户端

###### 配置认证中间件

###### 添加登录认证界面

## What

### OpenId Connect && OAuth2.0

#### OpenId 用于认证（Authentication）

OpenID 是一个以用户为中心的数字身份识别框架，它具有开放、分散性。

OpenID 的创建基于这样一个概念：我们可以通过 URI （又叫URL或网站地址）来认证一个网站的唯一身份，同理，我们也可以通过这种方式来作为用户的身份认证。

OpenID的认证非常简单，当你访问需要认证的A网站时，A网站要求你输入你的OpenID用户名，然后会跳转你的OpenID服务网站，输入用户名密码验证通过后，再跳回A网站，而些时已经显示认证成功。除了一处注册，到处通行外，OpenID还可以使所有支持OpenID的网站共享用户资源，而用户可以控制哪些信息可以被共享，例如姓名、地址、电话号码等。

OpenID Connect，是OpenID的第三代技术

#### OAuth2.0 用于授权（Authorization）

##### OAuth2.0 授权流程

#### OIDC=OpenID Connect =(Identity, Authentication) + OAuth 2.0

OpenID Connect

### 特性

#### 认证即服务

#### Api访问控制

#### 第三方登陆

#### 灵活定制

### 解决了什么问题

#### 集中认证和授权

#### 单点登录和注销

#### 支持Web应用、移动应用、桌面应用

### 一句话解释

#### IdentityServer4是为ASP.NET CORE量身定制的实现了OpenId Connect和OAuth2.0协议的认证授权中间件。我们仅需要提供登录和注销界面即可。

## How

### IdentityServer

#### 1. 配置IdentityServer中间件

`services.AddIdentityServer`

##### 1. 配置受保护的资源列表

###### Identity Resource

```
public static IEnumerable<IdentityResource> GetIdentityResources()
{
    return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };
}

```

####### OpenId

####### Profile

####### Address

####### Phone

####### Email

###### Api Resource

http://docs.identityserver.io/en/release/reference/api_resource.html?highlight=ApiResource

####### API Name

####### UserClaims

访问这个Api需要包含的用户申明。
通过指定UserClaim来检查AccessToken中是否包含指定的申明，来决定是否具有访问权限。

####### ApiSecrets

通过指定ApiSecrets，可以实现本站点内部的Api间的相互直接访问，而不需要再去向IdentityServer去申请访问权限

####### Scopes

每个Api至少有一个Scope，在源码中，IdentifyServer默认添加了一个以ApiName命名的Scope。 

通过Scope来限制客户端的访问范围
```
//ApiResource.cs
Scopes.Add(new Scope(name, displayName));
```

```
new ApiResource {
    Name = "api2",
        Scopes = {
            new Scope () {
            Name = "api2.full_access",
            DisplayName = "Full access to API 2"
            },
            new Scope {
            Name = "api2.read_only",
            DisplayName = "Read only access to API 2"
            }
            },
            UserClaims = { "Phone", "Address" }
            }```
 
 
 但是在某些情况下，您可能希望细分API的功能，并让不同的客户端访问不同的部分。
            

##### 2. 配置允许验证的Client

###### ClientId

###### ClientSecrets

###### AllowedGrandTypes

授权模式：主要包含五种。
IdentityServer4额外添加了对额外的混合模式。比如：
1. ImplicitAndClientCredentials
2. HybridAndClientCredentials
3. ResourceOwnerPasswordAndClientCredentials

####### Implicit

####### Authorization Code

####### Hybrid

####### ResourceOwnerPassword

####### ClientCredentials

###### AllowedScopes

指定Client可以访问的API范围

#### 2. 配置Authtication中间件

`services.AddAuthentication()   .AddGoogle(options =>
    {
    })
    .AddOpenIdConnect("oidc", "OpenID Connect", options =>
    {
    }`

##### 1. 配置第三方 identity provider

##### 2. 配置OIDC

#### 3. 添加IdentityServer中间件到Pipeline

`app.UseIdentityServer();`

### Resource

#### 1. 配置Authorization 中间件

`services.AddMvcCore()            .AddAuthorization()`

#### 2. 配置Authentication 中间件

`services.AddAuthentication("Bearer")
 .AddIdentityServerAuthentication(options =>
    {
        options.Authority = "http://localhost:5000";
        options.RequireHttpsMetadata = false;
        options.ApiName = "api1";
    });`

#### 3. 添加Authentication中间件到Pipeline

### Client

#### ASP.NET 集成

##### 1. 配置Authentication 中间件

##### 2. 配置OIDC身份认证中间件

```

services.AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "oidc";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.SignInScheme = "Cookies";
        options.Authority = "http://localhost:5000";
        options.RequireHttpsMetadata = false;
        options.ClientId = "mvc";
        options.ClientSecret = "secret";
        options.ResponseType = "code id_token";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("api1");
        options.Scope.Add("offline_access");
    });
    
    ```

##### 3. 添加Authentication中间件到Pipeline

#### Console

##### 1. 使用DiscoverClient发现Token Endpoint

// discover endpoints from metadata
var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

##### 2. 使用TokenClient请求Access Token

// request token
var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

##### 3. 使用HttpClient访问Api

// call api
var client = new HttpClient();
client.SetBearerToken(tokenResponse.AccessToken);

## 术语

### User（用户）

### Client（客户端）

### Resource（资源）

#### Identity Data（身份数据）

#### Apis

### IdentityServer（认证授权服务器）

### Token

#### Access Token（访问令牌）

#### Identity Token（身份令牌）

#### 访问令牌较身份令牌更敏感，应该按需提供

### Bearer认证

#### BEARER_TOKEN/access_token

#### Token编码方式

##### JWT

###### 组成部分

<first part>.<second part>.<third part>

####### Header（Base64Url编码）

######## alg

######## typ

####### Payload（Base64Url编码）

######## reserved claims

######## public claims

######## private claims

####### Signature

######## 使用保存在服务端的密钥对其签名，确保不被篡改

###### 优点

####### 通用

####### 紧凑

####### 扩展

## Other

### Reference Tokens
