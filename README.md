"# api-recursos-erp" 
# API CONSULTA DE INFORMACIÓN PARA ERP
## 

La siguiente API fue realizada en C# utilizando como base de datos MongoDB.


## Características

- Autenticación de usuarios utilizando JWT
- Consulta de recursos de la base de datos MongoDB

## Instalación

Instalar los siguientes paquetes: 

```sh
dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 6.0.4
```

# REST API

Los rutas y métodos son los siguientes:

## Crear un nuevo usuario
## Request
`POST /api/Authenticate`

   
    {
    "Username": "string",
    "Password":"string",
    "Email":"string",
    "Phone":"string",
    "Deporte":"string"
    }


### Response

    {token}



## Login
### Request

`POST /api/Login`

   
    {
    "Username": "string",
    "Password":"string",
    }


### Response

    {token}

## Obtener contenido de tutoriales
### Request

`GET /api/FlujosNow`

## Obtener contenido de guías
### Request

`GET /api/Support`

## License

MIT

