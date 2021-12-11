# Setting up the cluster

information taken from: <https://docs.microsoft.com/en-us/azure/aks/windows-container-cli>

| Name                             | Value                  |
|------------------------------|---------------------|
| resource group               | carbon-1             |
| network security group  | carbon-1-secgrp |

## Create cluster

```cmd
az aks create \ 
--resource-group carbon-1 \ 
--name carbon-1 \ 
--node-count 2 \ 
--enable-addons monitoring \ 
--generate-ssh-keys \ 
--windows-admin-username adminUser \ 
--vm-set-type VirtualMachineScaleSets \ 
--kubernetes-version 1.20.9 \ 
--network-plugin azure
```

> windows user:  adminUser / adm$pwd$4$med123

## Create windows node pool

```cmd
az aks nodepool add \
    --resource-group carbon-1 \
    --cluster-name carbon-1 \
    --os-type Windows \
    --name npwin \
    --node-count 1
```

## Reauthenticate

```cmd
az aks get-credentials -a --resource-group carbon-1 --name carbon-1
```

## Starting / Stopping the cluster

```cmd
az aks start --name carbon-1 --resource-group carbon-1
az aks stop --name carbon-1 --resource-group carbon-1
```

# To remember

to reload profile:

```
profile:  ~/.profile
reload profile:  source ~/.bash
```
