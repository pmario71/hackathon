# Open Service Mesh Notes

## Installation

* install succeeded once `linkerd` got uninstalled correctly

    ```cmd
    osm install `
        --set=OpenServiceMesh.enablePermissiveTrafficPolicy=true `
        --set=OpenServiceMesh.deployPrometheus=true `
        --set=OpenServiceMesh.deployGrafana=true `
        --set=OpenServiceMesh.deployJaeger=true
    ```

## Prototyping

### Deply Example App from OSM Site

* DemoApp: [link to demo app installation](https://release-v0-11.docs.openservicemesh.io/docs/getting_started/quickstart/manual_demo/#create-the-namespaces)
  
* app successfully deployed
* portfoarward scripts only for linux available
* meshing works, but additional observability components are not installed out-of-the-box

### Deploy Windows Workload

* [x] deploy app into separate namespace
* [x] tag the namespace to be meshed

* used again `DemoApp`
* after meshing, the pod did not come up again (hangs in scheduling (0/2))
* removing the `noschedule taint` form Windows node results in the demo app container being started, but the envoy sidecar fails to start with following error:
  
    ```cmd
    Error: failed to start container "envoy": Error response from daemon:
    container envoy encountered an error during hcsshim::System::CreateProcess:
    failure in a Windows system call: The password for this account has expired.
    (0x532)
    ```

* stopping OSM activities
