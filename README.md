[![Build status](https://ci.appveyor.com/api/projects/status/e3ckfldavu2iwm77/branch/master?svg=true)](https://ci.appveyor.com/project/Britz/accounts/branch/master)
[![Coverage Status](https://coveralls.io/repos/CWISoftware/accounts/badge.svg?branch=master&service=github)](https://coveralls.io/github/CWISoftware/accounts?branch=master)
[![Stories in Ready](https://badge.waffle.io/CWISoftware/accounts.png?label=ready&title=Ready)](https://waffle.io/CWISoftware/accounts)

# accounts
WIP: CWI OAuth2 provider

http://www.asp.net/identity/overview/getting-started/aspnet-identity-recommended-resources
http://www.microsoft.com/en-us/download/details.aspx?id=48222
### Dependencies

* Install [npm](https://www.npmjs.com/package/npm)
* Install [Bower](http://bower.io/#install-bower)

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

### Run tests

    dnx -p .\test\Accounts.Web.Tests\ test