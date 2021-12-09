$linkerd='C:\TFS\hackathon\bin\linkerd2-cli-stable-2.11.1-windows.exe'
Set-Alias linkerd -Value $linkerd
Set-Alias l -Value $linkerd

# az login potentially required before
az aks get-credentials --resource-group carbon-1 --name carbon-1