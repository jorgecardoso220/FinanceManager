# Finance Manager API

Table of Contents (up to date)

-  [Finance Manager API](#finance-manager-api)
   -  [Auth](#auth)
      -  [Register](#register)
         -  [Register Request](#register-request)
         -  [Register Respose](#register-response)
      -  [Login](#login)
         -  [Login Request](#login-request)
         -  [Login Respose](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
	"firstName": "Jorge",
	"lastName": "Cardoso",
	"email": "jorgecardoso220@gmail.com",
	"password": "123oliveira4"
}
```

#### Register Request

```js
200 OK
```

```js
{
	"id": "asdasd-asdasdas-asdasdas-asdasdasd",
	"firstName": "Jorge",
	"lastName": "Cardoso",
	"email": "jorgecardoso220@gmail.com",
	"password": "123oliveira4"
}
```
