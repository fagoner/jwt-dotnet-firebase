### Jwt Firebase

Webapi that validate JWT generated from Google

#### Steps

- Create a project Firebase

- Get the api key

- Use the credentials and Id's in the file `Startup.cs`

```
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options =>
        {
            options.Authority = "https://securetoken.google.com/<<project-Id>>";
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = "https://securetoken.google.com/<<project-Id>>",
                ValidateAudience = true,
                ValidAudience = "<<project-Id>>",
                ValidateLifetime = true,
            };
        }
    );
    
    ....


    #Important
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      ...
            app.UseRouting();
            # Respect the order
            app.UseAuthentication();
            app.UseAuthorization();
```

- Authorize with the method that fits in the project (Mail/Password)

- Generate Token
  Post to url when the next body:

```
#Url
https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=[API_KEY]

#Body:
{
  "email": "awesomeDev@changeme.som",
  "password": "mysecretpassword",
  "returnSecureToken": "true"
}

# Response

{
  "kind": "identitytoolkit#VerifyPasswordResponse",
  "localId": "****",
  "email": "****",
  "displayName": "",
  "idToken": "****",
  "registered": true,
  "refreshToken": "****",
  "expiresIn": "3600"
}
```
Keep `idToken` that is similar to `eyJhbGciOiJSUzI1NiIsImtpZCI6I....`

- Test with the path `api/tokens/protected`

```
#REQUEST
curl --location -k  --request GET 'https://localhost:5001/api/tokens/protected' \
--header 'Authorization: Bearer eyJhbGciOiJSUzI1N....'

#RESPONSE

{
    "message": "Deluxe and protected Hello World"
}
```

#### Packaged used

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 3.1.9
```

#### Source
- [blog-bertrand-thomasasp-net-core-3-0-and-firebase](https://blog-bertrand-thomas.devpro.fr/2019/10/24/api-authentication-with-asp-net-core-3-0-and-firebase/)
