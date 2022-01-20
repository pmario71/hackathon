# Readme

## Goals

* focus is on encrypting service-service communication
* other features e.g. traffic splitting are not considered
  
* Complexity reduction Service-Service comunication
  * provide a unified solution for encrypting communication and operational processes as certificate renewal

* support also Windows-based workloads

## Prerequisits

Hybrid linux-windows cluster is setup in Azure.

* [Setting up an Azure cluster](docs/00_settingup_cluster.md)
* [Understand Workloads used](docs/01_deploying_a_workload.md)

# Summary

## Linkerd Evaluation

* no support for hybrid clusters running linux and windows worker nodes
* linkerd sidecar uses `iptables` for intercepting traffic, which is not available on Windows
* there are no plans to enable Windows support in near future

[more details](docs/02_linkerd_notes.md)

## Open Service Mesh Evaluation

* no support for hybrid clusters running linux and windows worker nodes
* OMS uses `envoy` sidecar, with `envoy` having Windows support
  * however OMS does not make use of a Windows `envoy` version
  * other missing features around node type detection, supporting taints to all scheduling of sidecar on Windows node also missing
* there are no plans described to enable Windows support in near future

[more details](docs/03_open_service_mesh_notes.md)

## Dapr Evaluation

* ongoing ...

[more details](docs/04_dapr_evaluation.md)