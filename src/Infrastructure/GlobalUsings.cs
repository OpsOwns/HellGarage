﻿global using System.Reflection;
global using Domain.User;
global using Infrastructure.Cqrs;
global using Infrastructure.Database;
global using Infrastructure.Database.Abstractions;
global using Infrastructure.Database.Decorators;
global using Infrastructure.Database.Repositories;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Shared;
global using Shared.Cqrs.Commands;
global using Shared.Cqrs.Queries;
global using Shared.Domain;