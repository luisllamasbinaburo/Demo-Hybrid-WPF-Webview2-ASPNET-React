# Iniciar servidor ASP.NET Core
Start-Process dotnet -ArgumentList "run --configuration Debug --project HybridAppWPF" -WindowStyle Hidden

# Iniciar Vite
npm --prefix HybridClientReact run dev