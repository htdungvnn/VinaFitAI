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