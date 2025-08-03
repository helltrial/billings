# Billing Service

Микросервис для учета использования ресурсов и автоматического выставления счетов.

## 🧩 Архитектура

- **ASP.NET Core Web API** + **Clean Architecture**
- **CQRS** с использованием **MediatR**
- **Event Sourcing** через **Kafka**
- **Materialized Views** в **PostgreSQL**
- **Docker Compose** для инфраструктуры

## 📦 Компоненты

- **Usage** — создание записей использования (Usage)
- **Invoice** — создание инвойсов на основе Usage
- **Kafka** — брокер событий для взаимодействия между сервисами
- **PostgreSQL** — хранение материализованных представлений

## 🚀 Запуск

```bash
docker-compose up -d
```

После запуска будут доступны:
- Kafka: `localhost:9092`
- PostgreSQL: `localhost:5432` (пользователь: `billing_user`, пароль: `billing_password`)
- Kafka UI: http://localhost:8080

## 🔄 Автоматические миграции

EF Core миграции применяются автоматически при запуске приложения.

## 📡 Kafka Topics

- `usage-created`
- `invoice-created`

## 🧪 Тестирование

Событие `usage-created` вызывает автоматическое создание `invoice-created`.

## 📁 Структура проекта

- `Domain` — бизнес-логика
- `Application` — CQRS-команды/обработчики
- `Infrastructure` — Kafka и PostgreSQL
- `API` — ASP.NET контроллеры

## ✅ Планы

- Подключение Notification Service
- Добавление метрик
- Поддержка агрегированных инвойсов

---

> Автор: Юрий  
> Платформа: .NET 8 + Kafka + PostgreSQL  
