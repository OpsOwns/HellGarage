﻿global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using Application.Abstractions.Commands;
global using Application.Abstractions.Queries;
global using Application.Abstractions.Security;
global using Application.User.DTO;
global using Domain.User;
global using Domain.User.Abstractions;
global using Infrastructure.Auth;
global using Infrastructure.Cqrs;
global using Infrastructure.Cqrs.Abstractions;
global using Infrastructure.Database;
global using Infrastructure.Database.Abstractions;
global using Infrastructure.Database.Decorators;
global using Infrastructure.Database.Repositories;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Http;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.IdentityModel.Tokens;
global using Shared.Abstractions;