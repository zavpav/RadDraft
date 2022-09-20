#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./WebAppRep.csproj", "WebAppRep/"]
COPY ["./Dx/*.*", "WebAppRep/Dx/"]
WORKDIR "/src/WebAppRep"
RUN ls .
RUN ls Dx/
RUN dotnet restore "WebAppRep.csproj"
COPY . .
RUN dotnet build "WebAppRep.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAppRep.csproj" -c Release -o /app/publish

FROM base AS final
RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
        libharfbuzz0b \
        libfreetype6 \
        fontconfig \
     && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppRep.dll"]