# aspnet web api template

[![Build status](https://ci.appveyor.com/api/projects/status/2kd6y98veiki3fyq/branch/master?svg=true)](https://ci.appveyor.com/project/eduardobursa/aspnet-web-api-template/branch/master)
[![License](http://img.shields.io/:license-MIT-blue.svg)](https://raw.githubusercontent.com/eduardobursa/aspnet.web_api-template/master/LICENSE)

## What?
This is a project template to bootstrap a web api application with common configuration and features.

What is included?
- Asp .net web api
- OAuth / Bearer token default configuration, 
- Swagger / Swashbuckle to expose api documentation
 - An entry point for swagger UI customization
- Elmah for error logging

## Getting started
Althought you can download and use it, I strongly recommend to use [jumpStart](https://github.com/giacomelli/jumpstart).

With jumpStart you have just to run the command below changing ***My.Amazing.NewProject*** with an approprieted namespace that suits your project:

```shell
jumpstart -tf https://github.com/eduardobursa/aspnet.web_api-template/archive/master.zip -f Result -tn EduardoBursa.Templates.WebApi -n My.Amazing.NewProject.WebApi
```
