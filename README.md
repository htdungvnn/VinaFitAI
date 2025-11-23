Below is the raw full source code of the README.md file exactly as Markdown.
You can copy/paste directly into GitHub or your repository.

⸻

📄 README.md (RAW MARKDOWN SOURCE CODE)

# 🏋️ VinaFitAI — AI-Powered Personal Trainer Platform  
Mobile App (React Native) + .NET Backend Microservices + Python AI Engine + Supabase + Next.js Admin Dashboard

VinaFitAI is an end-to-end AI fitness platform designed to help users train at home using real-time pose estimation, workout guidance, and progress tracking.

---

# 📚 Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [System Architecture](#system-architecture)
- [Repository Structure](#repository-structure)
- [Services](#services)
- [Setup & Installation](#setup--installation)
- [Environment Variables](#environment-variables)
- [Running the Project](#running-the-project)
- [API Overview](#api-overview)
- [AI Workflow](#ai-workflow)
- [Database Schema](#database-schema)
- [Deployment Guide](#deployment-guide)
- [CI/CD](#cicd)
- [Contributing](#contributing)
- [License](#license)

---

# 🧩 Overview

**VinaFitAI** is an AI-driven fitness assistant built for mobile users.  
Using advanced pose estimation models (MoveNet / MediaPipe), VinaFitAI analyzes workouts in real time, counts reps, gives corrective feedback, and tracks user progress.

This repository contains the complete architecture:
- AI Service (Python)
- Backend API (C# .NET 10)
- Mobile App (React Native)
- Web Admin Dashboard (Next.js)
- Supabase PostgreSQL database
- Cloud Storage for video uploads

---

# ⭐ Features

### 🔐 Authentication
- Phone OTP login (Firebase / .NET)
- JWT + Refresh Token rotation
- Multi-device session support

### 🧠 AI Workout Analysis
- Real-time pose estimation (MoveNet/TF Lite)
- Rep counting
- Form checking
- Exercise classification
- Video frame ingestion

### 📸 Mobile App (React Native)
- 60 FPS Workout Camera with VisionCamera
- Real-time pose overlay
- Workout timer & progress
- User history tracking
- Profile & stats management

### 🗄 Backend Microservices (.NET Minimal API)
- AuthService
- UserService
- WorkoutService
- NotificationService
- API Gateway

### 📊 Admin Dashboard (Next.js)
- User management
- Workout records
- AI performance analytics

---

# 🏗 System Architecture
```
React Native App
│
▼
┌──────────────────────────┐
│   API Gateway (.NET 10)  │
└───────────┬──────────────┘
│
├────────── Auth Service (.NET)
├────────── User Service (.NET)
├────────── Workout Service (.NET)
│
▼
PostgreSQL (Supabase)
│
▼
┌──────────────────────────┐
│   AI Service (Python)    │
│  MoveNet / MediaPipe     │
└───────────┬──────────────┘
│
▼
Cloud Storage (S3/R2)
│
▼
Next.js Admin Dashboard
```
---

# 📁 Repository Structure
```
VinaFitAI/
│
├── README.md
├── .gitignore
├── .editorconfig
│
├── infra/                              # Infrastructure
│   ├── docker-compose.yml
│   ├── reverse-proxy/                  # Nginx / Traefik (optional)
│   ├── k8s/                             # Kubernetes manifests
│   ├── db-migrations/                   # SQL migrations for Supabase
│   ├── env/                             # Environment files templates
│   └── scripts/                         # Deployment scripts
│
├── backend/                             # .NET Microservices
│   ├── api-gateway/                     # Routing / Aggregation
│   │   ├── ApiGateway.csproj
│   │   └── Program.cs
│   │
│   ├── auth-service/
│   │   ├── AuthService.Api/             # Minimal API
│   │   │   ├── Controllers/
│   │   │   ├── Endpoints/
│   │   │   ├── Program.cs
│   │   │   ├── appsettings.json
│   │   │   └── AuthService.Api.csproj
│   │   ├── AuthService.Application/      # Business logic
│   │   ├── AuthService.Domain/           # Entities
│   │   ├── AuthService.Infrastructure/   # DB, Firebase, JWT
│   │   └── AuthService.sln
│   │
│   ├── user-service/
│   │   ├── UserService.Api/
│   │   ├── UserService.Application/
│   │   ├── UserService.Domain/
│   │   ├── UserService.Infrastructure/
│   │   └── UserService.sln
│   │
│   ├── workout-service/
│   │   ├── WorkoutService.Api/
│   │   ├── WorkoutService.Application/
│   │   ├── WorkoutService.Domain/
│   │   ├── WorkoutService.Infrastructure/
│   │   └── WorkoutService.sln
│   │
│   └── shared/                          # Shared .NET libs (optional)
│       ├── Shared.Core/
│       ├── Shared.Auth/
│       └── Shared.Messages/
│
├── ai-service/                          # Python AI Engine
│   ├── app/
│   │   ├── routers/
│   │   │   ├── pose.py
│   │   ├── models/
│   │   │   ├── movenet.tflite
│   │   │   └── pose_classifier.pkl
│   │   ├── core/
│   │   │   ├── inference.py
│   │   │   ├── preprocess.py
│   │   │   └── pose_utils.py
│   │   ├── services/
│   │   ├── schemas/
│   │   └── main.py                      # FastAPI root
│   ├── requirements.txt
│   └── Dockerfile
│
├── mobile-app/                          # React Native + Expo
│   ├── src/
│   │   ├── api/                         # API client for backend
│   │   ├── screens/
│   │   ├── components/
│   │   ├── hooks/
│   │   ├── store/                       # Zustand / Redux
│   │   ├── utils/
│   │   ├── navigation/
│   │   └── camera/                      # VisionCamera
│   │       ├── WorkoutCamera.tsx
│   │       ├── PoseOverlay.tsx
│   │       └── frame-processor.ts
│   ├── package.json
│   ├── app.json
│   ├── eas.json
│   └── tsconfig.json
│
├── admin-dashboard/                     # Next.js 15 Admin Panel
│   ├── src/
│   │   ├── app/
│   │   ├── components/
│   │   ├── auth/
│   │   ├── charts/
│   │   ├── layout/
│   │   └── pages/
│   ├── next.config.js
│   └── package.json
│
└── docs/                                # Documentation
    ├── architecture/
    │   ├── high-level-diagram.png
    │   ├── microservice-diagram.png
    │   ├── ai-flow.png
    │   └── mobile-workflow.png
    ├── api/
    │   ├── auth-service-openapi.yaml
    │   ├── workout-service-openapi.yaml
    │   └── ai-service-openapi.yaml
    ├── db/
    │   ├── erd.png
    │   └── schema.sql
    └── README.md
```
---

# 🔧 Services
```
### 📌 1. Auth Service (.NET 10 Minimal API)
- Phone OTP login
- JWT access token
- Refresh token management
- User session tracking

### 📌 2. User Service (.NET)
- User profile
- Preferences
- Subscription status
- Device management

### 📌 3. Workout Service (.NET)
- Workout history
- AI results saving
- Score calculation
- Exercise library

### 📌 4. AI Service (Python FastAPI)
- Pose estimation (MoveNet Lightning/Thunder)
- Rep counting
- Form correction detection
- Exercise classification
- Skeleton overlay (optional)

### 📌 5. Admin Dashboard (Next.js)
- Authentication (Admin)
- Workout analytics
- User activity charts
- AI performance monitor
```
---

# ⚙️ Setup & Installation

## 1️⃣ Clone project

```sh
git clone https://github.com/<your-org>/vinafitai.git
cd vinafitai
```

2️⃣ Install dependencies
```
Backend (.NET)

cd backend
dotnet restore

AI Service

cd ai-service
pip install -r requirements.txt

Mobile App

cd mobile-app
npm install

Admin Dashboard

cd admin-dashboard
npm install
```

⸻

🔐 Environment Variables
```
Example for .NET AuthService

JWT_KEY=super-secret-key
JWT_ISSUER=VinaFitAI
JWT_AUDIENCE=VinaFitAI-Mobile
DB_CONNECTION=Host=...;Port=5432;User Id=...;Password=...
FIREBASE_CREDENTIALS=./firebase.json

Example for AI Service (Python)

MODEL_PATH=./models/movenet.tflite
TEMP_DIR=./tmp
```

⸻

▶️ Running the Project

🐳 Using Docker Compose
```
cd infra
docker compose up -d --build

📱 Mobile App

cd mobile-app
npx expo start
```

⸻

📡 API Overview
```
Auth API

POST /auth/request-otp
POST /auth/verify-otp
POST /auth/refresh-token
GET  /auth/me

AI Service

POST /ai/pose/analyze
POST /ai/pose/video

Workout API

POST /workouts/start
POST /workouts/complete
GET  /workouts/history
```

⸻

🤖 AI Workflow

	1.	React Native camera streams frames or video
	2.	Frames uploaded to AI-Service
	3.	AI extracts:
	•	Keypoints
	•	Pose classification
	•	Repetition count
	•	Angles / posture
	4.	Result returned to WorkoutService
	5.	Mobile app displays real-time guidance

⸻

🗄 Database Schema
```
Users

id (uuid)
phone
created_at
profile_name
avatar
subscription_status

Workout History

id
user_id
exercise_id
reps
score
duration
created_at

AI Results

id
workout_id
keypoints_json
score
tips
video_url

```
⸻

🚀 Deployment Guide
```
Backend & AI
	•	Docker Swarm
	•	Kubernetes
	•	Fly.io
	•	Render
	•	Railway
	•	AWS ECS

Web Dashboard (Next.js)
	•	Vercel
	•	Netlify
	•	AWS Amplify

Mobile App (Expo)
	•	EAS Build (iOS/Android)
```
⸻

🔄 CI/CD
```
Using GitHub Actions:
	•	Lint + Test on PR
	•	Build Docker images
	•	Deploy to staging/production
	•	Automated DB migrations
```
⸻

🤝 Contributing
```
	1.	Fork the project
	2.	Create a feature branch
	3.	Submit Pull Request
	4.	Wait for code review
```
⸻

📄 License

MIT License © 2025 VinaFitAI

---