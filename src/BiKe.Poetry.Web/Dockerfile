#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/BiKe.Poetry.Web/BiKe.Poetry.Web.csproj", "src/BiKe.Poetry.Web/"]
COPY ["src/BiKe.Poetry.HttpApi/BiKe.Poetry.HttpApi.csproj", "src/BiKe.Poetry.HttpApi/"]
COPY ["src/BiKe.Poetry.Application.Contracts/BiKe.Poetry.Application.Contracts.csproj", "src/BiKe.Poetry.Application.Contracts/"]
COPY ["src/BiKe.Poetry.Domain.Shared/BiKe.Poetry.Domain.Shared.csproj", "src/BiKe.Poetry.Domain.Shared/"]
COPY ["src/BiKe.Poetry.EntityFrameworkCore.DbMigrations/BiKe.Poetry.EntityFrameworkCore.DbMigrations.csproj", "src/BiKe.Poetry.EntityFrameworkCore.DbMigrations/"]
COPY ["src/BiKe.Poetry.EntityFrameworkCore/BiKe.Poetry.EntityFrameworkCore.csproj", "src/BiKe.Poetry.EntityFrameworkCore/"]
COPY ["src/BiKe.Poetry.Domain/BiKe.Poetry.Domain.csproj", "src/BiKe.Poetry.Domain/"]
COPY ["src/BiKe.Poetry.Application/BiKe.Poetry.Application.csproj", "src/BiKe.Poetry.Application/"]

ENV ASPNETCORE_ENVIRONMENT1 Production

RUN dotnet restore "src/BiKe.Poetry.Web/BiKe.Poetry.Web.csproj"
COPY . .
WORKDIR "/src/src/BiKe.Poetry.Web"
RUN dotnet build "BiKe.Poetry.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BiKe.Poetry.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BiKe.Poetry.Web.dll"]
