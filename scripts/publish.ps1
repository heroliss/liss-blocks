param([string]$Version='1.0.0')
$ErrorActionPreference='Stop'
$projectRoot=Split-Path -Parent $PSScriptRoot
$out=Join-Path $projectRoot "artifacts/Liss-Blocks-$Version-win-x64"
dotnet publish (Join-Path $projectRoot 'src/Blocks.App/Blocks.App.csproj') -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=none -p:DebugSymbols=false -o $out
if($LASTEXITCODE -ne 0){throw 'Publish failed'}
Copy-Item -LiteralPath (Join-Path $projectRoot 'README.md'),(Join-Path $projectRoot 'THIRD-PARTY-NOTICES.md') -Destination $out -Force
Copy-Item -LiteralPath (Join-Path $projectRoot 'licenses') -Destination $out -Recurse -Force
$zip=Join-Path $projectRoot "artifacts/Liss-Blocks-$Version-win-x64.zip"
Compress-Archive -Path (Join-Path $out '*') -DestinationPath $zip -Force
Get-Item -LiteralPath (Join-Path $out 'Liss.Blocks.exe'),$zip | Select-Object FullName,Length
