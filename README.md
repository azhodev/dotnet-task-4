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
docker compose up --build
```

После запуска:
- приложение: `http://localhost:8080`
- PostgreSQL: `localhost:5433`
- SMTP (Mailpit): `localhost:1025`
- Mailpit Web UI: `http://localhost:8025`

Остановка:

```bash
docker compose down
```

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

## Проверка подтверждения e-mail

1. Зарегистрируйте нового пользователя в приложении.
2. Откройте `http://localhost:8025`.
3. Входящее письмо содержит ссылку подтверждения `ConfirmEmail`.
4. После перехода по ссылке:
   - статус `unverified` меняется на `active`;
   - статус `blocked` остается `blocked`.
