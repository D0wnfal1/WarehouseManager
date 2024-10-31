# Указываем базовый образ для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл решения
COPY ["WarehouseManager.sln", "./"]

# Копируем проектные файлы
COPY ["WarehouseManager.WebHost/WarehouseManager.WebHost.csproj", "WarehouseManager.WebHost/"]
COPY ["WarehouseManager.Services/WarehouseManager.Services.csproj", "WarehouseManager.Services/"]
COPY ["WarehouseManager.DataAccess/WarehouseManager.DataAccess.csproj", "WarehouseManager.DataAccess/"]

# Восстанавливаем зависимости для всех проектов
RUN dotnet restore "WarehouseManager.WebHost/WarehouseManager.WebHost.csproj"

# Копируем все файлы проектов
COPY ["WarehouseManager.WebHost/", "WarehouseManager.WebHost/"]
COPY ["WarehouseManager.Services/", "WarehouseManager.Services/"]
COPY ["WarehouseManager.DataAccess/", "WarehouseManager.DataAccess/"]

# Собираем проект
RUN dotnet build "WarehouseManager.WebHost/WarehouseManager.WebHost.csproj" -c Release -o /app/build

# Указываем базовый образ для выполнения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Указываем точку входа приложения
ENTRYPOINT ["dotnet", "WarehouseManager.WebHost.dll"]
