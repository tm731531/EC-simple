# EC-Simple Kafka 規範總覽

本文件定義 EC-Simple 中使用的 Kafka 結構與規則，包含：

- Kafka Topic 命名與分類
- 訊息格式（Message Format）
- Job 工廠模式的使用方式
- 範例訊息

---

## 📚 Kafka Topic 一覽

下表為目前使用中的 Kafka Topics 清單。

### 🧠 核心處理類 Topic

| Topic 名稱               | 說明                   |
|--------------------------|------------------------|
| core.backstage.process   | 後台作業處理任務       |
| core.order.process       | 訂單核心處理流程       |

### 📦 訂單事件類 Topic

| Topic 名稱               | 說明                   |
|--------------------------|------------------------|
| order.event.created      | 訂單新增事件           |
| order.event.completed    | 訂單完成事件           |
| order.event.canceled     | 訂單取消事件           |
| order.event.returned     | 訂單退貨事件           |

### 🧮 數據與計算類 Topic

| Topic 名稱                 | 說明                     |
|----------------------------|--------------------------|
| order.quantity.calculate   | 訂單數量與庫存計算處理   |

### 🏪 各平台通用處理（normal）

| Topic 名稱                     | 說明                       |
|--------------------------------|----------------------------|
| platform.91app.normal          | 91App 平台通用事件         |
| platform.cyberbiz.normal       | Cyberbiz 平台通用事件      |
| platform.easystore.normal      | Easystore 平台通用事件     |
| platform.shopee.normal         | Shopee 平台通用事件        |
| platform.shopify.normal        | Shopify 平台通用事件       |
| platform.shopline.normal       | Shopline 平台通用事件      |

### 🏪 各平台專用處理（細項）

| Topic 名稱                     | 說明                       |
|--------------------------------|----------------------------|
| platform.91app                | 91App 特定平台處理         |
| platform.cyberbiz             | Cyberbiz 特定平台處理      |
| platform.easystore            | Easystore 特定平台處理     |
| platform.shopee               | Shopee 特定平台處理        |
| platform.shopify              | Shopify 特定平台處理       |
| platform.shopline             | Shopline 特定平台處理      |

---

## 📦 Kafka 訊息格式（標準）

所有 Kafka 訊息皆使用統一 JSON 結構：

```json
{
  "header": {
    "version": "1.0.0"
  },
  "body": {
    "timestamp": "2025-04-19T12:34:56Z",
    "action": "OrderCreated",
    "data": {
      // 各 action 對應資料
    }
  }
}
```

Header 欄位說明

| 欄位	|類型	|說明   |
|--------------------------------|----------------------------|-----|
| version	|string	|訊息格式版本（ex: 1.0.0）  |


Body  欄位說明

| 欄位	|類型	|說明   |
|--------------------------------|----------------------------|-----|
| timestamp	|string	|ISO8601 時間戳 |
| action	|string	|動作名稱，決定產生對應 Job|
| data	|object	|傳遞給該 Job 的資料內容 |

範例訊息

```json
{
  "header": {
    "version": "1.0.0"
  },
  "body": {
    "timestamp": "2025-04-19T15:00:00Z",
    "action": "OrderCreated",
    "data": {
      "orderId": "ORD123456",
      "platform": "Shopee",
      "items": [
        { "sku": "A123", "qty": 2 },
        { "sku": "B456", "qty": 1 }
      ]
    }
  }
}
```