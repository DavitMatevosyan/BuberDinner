# Login 

```
POST {{host}}/auth/login
```

### Login Request

```json
{
    "email": "dav@test.com",
    "password": "Davoo123"
}
```

```js
200 OK
```


### Login Response

```json
{
  "id": "645bd670-e7ae-4bd4-87ff-7ebe58e798d2",
  "firstName": "Dav",
  "lastName": "Mat",
  "email": "davMat@gmail.com",
  "token": "token"
}
```
