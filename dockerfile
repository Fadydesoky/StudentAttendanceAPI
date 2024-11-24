FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# نسخ ملفات المشروع
COPY *.csproj ./
RUN dotnet restore

# نسخ بقية الملفات
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "StudentAttendanceAPI.dll"]
