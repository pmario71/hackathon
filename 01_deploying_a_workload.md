# Deploying a Workload

## Use nodeSelector to deploy on linux node

```
nodeSelector:
    "kubernetes.io/os": linux
```
alternatively use:  `"kubernetes.io/os": windows`

## Use taints/tolerations for windows workloads

Tainting windows node:

```
kubectl taint nodes aksnpwin000000 os=windows:NoSchedule
```

```

```

## References

* [Guide for scheduling Windows containers in Kubernetes](https://kubernetes.io/docs/setup/production-environment/windows/user-guide-windows-containers/)