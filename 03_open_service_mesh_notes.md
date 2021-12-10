# Open Service Mesh Notes

## Installation

* install succeeded once `linkerd` got uninstalled correctly
    ```
    osm install `
        --set=OpenServiceMesh.deployPrometheus=true `
        --set=OpenServiceMesh.deployGrafana=true `
        --set=OpenServiceMesh.deployJaeger=true
    ```

## Prototyping

### Deploy Windows Workload

* [ ] deploy app into separate namespace
* [ ] tag the namespace to be meshed







