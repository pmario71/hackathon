$bin = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName( $PSScriptRoot), 'bin')

# setting up kubectl
Set-Alias k -Value kubectl

# setting up linkerd
$linkerd="$bin\linkerd2-cli-stable-2.11.1-windows.exe"
Set-Alias linkerd -Value $linkerd
Set-Alias l -Value $linkerd


$Host.ui.WriteLine('Test: ' + $PSScriptRoot)

# setting up Open Service Mesh CLI
Set-Alias osm -Value "$bin\osm.exe"