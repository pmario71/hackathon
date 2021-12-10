function GetPodName {
    param (
        $pod
    )
    $spec = & kubectl get pods --selector app=$pod -n $pod --no-headers
    return $spec.Split(' ',[System.StringSplitOptions]::RemoveEmptyEntries)[0]
}

function PortForward {
    param (
        $podname,
        $port,
        $sourcePort
    )
    # podname used as namespace as well, convention in example
    $pn = GetPodName($podname)
    & kubectl port-forward $pn -n $podname ${port}:$sourcePort
}

PortForward 'bookbuyer' 8090  14001 
PortForward 'bookthief' 8091  14001 &
PortForward 'bookstore' 8093  14001 &

#kubectl port-forward bookbuyer-86df7f6764-p94mh -n bookbuyer 8090:14001