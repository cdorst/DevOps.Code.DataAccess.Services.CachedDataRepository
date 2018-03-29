# DevOps.Code.DataAccess.Services.CachedDataRepository

[![AppVeyor build status](https://img.shields.io/appveyor/ci/cdorst/devops-code-dataaccess-services-cacheddatareposito.svg?label=AppVeyor&style=for-the-badge)](https://ci.appveyor.com/project/cdorst/devops-code-dataaccess-services-cacheddatareposito)
[![NuGet package status](https://img.shields.io/nuget/v/CDorst.DevOps.Code.DataAccess.Services.CachedDataRepository.svg?label=NuGet&style=for-the-badge)](https://www.nuget.org/packages/CDorst.DevOps.Code.DataAccess.Services.CachedDataRepository)

## Description

Represents a generic data-access repository with caching

## Environment Variables

This project depends on this environment variable:

Name | Description
---- | -----------
`LOCAL_NUGET_SOURCE_PATH` | *Required* to build the project, but not required during code execution. This is set to `c:\projects\nuget\cache` on the build server. On your development machine, set this to an empty, existing path. `dotnet restore` will inspect this folder prior to checking NuGet.

## Dependencies

Name | Status
---- | ------
[CDorst.DevOps.Code.DataAccess.Interfaces.CacheService](https://github.com/CDorst/DevOps.Code.DataAccess.Interfaces.CacheService) | [![AppVeyor build status](https://img.shields.io/appveyor/ci/cdorst/devops-code-dataaccess-interfaces-cacheservice.svg?label=AppVeyor&style=flat-square)](https://ci.appveyor.com/project/cdorst/devops-code-dataaccess-interfaces-cacheservice) [![NuGet package status](https://img.shields.io/nuget/v/CDorst.DevOps.Code.DataAccess.Interfaces.CacheService.svg?label=NuGet&style=flat-square)](https://www.nuget.org/packages/CDorst.DevOps.Code.DataAccess.Interfaces.CacheService)
[CDorst.DevOps.Code.DataAccess.Services.DataRepository](https://github.com/CDorst/DevOps.Code.DataAccess.Services.DataRepository) | [![AppVeyor build status](https://img.shields.io/appveyor/ci/cdorst/devops-code-dataaccess-services-datarepository.svg?label=AppVeyor&style=flat-square)](https://ci.appveyor.com/project/cdorst/devops-code-dataaccess-services-datarepository) [![NuGet package status](https://img.shields.io/nuget/v/CDorst.DevOps.Code.DataAccess.Services.DataRepository.svg?label=NuGet&style=flat-square)](https://www.nuget.org/packages/CDorst.DevOps.Code.DataAccess.Services.DataRepository)

## NuGet

This project is published as a NuGet package at [https://www.nuget.org/packages/CDorst.DevOps.Code.DataAccess.Services.CachedDataRepository](https://www.nuget.org/packages/CDorst.DevOps.Code.DataAccess.Services.CachedDataRepository)

## Version

1.0.5

## Metaproject

DevOps.Code.DataAccess.Services.CachedDataRepository is maintained by robots and exists because of a declarative template metaproject. View the metaproject's component directory at [https://github.com/CDorst/Project.Index](https://github.com/CDorst/Project.Index)

