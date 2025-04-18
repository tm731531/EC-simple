# Key Setup for Various Platforms

## 1. 91App

### 申請流程：
1. 登入 91App 商家後台。
2. 取得金鑰

### 金鑰使用：
- 打API時 在Header中帶入 "x-api-key" 的Key 帶上Token

---

## 2. Cyberbiz

### 申請流程：
1. 需申請第三方平台APP
2. 得到APP的ID跟KEY

### 金鑰使用：
- 使用方式為第三方授權，因此程式端需要有第一次授權並且自動更新機制

---

## 3. Easystore

### 申請流程：
1. 需申請第三方平台APP
2. 得到APP的ID跟KEY

### 金鑰使用：
- 使用方式為第三方授權，因此程式端需要有第一次授權並且自動更新機制

---

## 4. Shopee

### 申請流程：
1. 需申請第三方平台APP
2. 得到APP的ID跟KEY

### 金鑰使用：
- 使用方式為第三方授權，因此程式端需要有第一次授權並且自動更新機制

---

## 5. Shopify

### 申請流程：
1. 登入 [Shopify Partners](https://partners.shopify.com/)。
2. 創建應用並選擇適用的 API。
3. 進入「Apps」頁面，並選擇「Create App」來生成您的 API 金鑰。
4. 點擊生成並保留 `API Key` 和 `API Secret`。

### 金鑰使用：
- 在 Shopify 中，因網站為subdomain模式，需要subdomain 跟 Header帶 "X-Shopify-Access-Token"類似91APP。

---

## 6. Shopline

### 申請流程：
1. 需申請第三方平台APP
2. 得到APP的ID跟KEY

### 金鑰使用：
- 使用方式為第三方授權，因此程式端需要有第一次授權並且自動更新機制

---

### 注意事項：
- 各平台的 API 金鑰設定方式可能會有細微的不同，但大致上都會要求創建開發者帳戶，生成應用並配置相應的金鑰。申請過程中，您需要明確您需要的 API 權限範圍。
- 這些金鑰應該妥善保管，並只在安全的伺服器上使用，避免將金鑰洩漏在公共代碼庫中。
