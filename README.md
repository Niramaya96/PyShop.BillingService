# Задача:
Разработайте сервис биллинга, с возможностью эмиссии внутренней валюты (Coins, или Монеты) приложения, передачи валюты от пользователя к пользователю, находить монету с самой длинной историей перемещения.

### Прото-файл сервиса

```
# billing.proto
syntax = "proto3";

package billing;

option csharp_namespace = "Billing";

service Billing {
  rpc ListUsers (None) returns (stream UserProfile);
  rpc CoinsEmission (EmissionAmount) returns (Response);
  rpc MoveCoins (MoveCoinsTransaction) returns (Response);
  rpc LongestHistoryCoin (None) returns (Coin);
}

message None {
}

message UserProfile {
  string name = 1;
  optional int64 amount = 2;
}

message MoveCoinsTransaction {
  string src_user = 1;
  string dst_user = 2;
  int64 amount = 3;
}

message Response {
  enum Status {
    STATUS_UNSPECIFIED = 0;
    STATUS_OK = 1;
    STATUS_FAILED = 2;
  }

  Status status = 1;
  string comment = 2;
}

message EmissionAmount {
  int64 amount = 1;
}

message Coin {
  int64 id = 1;
  string history = 2;
}
```

- Billing.ListUsers() – перечисляет пользователей в сервисе. При инициализации создайте в сервисе следующих пользователей, поле rating потребуется при эмиссии:
```
[
    {
        "name": "boris",
        "rating": 5000
    },
    {
        "name": "maria",
        "rating": 1000
    },
    {
        "name": "oleg",
        "rating": 800
    }
]
```

- Billing.CoinsEmission() – распределяет по пользователям amount монет, учитывая рейтинг. Пользователи получают количество монет пропорциональное рейтингу, при этом каждый пользователь должен получить не менее 1-й монеты. Каждая монета имеет свой id и историю перемещения между пользователями, начиная с эмиссии.
- Billing.MoveCoins() – перемещает монеты от пользователя к пользователю если у пользователя-источника достаточно монет на балансе, в противном случае возвращает ошибку.
- Billing.LongestHistoryCoin() – возвращает монету с самой длинной историей перемещения между пользователями.
### Замечания к реализации 
Для разработки серверной части следует использовать .NET Core 6.
Интегрировать базу данных в этом задании не стоит, достаточно хранить информацию в памяти сервиса, инициализируя его данными пользователей при каждом запуске.
