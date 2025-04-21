# EC-Simple

EC-Simple 是一個用 .NET Core 8 打造的輕量級電子商務後台專案，設計初衷是以微服務架構為基礎，整合 Kafka、PostgreSQL，並支援 Jenkins CI/CD 與 Helm 多實例部署到 Kubernetes。

本專案適合作為開源電商系統、背景處理 API 架構範例，或 DevOps CI/CD + K8s 部署實務演練用例。

---

## 🚀 專案特色

- ✅ 使用 .NET 8 開發
- ✅ Job as API：每個背景任務皆以獨立 API 呈現
- ✅ 整合 Kafka 作為任務觸發機制
- ✅ 使用 PostgreSQL 作為核心資料庫
- ✅ Jenkins + Helm 實現 CI/CD 與多實例部署
- ✅ 可水平擴展至 Kubernetes 多 Pod 結構

---
EC-infra 內有整個的Docker compose可快速了解需要什麼環境

## 📦 快速開始

### 1️⃣ 建置 Docker 映像檔

```bash
docker build -t ecsimple:latest .

helm install ecsimple ./deploy/helm-chart
## License

This project is licensed under the **Apache License 2.0** - see the [LICENSE](./LICENSE) file for details.
