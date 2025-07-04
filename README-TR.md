# ProductApp - Clean Architecture Ürün Yönetimi API'si

## Genel Bakış

ProductApp, Clean Architecture prensipleri kullanılarak geliştirilmiş modern bir .NET 7 Web API uygulamasıdır. MediatR kullanarak CQRS (Command Query Responsibility Segregation) pattern implementasyonu ile ürün yönetimi için RESTful API sağlar.

## 🏗️ Mimari

Uygulama, Clean Architecture prensiplerini takip ederek endişelerin net bir şekilde ayrılmasını sağlar:

```
src/
├── Core/
│   ├── ProductApp.Domain/          # Domain varlıkları ve iş kuralları
│   └── ProductApp.Application/      # Uygulama mantığı, CQRS handlers, DTOs
├── Infrastructure/
│   └── Persistence/                 # Entity Framework ile veri erişim katmanı
└── WebApi/
    └── ProductApp.WebApi/          # API controllers ve konfigürasyon
```

### Katman Açıklamaları

- **Domain Katmanı**: Temel iş varlıklarını ve domain mantığını içerir
- **Application Katmanı**: MediatR ile CQRS pattern kullanarak use case'leri implement eder
- **Infrastructure Katmanı**: Entity Framework Core kullanarak veri kalıcılığını yönetir
- **WebApi Katmanı**: REST endpoint'lerini expose eder ve HTTP isteklerini yönetir

## 🚀 Kullanılan Teknolojiler

- **.NET 7**: En güncel .NET framework
- **ASP.NET Core Web API**: REST API'ler oluşturmak için
- **Entity Framework Core 7.0.3**: Veri erişimi için ORM
- **In-Memory Database**: Geliştirme ve test için
- **MediatR 12.0.0**: CQRS pattern implementasyonu için
- **AutoMapper 12.0.1**: Nesne-nesne eşlemesi için
- **Swagger/OpenAPI**: API dokümantasyonu için
- **Clean Architecture**: Sürdürülebilir ve test edilebilir kod yapısı için

## 📋 Özellikler

### Ürün Yönetimi
- **Ürün Oluşturma**: İsim, miktar ve kalite ile yeni ürünler ekleme
- **Tüm Ürünleri Getirme**: Tüm ürünlerin listesini alma
- **ID ile Ürün Getirme**: Belirli ürün detaylarını alma

### API Endpoint'leri

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| GET | `/api/Product` | Tüm ürünleri getir |
| GET | `/api/Product/{id}` | ID ile ürün getir |
| POST | `/api/Product` | Yeni ürün oluştur |

### Ürün Modeli

```csharp
public class Product
{
    public Guid Id { get; set; }           // Benzersiz tanımlayıcı
    public DateTime CreateDate { get; set; } // Oluşturulma zamanı
    public string? Name { get; set; }       // Ürün adı
    public int Quantity { get; set; }       // Mevcut miktar
    public int Quality { get; set; }        // Kalite puanı
}
```

## 🛠️ Başlangıç

### Gereksinimler

- .NET 7 SDK
- Visual Studio 2022 veya VS Code
- Git

### Kurulum

1. **Repository'yi klonlayın**
   ```bash
   git clone <repository-url>
   cd ProductApp
   ```

2. **Bağımlılıkları geri yükleyin**
   ```bash
   dotnet restore
   ```

3. **Solution'ı derleyin**
   ```bash
   dotnet build
   ```

4. **Uygulamayı çalıştırın**
   ```bash
   cd src/WebApi/ProductApp.WebApi
   dotnet run
   ```

5. **API'ye erişin**
   - API Base URL: `https://localhost:7xxx` veya `http://localhost:5xxx`
   - Swagger UI: `https://localhost:7xxx/swagger`

## 📖 API Kullanım Örnekleri

### Ürün Oluşturma

```bash
curl -X POST "https://localhost:7xxx/api/Product" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "Örnek Ürün",
       "quantity": 100,
       "quality": 5
     }'
```

### Tüm Ürünleri Getirme

```bash
curl -X GET "https://localhost:7xxx/api/Product"
```

### ID ile Ürün Getirme

```bash
curl -X GET "https://localhost:7xxx/api/Product/{product-id}"
```

## 🏛️ Tasarım Desenleri

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Yazma işlemlerini yönetir (CreateProductCommand)
- **Queries**: Okuma işlemlerini yönetir (GetAllProductsQuery, GetProductByIdQuery)

### Repository Pattern
- Veri erişim mantığını soyutlar
- Test edilebilir veri katmanı sağlar

### Mediator Pattern
- İstek/yanıt işlemlerini ayırır
- Cross-cutting concern'leri merkezileştirir

## 🗂️ Proje Yapısı Detayları

### Domain Katmanı (`ProductApp.Domain`)
- `Entities/Product.cs`: Temel ürün varlığı
- `Common/BaseEntity.cs`: Ortak özellikler içeren temel varlık

### Application Katmanı (`ProductApp.Application`)
- `Features/Commands/`: Yazma işlemleri için command handler'lar
- `Features/Queries/`: Okuma işlemleri için query handler'lar
- `Dto/`: Veri transfer nesneleri
- `Interfaces/`: Repository arayüzleri
- `Mapping/`: AutoMapper profilleri
- `Wrapper/`: Response wrapper sınıfları

### Infrastructure Katmanı (`ProductApp.Persistence`)
- `Context/`: Entity Framework DbContext
- `Repositories/`: Repository implementasyonları
- `ServiceRegistration.cs`: Dependency injection konfigürasyonu

### WebApi Katmanı (`ProductApp.WebApi`)
- `Controllers/ProductController.cs`: REST API endpoint'leri
- `Program.cs`: Uygulama başlatma ve konfigürasyon

## 🔧 Konfigürasyon

Uygulama geliştirme için in-memory database kullanır. Konfigürasyon şu dosyalarda değiştirilebilir:
- `appsettings.json`: Genel uygulama ayarları
- `appsettings.Development.json`: Geliştirme ortamına özel ayarlar

## 🧪 Test

Uygulama test edilebilirlik göz önünde bulundurularak tasarlanmıştır:
- Endişelerin net ayrımı
- Dependency injection
- Veri erişimi için repository pattern
- İş mantığı ayrımı için CQRS

## 🔍 Teknik Detaylar

### CQRS Implementasyonu
Uygulama, okuma ve yazma işlemlerini ayırmak için CQRS pattern'ini kullanır:

**Command Örneği:**
```csharp
public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
{
    public int Quantity { get; set; }
    public int Quality { get; set; }
    public string? Name { get; set; }
}
```

**Query Örneği:**
```csharp
public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
{
    // Query parametreleri burada tanımlanır
}
```

### AutoMapper Kullanımı
Nesneler arası dönüşüm için AutoMapper kullanılır:
- Domain Entity → DTO dönüşümleri
- Command → Domain Entity dönüşümleri

### Service Response Wrapper
Tüm API yanıtları tutarlı format için wrapper sınıfı kullanır:
```csharp
public class ServiceResponse<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
```

## 🚀 Gelişmiş Özellikler

### Dependency Injection
Uygulama .NET Core'un built-in DI container'ını kullanır:
- Repository'ler için interface-implementation binding
- MediatR handler'ların otomatik registration'ı
- AutoMapper profil registration'ı

### Swagger Integration
API dokümantasyonu için Swagger/OpenAPI entegrasyonu:
- Otomatik API dokümantasyonu
- Interactive API testing
- Request/Response model'lerin görselleştirilmesi

## 📊 Performans Considerations

- **In-Memory Database**: Hızlı geliştirme ve test için optimize edilmiş
- **Async/Await Pattern**: Non-blocking I/O operations
- **CQRS**: Okuma ve yazma işlemlerinin optimize edilmesi
- **AutoMapper**: Efficient object mapping

## 🔒 Güvenlik

Mevcut implementasyon temel güvenlik özelliklerini içerir:
- HTTPS support
- CORS configuration
- Input validation (model binding)

**Üretim için önerilen ek güvenlik önlemleri:**
- Authentication & Authorization
- Rate limiting
- Input sanitization
- SQL injection protection (EF Core otomatik sağlar)

## 🤝 Katkıda Bulunma

1. Repository'yi fork edin
2. Feature branch oluşturun
3. Değişikliklerinizi commit edin
4. Branch'e push yapın
5. Pull Request oluşturun

## 📈 Gelecek Geliştirmeler

- [ ] Authentication & Authorization
- [ ] Caching implementation (Redis)
- [ ] Database migration (SQL Server/PostgreSQL)
- [ ] Unit & Integration tests
- [ ] Docker containerization
- [ ] CI/CD pipeline
- [ ] Logging & Monitoring
- [ ] API versioning

## 📄 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır.

## 📞 Destek

Sorular ve destek için lütfen repository'de issue açın.

---

**Clean Architecture ve .NET 7 kullanılarak ❤️ ile geliştirilmiştir**