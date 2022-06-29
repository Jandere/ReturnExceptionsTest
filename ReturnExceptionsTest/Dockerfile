FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ReturnExceptionsTest/ReturnExceptionsTest.csproj", "ReturnExceptionsTest/"]
RUN dotnet restore "ReturnExceptionsTest/ReturnExceptionsTest.csproj"
COPY . .
WORKDIR "/src/ReturnExceptionsTest"
RUN dotnet build "ReturnExceptionsTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReturnExceptionsTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReturnExceptionsTest.dll"]
