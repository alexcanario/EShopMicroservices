global using EShop.BuildingBlocks.Behaviors;
global using EShop.BuildingBlocks.CQRS;
global using EShop.BuildingBlocks.Exceptions;
global using EShop.BuildingBlocks.Messaging.Events;
global using EShop.BuildingBlocks.Messaging.MassTransit;
global using EShop.BuildingBlocks.Pagination;
global using EShop.Ordering.App.Data;
global using EShop.Ordering.App.DataTransfers;
global using EShop.Ordering.App.Exceptions;
global using EShop.Ordering.App.Extensions;
global using EShop.Ordering.App.Orders.Commands.CreateOrder;
global using EShop.Ordering.Domain.Enums;
global using EShop.Ordering.Domain.Events;
global using EShop.Ordering.Domain.Models;
global using EShop.Ordering.Domain.ValueObjects;

global using FluentValidation;

global using MassTransit;

global using MediatR;

global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;

global using System.Reflection;
