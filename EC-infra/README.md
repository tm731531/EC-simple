

## close
docker-compose -f ec-data.yml down

## download & start
docker-compose -f ec-data.yml up -d
docker ps -a
:::info 
kafka redis  kowl kafdrop status is CREATED
:::

## start kafka & redis
docker restart kafka redis
docker ps -a
:::info 
kowl kafdrop status is CREATED , wait for kafka is ready
use docker logs kafka
:::

## start kowl & kafdrop
docker restart kowl kafdrop
docker ps -a