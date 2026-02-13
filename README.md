# Task4

Веб-приложение на ASP.NET Core MVC для управления пользователями:
- регистрация и вход;
- таблица пользователей с массовыми действиями (block/unblock/delete/delete unverified);
- PostgreSQL как хранилище.

## Технологии

- .NET 10
- ASP.NET Core MVC
- Entity Framework Core + Npgsql
- PostgreSQL
- Bootstrap

## Запуск локально (Docker)

Требования:
- Docker
- Docker Compose

Команда запуска:

```bash
cp .env.example .env
# edit .env
docker compose up -d --build
```

После запуска:
- приложение: `http://localhost:8080`
- PostgreSQL: `localhost:5433`
- SMTP: внешний SMTP-сервер из `.env` (например, Gmail SMTP)
- Seq (логи): `http://localhost:5341`

Остановка:

```bash
docker compose down
```

## Hot reload в Docker (dotnet watch)

Сервис `web` запускается в dev-режиме через `dotnet watch` и использует bind mount исходников.
Это позволяет применять изменения кода без пересборки образа.

Первый запуск:

```bash
docker compose up -d --build
```

Дальше после изменений в коде обычно достаточно:

```bash
docker compose restart web
```

В большинстве случаев даже `restart` не нужен: `dotnet watch` сам перезапускает приложение.

Сброс БД (с удалением volume):

```bash
docker compose down -v
```

## Применение обновления БД для существующего volume

`docker-entrypoint-initdb.d` выполняется только при первой инициализации БД.  
Если volume уже существует, примените SQL вручную:

```bash
set -a && source .env && set +a
docker compose exec -T db psql -U "$POSTGRES_USER" -d "$POSTGRES_DB" < docker/postgres/migrations/02-email-confirmation.sql
```

## SMTP Secrets

- SMTP параметры вынесены в `.env` (файл в git не попадает).
- Шаблон находится в `.env.example`.
- Для Gmail используйте `App Password`, не обычный пароль аккаунта.

## Логирование (Serilog + Seq)

- Serilog подключен через `Serilog.AspNetCore`.
- Активны sink'и:
  - Console
  - Seq
- Логи в Seq доступны по адресу `http://localhost:5341`.

## Проверка подтверждения e-mail

1. Зарегистрируйте нового пользователя в приложении.
2. Проверьте входящее письмо на почтовом ящике, указанном при регистрации.
3. В письме будет ссылка подтверждения `ConfirmEmail`.
4. После перехода по ссылке:
   - статус `unverified` меняется на `active`;
   - статус `blocked` остается `blocked`.
