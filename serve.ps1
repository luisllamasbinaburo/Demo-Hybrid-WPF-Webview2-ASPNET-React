# Iniciar servidor ASP.NET Core
Start-Process chrome -ArgumentList "http://localhost:5173"


Start-Process dotnet -ArgumentList "run --configuration Debug --project ServerAspnet"

# Iniciar Vite
npm --prefix ClientReact run dev

