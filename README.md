[![Build status](https://ci.appveyor.com/api/projects/status/34m8w6uq27u0a9ey?svg=true)](https://ci.appveyor.com/project/contascwi/accounts)
[![Coverage Status](https://coveralls.io/repos/CWISoftware/accounts/badge.svg?branch=master&service=github)](https://coveralls.io/github/CWISoftware/accounts?branch=master)
[![Stories in Ready](https://badge.waffle.io/CWISoftware/accounts.png?label=ready&title=Ready)](https://waffle.io/CWISoftware/accounts)

# accounts
WIP: CWI OAuth2 provider

http://www.asp.net/identity/overview/getting-started/aspnet-identity-recommended-resources

### Dependencies

[<img src="https://raw.githubusercontent.com/isaacs/npm/master/html/npm-256-square.png" width="100" height="100">](https://www.npmjs.com/package/npm)
[<img src="http://www.codingpedia.org/wp-content/uploads/2014/04/gulp-2x.png" width="100" height="100">](https://github.com/gulpjs/gulp/blob/master/docs/getting-started.md)
[<img src="http://yeoman.io/static/tool-bower.2cc5d0d1ec.png" width="100" height="100">](http://bower.io/#install-bower)
[<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/TypeScript_Logo.png/220px-TypeScript_Logo.png">](http://www.typescriptlang.org/)

### Install the DNX environment

Install the [ASP.NET 5](https://github.com/aspnet/Home#cmd)

Open new shell and execute command about to install runtime:

	dnvm update

### Running first time

Refresh packages from nuget:

	dnu restore

### Run web application

Windows:

	dnx -p .\src\Accounts.Web\ web

Mac\Linux:

	dnx -p .\src\Accounts.Web\ kestrel

### Deploy web application

IIS:

* IIS 8 and [IIS HttpPlatformHandler](http://www.iis.net/downloads/microsoft/httpplatformhandler) ([Announcement](http://blogs.msdn.com/b/webdev/archive/2015/10/15/announcing-availability-of-asp-net-5-beta8.aspx))
* **Roles**: Web Server (IIS) > Web Server > Application Development > .NET 4.5 Extensibility and ASP.NET 4.5
* **Features**: .NET Framework 4.5 Features > .NET Framework 4.5 and ASP.NET 4.5

### Run tests

    dnx -p .\test\Accounts.Web.Tests\ test

## Notes:

1. dnxcore50 is not used because `System.DirectoryServices.AccountManagement` namespace is not suported in dnxcore50. That will be possible when we refactor this feature or use another strategy.