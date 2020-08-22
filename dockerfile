# .NET Core SDK
FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine AS dotnetcore-sdk

WORKDIR /source

# Copy Projects
COPY source/Application/Dietician.Application.csproj ./Application/
COPY source/Database/Dietician.Database.csproj ./Database/
COPY source/Domain/Dietician.Domain.csproj ./Domain/
COPY source/Model/Dietician.Model.csproj ./Model/
COPY source/Web/Dietician.Web.csproj ./Web/

# .NET Core Restore
RUN dotnet restore ./Web/Dietician.Web.csproj

# Copy All Files
COPY source .

# .NET Core Build and Publish
FROM dotnetcore-sdk AS dotnetcore-build
RUN dotnet publish ./Web/Dietician.Web.csproj -c Release -o /publish

# Angular
FROM node:13.11-alpine AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /frontend
ENV PATH /frontend/node_modules/.bin:$PATH
COPY source/Web/Frontend/package.json .
RUN npm run restore
COPY source/Web/Frontend .
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.3-alpine AS aspnetcore-runtime
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=dotnetcore-build /publish .
COPY --from=angular-build /frontend/dist ./Frontend/dist
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "Dietician.Web.dll"]
