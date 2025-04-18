# Key Setup for Various Platforms

## 1. 91App

### 申請流程：
1. 登入 91App 商家後台。
2. 進入「開發者中心」。
3. 點擊「API 金鑰」或「API 設定」。
4. 點擊「創建新的 API 金鑰」，並填寫相關應用名稱與應用類型。
5. 生成的金鑰可以在開發者控制台查看，並用於您對接 API 的認證。

### 金鑰使用：
- API 密鑰通常包括 `Client ID` 和 `Client Secret`，您需要在您的應用中配置這些金鑰以進行身份驗證和 API 呼叫。

---

## 2. Cyberbiz

### 申請流程：
1. 登入 Cyberbiz 商家後台。
2. 進入「開發者中心」。
3. 點擊「建立新應用」來生成您的 API 金鑰。
4. 填寫應用名稱與描述，選擇需要的權限範圍。
5. 生成的金鑰會顯示在「API 金鑰」頁面，並可供您用來進行 API 呼叫。

### 金鑰使用：
- 金鑰類型通常包括 `API Key` 和 `API Secret`，這些金鑰會被用來認證每個 API 請求。

---

## 3. Easystore

### 申請流程：
1. 登入 Easystore 管理後台。
2. 進入「API 管理」頁面。
3. 點擊「新增 API 密鑰」。
4. 輸入應用名稱、描述以及需要的權限範圍。
5. 點擊生成，並保存金鑰。

### 金鑰使用：
- 您將獲得 `API Key` 和 `API Secret`，您需要將其嵌入到應用的 API 請求中進行驗證。

---

## 4. Shopee

### 申請流程：
1. 登入 Shopee 開發者平台 [Shopee開發者平台](https://open.shopee.com/).
2. 創建開發者帳號並登錄後，進入「應用管理」頁面。
3. 點擊「創建應用」來生成 API 金鑰。
4. 輸入應用的名稱，選擇 API 的存取權限。
5. 完成應用設置後，您將獲得 `API Key`、`API Secret` 和 `Access Token`。

### 金鑰使用：
- 您可以使用 `API Key` 和 `API Secret` 來生成 OAuth 2.0 的 `Access Token`，並用它來進行 API 請求。

---

## 5. Shopify

### 申請流程：
1. 登入 [Shopify Partners](https://partners.shopify.com/)。
2. 創建應用並選擇適用的 API。
3. 進入「Apps」頁面，並選擇「Create App」來生成您的 API 金鑰。
4. 點擊生成並保留 `API Key` 和 `API Secret`。

### 金鑰使用：
- 在 Shopify 中，API 使用 OAuth 2.0 進行授權，您需要配置 `API Key` 和 `API Secret`，並使用它們來獲取存取令牌。

---

## 6. Shopline

### 申請流程：
1. 登入 [Shopline](https://www.shopline.com/) 的商家後台。
2. 進入「開發者」或「應用管理」頁面。
3. 創建新的 API 應用來生成 API 金鑰。
4. 配置 API 權限範圍，並生成金鑰。

### 金鑰使用：
- 您將得到 `API Key` 和 `API Secret`，在進行 API 認證時使用它們。

---

### 注意事項：
- 各平台的 API 金鑰設定方式可能會有細微的不同，但大致上都會要求創建開發者帳戶，生成應用並配置相應的金鑰。申請過程中，您需要明確您需要的 API 權限範圍。
- 這些金鑰應該妥善保管，並只在安全的伺服器上使用，避免將金鑰洩漏在公共代碼庫中。
