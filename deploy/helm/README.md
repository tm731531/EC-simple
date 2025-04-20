
## install
### sample
helm install <release-name> ./backend-job
### real
helm install backend-job ./backend-job
helm install shopee-job ./shopee-normal-job
helm install cyberbiz-job ./cyberbiz-normal-job
helm install order-processing-job ./order-processing-job

## update
### sample
helm upgrade <release-name> ./backend-job
### real
helm upgrade backend-job ./backend-job
helm upgrade shopee-job ./shopee-normal-job
helm upgrade cyberbiz-job ./cyberbiz-normal-job
helm upgrade order-processing-job ./order-processing-job

## delete 
### sample
helm uninstall <release-name>
### real
helm uninstall backend-job
helm uninstall shopee-job
helm uninstall cyberbiz-job
helm uninstall order-processing-job