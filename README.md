🏠 Yad2 – Full Stack Real Estate Platform
Live Demo
https://www.yad2-demo-dev.online/

Frontend Repository
https://github.com/HernanRomanello/Yad2-frontend

Backend Repository
https://github.com/HernanRomanello/Yad2-backend

📌 Overview
Yad2 is a production-style full stack real estate platform inspired by real-world property marketplaces.

The system allows users to register, authenticate securely, create and manage property advertisements, upload media, perform advanced searches, save favorite ads, and view recent search history.

The cloud version of the system is configured for production deployment and uses a real domain, secure authentication cookies, and AWS cloud storage.
The GitHub version currently reflects a local configuration, but the production architecture and deployment structure are already implemented and require only configuration adjustments.

The project demonstrates real-world engineering practices across frontend, backend, database design, and cloud services.

🚀 Key Highlights
✔ Full stack architecture using Angular and ASP.NET Core
✔ Secure authentication using HTTP-only cookies
✔ Image upload to AWS S3
✔ CDN delivery via CloudFront
✔ Production deployment using real domain
✔ Responsive UI (desktop, tablet, mobile)
✔ Advanced real estate advertisement model
✔ Integration with Data Gov API for real address suggestions
✔ Favorites system
✔ Recent searches history
✔ REST API architecture
✔ relational database structure

✨ Core Features
User Features
user registration
login system
secure authenticated sessions
create advertisements
edit advertisements
delete advertisements
upload multiple images
upload video
save favorite advertisements
recent searches history
last searches persistence
responsive user interface
Search Features
advanced property search
filtering by city
filtering by street and area
filtering by property type
filtering by price
filtering by rooms
filtering by floor
filtering by property features
integration with Data Gov API for real address suggestions
Advertisement Features
Users can create rich real estate listings including:

city
street
property number
floor
total floors
neighborhood
area
trade type
asset type
asset state
rooms
shower rooms
parking
balconies
square meters
price
price per meter
entry date
description
furniture description
contact details
images
video
Property Characteristics
Supports many real-world property attributes:

elevator
air conditioning
solar water heater
window bars
furnished
pets allowed
kosher kitchen
separate unit
disabled access
safe room
storage room
renovation state
flexible entry date
long-term rental support
🧠 Rich Domain Model
The backend includes a detailed advertisement model designed to represent realistic real estate data.

The model stores structured property data such as:

property metadata
address data
pricing information
property characteristics
media references
contact information
publishing status
user activity data (favorites, views)
This demonstrates handling of complex business entities beyond simple CRUD examples.

🔐 Security Implementation
Authentication and session handling follow production-style practices.

Authentication Flow
authentication via ASP.NET Identity
JWT token generated in backend
token stored inside HTTP-only cookie
cookie automatically sent with requests
cookie inaccessible to client-side JavaScript
Security Protections
HTTP-only cookies
SameSite cookie policy
secure cookie configuration
protected API endpoints
secure password hashing
reduced XSS exposure
safer session management
Using HTTP-only cookies improves protection against token theft and client-side manipulation.

☁️ Cloud Architecture
AWS S3
Used for storing uploaded images and media files.

Benefits:

scalable cloud storage
reliable file hosting
separation of file storage from application logic
AWS CloudFront
Used for faster delivery of media content.

Benefits:

CDN caching
reduced latency
improved loading speed
AWS Elastic Beanstalk
Used to deploy ASP.NET Core backend.

Benefits:

managed infrastructure
simplified deployment
scalable environment
🌐 Custom Domain
Production environment uses real domain:

https://www.yad2-demo-dev.online/

Benefits:

HTTPS enabled
realistic production setup
professional presentation
🔌 External API Integration
The project integrates Data Gov API for retrieving real address data.

Benefits:

real address suggestions
improved search accuracy
improved data quality
more realistic user experience
❤️ Favorites and Search History
Favorites
Users can save advertisements for later viewing.

Recent Searches
The system stores recent search activity allowing users to quickly repeat previous searches.

These features reflect product-oriented thinking and usability improvements.

📱 Responsive Design (Desktop & Mobile)
The UI supports multiple screen sizes and devices.

Originally designed for desktop and later adapted for smaller screens.

Supported screen sizes
desktop
laptop
tablet
mobile
small mobile devices
Responsive adjustments include
flexible layouts
adaptive CSS
responsive spacing
consistent usability across screen sizes
Tested across common breakpoints from 320px up to large desktop resolutions.

🧱 Architecture Overview
Angular SPA
↓
ASP.NET Core API
↓
MySQL Database
↓
AWS S3
↓
CloudFront CDN
↓
Custom Domain HTTPS

🛠 Tech Stack
Frontend
Angular
TypeScript
RxJS
HTML
CSS
Backend
ASP.NET Core
C#
Entity Framework Core
REST API
ASP.NET Identity
JWT via HTTP-only cookies
Database
MySQL
Cloud
AWS S3
AWS CloudFront
AWS Elastic Beanstalk
Tools
Git
GitHub
Postman
Visual Studio
VS Code
📂 Project Structure
Frontend
src/app/

modules
components
services
interceptors
models

Backend
Controllers
Repositories
Models
DTOs
Data

▶ Running Locally
Backend
update connection string in appsettings.json

run:

dotnet restore dotnet run

Frontend
npm install npm start

📈 Future Improvements
improved favorites management
performance optimizations
automated testing
docker configuration
UI improvements
⭐ Production Capabilities Demonstrated
secure authentication architecture
HTTP-only cookie usage
cloud media storage
CDN integration
real domain deployment
complex domain model
search history support
favorites functionality
third-party API integration
responsive UI
👨‍💻 Author
Hernan Romanello

GitHub
https://github.com/HernanRomanello

LinkedIn
https://www.linkedin.com/in/hernan-romanello-/
