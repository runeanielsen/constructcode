FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy solution folders and NuGet config
COPY ./*.sln ./

# Copy the main source project files
COPY ./Constructcode.Web/*.csproj ./Constructcode.Web/

RUN dotnet restore

COPY . ./

WORKDIR /app/Constructcode.Web
RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/Constructcode.Web/out .
ENTRYPOINT ["dotnet", "Constructcode.Web.dll"]
