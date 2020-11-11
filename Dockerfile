FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["src/HrManagement.Identity/HrManagement.Identity.csproj", "./"]
RUN dotnet restore HrManagement.Identity.csproj --no-cache
COPY ./src/HrManagement.Identity/ .
RUN dotnet publish "HrManagement.Identity.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS final
EXPOSE 80
ARG ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=${ENVIRONMENT:-Development}
RUN apk add --no-cache icu-libs tzdata
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "HrManagement.Identity.dll"]