#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Ira/Ira.csproj", "Ira/"]
COPY ["Database/Database.csproj", "Database/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["BL/BL.csproj", "BL/"]
RUN dotnet restore "Ira/Ira.csproj"
COPY . .
WORKDIR "/src/Ira"
RUN dotnet build "Ira.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ira.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ira.dll"]



# FROM mcr.microsoft.com/dotnet/core/sdk:3.1  AS build-env
# WORKDIR /app


# COPY *.csproj ./
# RUN dotnet restore "Ira/Ira.csproj"


# COPY . ./
# RUN dotnet publish -c Release -o out


# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "DockerUf.dll"]