# youzr

## setup

- launch `user-manager-vue-dotnet.sln` in Visual Studio
- run the app (both web api and client app should run on same development server @ localhost:5000 or :5001)

### notes

- the app may take some time to install necessary node packages on first run
- the web api uses an in-memory db, so the app is seeded each time it's run with three test users:

```json
{
  email: "user1@user.com",
  password: "user1pw",
  name: "user 1",
},
{
  email: "user2@user.com",
  password: "user2pw",
  name: "user 2",
},
{
  email: "user3@user.com",
  password: "user3pw",
  name: "user 3",
},
```

use any of these as login credentials (login feature not ready yet)

## todo

- user authentication
- login page