# استخدم صورة .NET الأساسية
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# استخدم صورة الـ SDK الخاصة بـ .NET لبناء التطبيق
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StudentAttendanceAPI/StudentAttendanceAPI.csproj", "StudentAttendanceAPI/"]
COPY StudentAttendanceAPI/StudentAttendanceAPI.csproj StudentAttendanceAPI/
RUN dotnet restore "StudentAttendanceAPI/StudentAttendanceAPI.csproj"
COPY . .
WORKDIR "/src/StudentAttendanceAPI"
RUN dotnet build "StudentAttendanceAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentAttendanceAPI.csproj" -c Release -o /app/publish

# المرحلة الأخيرة
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentAttendanceAPI.dll"]