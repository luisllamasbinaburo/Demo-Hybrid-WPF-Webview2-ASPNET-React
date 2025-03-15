# Publicar
$wwwrootPath = ".\ServerAspnet\wwwroot"

if (Test-Path $wwwrootPath) {
    Remove-Item -Path $wwwrootPath -Recurse -Force
}

$publishPath = ".\publish"

if (Test-Path $publishPath) {
    Remove-Item -Path $publishPath -Recurse -Force
}

dotnet publish AppWPF -c Release -o packed -r win-x64 --self-contained true