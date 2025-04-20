

## close
docker-compose -f ec-data.yml down

## download & start
docker-compose -f ec-data.yml up -d

docker ps -a
>  **
kafka redis  kowl kafdrop status is CREATED
 **

## start redis & kafka-ui
docker restart redis redpanda-console kowl

docker ps -a

> **kowl must wait for kafka is ready**

> **KRAFT mode need not zk but must write cluster_id **