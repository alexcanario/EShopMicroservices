global using System.Reflection;
global using System.Text.Json;

global using Carter;

global using EShop.Basket.API.Data;
global using EShop.Basket.API.DataTransfers;
global using EShop.Basket.API.Exceptions;
global using EShop.Basket.API.Models;
global using EShop.BuildingBlocks.Behaviors;
global using EShop.BuildingBlocks.CQRS;
global using EShop.BuildingBlocks.Exceptions;
global using EShop.BuildingBlocks.Exceptions.Handler;
global using EShop.BuildingBlocks.Messaging.Events;
global using EShop.BuildingBlocks.Messaging.MassTransit;
global using EShop.Discount.Grpc;

global using FluentValidation;

global using HealthChecks.UI.Client;

global using JasperFx;

global using Mapster;

global using Marten;

global using MassTransit;

global using MediatR;

global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Caching.Distributed;