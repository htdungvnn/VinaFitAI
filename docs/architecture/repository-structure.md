# 📁 Repository Structure
```
VinaFitAI/
│
├── README.md
├── .gitignore
├── .editorconfig
│
│
├── infra/
│   ├── docker-compose.yml
│   ├── reverse-proxy/
│   │   └── nginx.conf
│   ├── k8s/
│   │   ├── api-gateway.yaml
│   │   ├── auth-service.yaml
│   │   ├── user-service.yaml
│   │   ├── workout-service.yaml
│   │   ├── ai-service.yaml
│   │   └── postgres.yaml
│   ├── db-migrations/
│   │   ├── 001_init_users.sql
│   │   ├── 002_workouts.sql
│   │   └── 003_ai_results.sql
│   ├── env/
│   │   ├── gateway.env
│   │   ├── auth.env
│   │   ├── user.env
│   │   ├── workout.env
│   │   └── ai.env
│   └── scripts/
│       ├── deploy.sh
│       └── migrate.sh
│
│
├── backend/
│   ├── api-gateway/
│   │   ├── ApiGateway.csproj
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   ├── Middlewares/
│   │   │   └── JwtMiddleware.cs
│   │   ├── Endpoints/
│   │   │   ├── AuthProxy.cs
│   │   │   ├── UserProxy.cs
│   │   │   └── WorkoutProxy.cs
│   │   └── Services/
│   │       └── HttpForwarderService.cs
│   │
│   ├── auth-service/
│   │   ├── AuthService.sln
│   │   ├── AuthService.Api/
│   │   │   ├── Program.cs
│   │   │   ├── Endpoints/
│   │   │   │   ├── AuthEndpoints.cs
│   │   │   │   └── TokenEndpoints.cs
│   │   │   ├── appsettings.json
│   │   │   └── AuthService.Api.csproj
│   │   ├── AuthService.Application/
│   │   │   ├── Interfaces/
│   │   │   │   ├── IAuthService.cs
│   │   │   │   └── ITokenService.cs
│   │   │   ├── DTOs/
│   │   │   │   ├── RequestOtpDto.cs
│   │   │   │   └── VerifyOtpDto.cs
│   │   │   ├── Services/
│   │   │   │   └── AuthService.cs
│   │   │   └── AuthService.Application.csproj
│   │   ├── AuthService.Domain/
│   │   │   ├── Entities/
│   │   │   │   └── User.cs
│   │   │   ├── ValueObjects/
│   │   │   └── AuthService.Domain.csproj
│   │   └── AuthService.Infrastructure/
│   │       ├── Persistence/
│   │       │   ├── AuthDbContext.cs
│   │       │   └── UserRepository.cs
│   │       ├── Firebase/
│   │       │   └── FirebaseOtpProvider.cs
│   │       ├── Jwt/
│   │       │   └── JwtTokenGenerator.cs
│   │       └── AuthService.Infrastructure.csproj
│   │
│   ├── user-service/
│   │   ├── UserService.sln
│   │   ├── UserService.Api/
│   │   │   ├── Program.cs
│   │   │   ├── Endpoints/
│   │   │   │   └── UserEndpoints.cs
│   │   │   └── UserService.Api.csproj
│   │   ├── UserService.Application/
│   │   │   ├── Interfaces/
│   │   │   ├── DTOs/
│   │   │   └── Services/
│   │   ├── UserService.Domain/
│   │   │   └── Entities/
│   │   └── UserService.Infrastructure/
│   │       └── Persistence/
│   │
│   ├── workout-service/
│   │   ├── WorkoutService.sln
│   │   ├── WorkoutService.Api/
│   │   │   ├── Program.cs
│   │   │   ├── Endpoints/
│   │   │   │   ├── StartWorkoutEndpoints.cs
│   │   │   │   ├── CompleteWorkoutEndpoints.cs
│   │   │   │   └── HistoryEndpoints.cs
│   │   │   └── WorkoutService.Api.csproj
│   │   ├── WorkoutService.Application/
│   │   │   ├── Services/
│   │   │   │   ├── WorkoutSessionService.cs
│   │   │   │   └── AiResultProcessor.cs
│   │   │   ├── DTOs/
│   │   │   └── Interfaces/
│   │   ├── WorkoutService.Domain/
│   │   │   └── Entities/
│   │   └── WorkoutService.Infrastructure/
│   │       ├── Persistence/
│   │       ├── Repositories/
│   │       └── EventBus/
│   │
│   └── shared/
│       ├── Shared.Core/
│       │   ├── BaseEntity.cs
│       │   ├── IAggregateRoot.cs
│       │   └── Result.cs
│       ├── Shared.Auth/
│       │   ├── JwtValidator.cs
│       │   └── AuthModels.cs
│       └── Shared.Messages/
│           ├── Events/
│           ├── Models/
│           └── MessageBus.cs
│
│
├── ai-service/
│   ├── app/
│   │   ├── main.py
│   │   ├── routers/
│   │   │   ├── pose.py
│   │   │   ├── video.py
│   │   │   └── analyze.py
│   │   ├── inference/
│   │   │   ├── movenet.py
│   │   │   ├── classifier.py
│   │   │   └── utils.py
│   │   ├── pipelines/
│   │   │   ├── pose_pipeline.py
│   │   │   ├── rep_counter.py
│   │   │   ├── angle_detection.py
│   │   │   └── scoring.py
│   │   ├── schemas/
│   │   │   ├── pose_schema.py
│   │   │   └── ai_response.py
│   │   ├── services/
│   │   │   ├── storage_service.py
│   │   │   └── queue_service.py
│   │   └── utils/
│   ├── models/
│   │   ├── movenet.tflite
│   │   └── exercise_classifier.pkl
│   ├── requirements.txt
│   └── Dockerfile
│
│
├── mobile-app/
│   ├── app.json
│   ├── package.json
│   ├── eas.json
│   ├── tsconfig.json
│   └── src/
│       ├── api/
│       │   └── client.ts
│       ├── screens/
│       ├── components/
│       ├── store/
│       │   ├── userStore.ts
│       │   ├── workoutStore.ts
│       ├── camera/
│       └── utils/
│
│
├── admin-dashboard/
│   ├── package.json
│   ├── next.config.js
│   └── src/
│       ├── pages/
│       ├── components/
│       ├── charts/
│       ├── analytics/
│       └── auth/
│
│
└── docs/
    ├── architecture/
    ├── api/
    ├── db/
    └── README.md
```