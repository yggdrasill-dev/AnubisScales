# AnubisScales 專案指引

## 專案概述

AnubisScales 是一個 .NET 授權框架，採用雙層架構：
- `AnubisScales.Abstractions`: 定義核心授權抽象層
- `AnubisScales.AspNetCore`: 實作 ASP.NET Core Web API 的授權處理

## 核心概念

### 授權系統架構

授權流程由四個關鍵元件組成：

1. **IAuthorizationSystem**: 授權系統核心，負責權限檢查和功能查詢
2. **IAuthorizationFunction**: 表示一個可授權的功能（如 API 端點）
3. **IAuthorizationDataStore**: 權限資料儲存介面，需自行實作
4. **IAuthorizationIdentityResolveProvider**: 解析使用者身分識別的提供者

### HTTP 功能比對模式

AspNetCore 實作使用組合式特徵比對：
- `HttpFunction` 包含多個 `IHttpFeature`
- `HttpPathFeature`: 使用路由範本比對路徑（支援 `{id:int}` 等約束）
- `HttpMethodFeature`: 比對 HTTP 方法（GET、POST 等）
- `HttpCompositeFeature`: 組合多個特徵進行 AND 邏輯比對

範例：
```csharp
new HttpFunction(
    Guid.NewGuid(),
    "GetUser",
    allowAnonymous: false,
    new HttpMethodFeature("GET"),
    new HttpPathFeature("/api/users/{id:int}", serviceProvider)
)
```

## 開發慣例

### 依賴注入模式

使用 Fluent Builder 模式註冊服務：
```csharp
services.AddAnubisScales("SystemName")
    .RegisterAuthorizationDataStore<MyDataStore>()
    .RegisterIdentityResolveProvider<MyIdentityProvider>();

services.AddWebApiAuthorizationMiddlewareResultHandler();
```

### 測試命名規範

測試方法使用中文描述測試情境，遵循「待測方法_測試情境_預期行為」格式：
```csharp
AuthorizationSystem_判斷功能能否存取_如果功能設定允許匿名_會直接回傳能存取()
```

使用 NSubstitute 進行模擬，測試檔案位於對應的 `.UnitTests` 專案。

### 內部實作模式

- `AuthorizationSystem` 是 internal class，透過 DI 工廠方法建立
- 使用 Primary Constructor 簡化依賴注入
- 中介軟體透過 `IMiddleware` 介面實作，不直接使用委派方式

## 建置與測試

- 專案使用 .NET 的現代化專案結構（slnx 格式）
- 測試專案採用 xUnit 框架
- 使用 `dotnet build` 建置，`dotnet test` 執行測試

## 重要檔案參考

- [AuthorizationSystem.cs](AnubisScales.Abstractions/AuthorizationSystem.cs): 核心授權邏輯
- [HttpFunction.cs](AnubisScales.AspNetCore/HttpFunction.cs): HTTP 功能定義
- [MatchFunctionMiddleware.cs](AnubisScales.AspNetCore/MatchFunctionMiddleware.cs): 請求功能比對中介軟體
- [HttpPathFeature.cs](AnubisScales.AspNetCore/HttpPathFeature.cs): 路徑比對實作（含約束處理）
