FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EmployeeDirectoryServer/EmployeeDirectoryServer.csproj", "EmployeeDirectoryServer/"]
RUN dotnet restore "EmployeeDirectoryServer/EmployeeDirectoryServer.csproj"
COPY . .
WORKDIR "/src/EmployeeDirectoryServer"
RUN dotnet build "EmployeeDirectoryServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeDirectoryServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeDirectoryServer.dll"]