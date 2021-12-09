# Linkerd Notes

## Setup

```cmd
linkerd viz install | kubectl apply -f -
linkerd viz dashboard &
```

### Jaeger

```cmd
linkerd jaeger install | kubectl apply -f -
```

## 01 Deploy DemoApp and have it meshed

* meshing the DemoApp did not work
* found now information on linkerd slack:
   ![no windows pod support in linkerd](.\images\linkerd-slack-no-windows.png)

**Matei David (Buoyant) 15:56 Uhr**\
@Yonatan Taragin yup, the proxy relies on iptables to redirect networked calls. You can install the mesh of you use linux and opt out of windows pods, yes.\
You won't have mTLS between your unix <> windows pods, since your windows pods will not have the proxy running inside. You will have mTLS between unix <> unix pods.

> **Summary**
> Since `linkerd` does not support encrypting communication for windows pods, communication between linux -> windows and windows -> windows pods needs to be encrypted manually.