# Sistema de Gestión de Vuelos y Reservas ✈️

Sistema API REST para la gestión de vuelos y reservas de una aerolínea, desarrollado con .NET 9.0 y arquitectura limpia.

## 📋 Características

- Búsqueda y gestión de vuelos
- Sistema completo de reservas
- Gestión de asientos
- Sistema de check-in
- Cancelación y modificación de reservas
- Consultas por email del pasajero

## 🚀 Tecnologías Utilizadas

- .NET 9.0
- C# 12
- Clean Architecture
- Minimal APIs
- Swagger/OpenAPI

## 📦 Estructura del Proyecto

```
📁 root
├── 📁 core
│   ├── 📁 entities        # Entidades del dominio
│   ├── 📁 interfaces      # Interfaces de repositorios
│   └── 📁 usecases        # Casos de uso de la aplicación
├── 📁 infrastructure
│   └── 📁 data           # Implementaciones de repositorios
└── 📁 DTOs               # Objetos de transferencia de datos
```

## ⚙️ Instalación

1. Clona el repositorio:
```bash
git clone https://github.com/devald-web/API-vuelos.git
```

2. Navega al directorio del proyecto:
```bash
cd sistema-vuelos
```

3. Restaura los paquetes NuGet:
```bash
dotnet restore
```

4. Ejecuta el proyecto:
```bash
dotnet run
```

La API estará disponible en `https://localhost:5165` (o el puerto que se configure).

## 📡 Endpoints API

### Vuelos

#### Obtener todos los vuelos
```http
GET /flights
```

#### Buscar vuelos
```http
GET /flights/search?origin={origin}&destination={destination}&date={date}
```

#### Obtener vuelo por ID
```http
GET /flights/{id}
```

#### Verificar asientos disponibles
```http
GET /flights/{id}/seats
```

### Reservas

#### Crear nueva reserva
```http
POST /reservations
```
```json
{
  "flightId": 1,
  "passengerName": "John Doe",
  "email": "john@example.com",
  "seatNumber": "12A"
}
```

#### Obtener reservas de un vuelo
```http
GET /flights/{id}/reservations
```

#### Obtener reservas por email
```http
GET /reservations/email/{email}
```

#### Cancelar reserva
```http
POST /reservations/{id}/cancel
```

#### Modificar reserva
```http
PUT /reservations/{id}
```
```json
{
  "newSeatNumber": "15B",
  "newPassengerName": "John Smith",
  "newEmail": "john.smith@example.com"
}
```

#### Realizar check-in
```http
POST /reservations/{id}/checkin
```

## 🔍 Estados de Reserva

- **Active**: Reserva creada y activa
- **Cancelled**: Reserva cancelada
- **CheckedIn**: Check-in realizado

## 🛡️ Validaciones

El sistema incluye las siguientes validaciones:

- Verificación de disponibilidad de asientos
- Validación de estados de reserva
- Comprobación de vuelos existentes
- Validación de modificaciones permitidas
- Verificación de check-in

## 🔧 Ejemplos de Uso

### Crear una Reserva

```bash
curl -X POST https://localhost:5165/reservations \
  -H "Content-Type: application/json" \
  -d '{
    "flightId": 1,
    "passengerName": "John Doe",
    "email": "john@example.com",
    "seatNumber": "12A"
  }'
```

### Buscar Vuelos

```bash
curl "https://localhost:5165/flights/search?origin=Madrid&destination=Barcelona&date=2024-02-15"
```

## 📝 Respuestas de Error

El sistema devuelve los siguientes códigos de estado HTTP:

- `200 OK`: Operación exitosa
- `400 Bad Request`: Error en la solicitud
- `404 Not Found`: Recurso no encontrado
- `500 Internal Server Error`: Error del servidor

## 🤝 Contribuir

1. Haz un Fork del proyecto
2. Crea una rama para tu función (`git checkout -b feature/NewFeature`)
3. Realiza tus cambios
4. Haz commit de tus cambios (`git commit -m 'Descripción de los cambios'`)
5. Push a la rama (`git push origin feature/NewFeature`)
6. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT

## ✨ Próximas Funcionalidades

- [ ] Sistema de precios dinámicos
- [ ] Gestión de equipaje
- [ ] Servicios adicionales (comidas, asientos premium)
- [ ] Sistema de puntos de viajero frecuente
- [ ] Notificaciones por email
- [ ] Integración con sistemas de pago

## 📞 Soporte

Si tienes alguna pregunta o problema, por favor abre un issue en el repositorio.

---
Desarrollado con ❤️ por A