#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Sample.Template.Api/Sample.Template.Api.csproj", "src/Sample.Template.Api/"]
COPY ["src/Sample.Template.Application/Sample.Template.Application.csproj", "src/Sample.Template.Application/"]
COPY ["src/Sample.Template.CrossCutting/Sample.Template.CrossCutting.csproj", "src/Sample.Template.CrossCutting/"]
COPY ["src/Sample.Template.Domain/Sample.Template.Domain.csproj", "src/Sample.Template.Domain/"]
COPY ["src/Sample.Template.Bootstrap/Sample.Template.Bootstrap.csproj", "src/Sample.Template.Bootstrap/"]
COPY ["src/Sample.Template.Data/Sample.Template.Data.csproj", "src/Sample.Template.Data/"]
RUN dotnet restore "src/Sample.Template.Api/Sample.Template.Api.csproj"
COPY . .
WORKDIR "/src/src/Sample.Template.Api"
RUN dotnet build "Sample.Template.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample.Template.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.Template.Api.dll"]