# Iniciar servidor ASP.NET Core
Start-Process dotnet -ArgumentList "run --configuration Debug --project HybridAppWPF" -WindowStyle Hidden

# Iniciar Vite
npm --prefix HybridClientUI run dev