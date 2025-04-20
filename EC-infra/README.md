

## close
docker-compose -f ec-data.yml down

## download & start
docker-compose -f ec-data.yml up -d

docker ps -a
>  **
kafka redis  kowl redpanda-console status is CREATED
 **

## start redis & kafka-ui
docker restart redis redpanda-console kowl

docker ps -a

> **kowl must wait for kafka is ready**

> **KRAFT mode need not zk but must write cluster_id**


---

## Kafka KRaft Mode Requires a cluster_id (Base64 UUID)

In Kafka's KRaft mode (when not using Zookeeper), a KAFKA_CLUSTER_ID must be provided at startup.

### ⚠️ Important Notes:
- The cluster_id is not a regular UUID string.

- It must be a Base64 URL-safe encoded version of a UUID (without padding).


---

### ✅ What Format Does Kafka Expect?

- Standard UUID: 550e8400-e29b-41d4-a716-446655440000 (36 characters)
- Kafka expects a format like this:

``` python=
import uuid, base64

u = uuid.uuid4()
b64 = base64.urlsafe_b64encode(u.bytes).rstrip(b'=').decode('ascii')
print(f"Kafka cluster ID: {b64}")
```