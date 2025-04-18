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

### 🏪 各平台通用處理（慢速-因應API打得比較重或多的）

| Topic 名稱                     | 說明                       |
|--------------------------------|----------------------------|
| platform.91app.normal          | 91App          |
| platform.cyberbiz.normal       | Cyberbiz       |
| platform.easystore.normal      | Easystore      |
| platform.shopee.normal         | Shopee         |
| platform.shopify.normal        | Shopify        |
| platform.shopline.normal       | Shopline       |

### 🏪 各平台專用處理（一般速-因應API打得比較即時或少量）

| Topic 名稱                     | 說明                       |
|--------------------------------|----------------------------|
| platform.91app                | 91App         |
| platform.cyberbiz             | Cyberbiz       |
| platform.easystore            | Easystore      |
| platform.shopee               | Shopee         |
| platform.shopify              | Shopify        |
| platform.shopline             | Shopline       |

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