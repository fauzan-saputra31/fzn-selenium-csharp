## ✅ Features

- Selenium WebDriver for UI automation
- Page Object Model for maintainable code
- JSON for test data input
- Configurable via `appsettings.json`
- NUnit
- Test results output as `.trx`

---

## 🛠 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/)
- Visual Studio or compatible IDE
- NuGet packages: Selenium WebDriver, NUnit, etc.

### Run Tests

without report
```bash
dotnet test
```
with report
```bash
dotnet test --logger "trx;LogFileName=TestResults.trx"
```