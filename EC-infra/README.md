

## close

```bash
docker-compose -f ec-data.yml down
```

## download & start

```bash
docker-compose -f ec-data.yml up -d
docker ps -a
```
>  **
kafka redis  kowl redpanda-console status is CREATED
 **

## start redis & kafka-ui

```bash
docker restart redis redpanda-console kowl
docker ps -a
```

> **kowl must wait for kafka is ready**
> **KRaft mode need not zk but must write CLUSTER_ID**


---

## Kafka KRaft Mode Requires a CLUSTER_ID (Base64 UUID)

In Kafka's KRaft mode (when not using Zookeeper), a `KAFKA_CLUSTER_ID` must be provided at startup.

### ⚠️ Important Notes:
- The `CLUSTER_ID` is not a regular UUID string.
- It must be a Base64 URL-safe encoded version of a UUID (without padding).


---

### ✅ What Format Does Kafka Expect?

- Standard UUID: 550e8400-e29b-41d4-a716-446655440000 (36 characters)
- Kafka expects a format like this:

```python
import uuid, base64

u = uuid.uuid4()
b64 = base64.urlsafe_b64encode(u.bytes).rstrip(b'=').decode('ascii')
print(f"Kafka cluster ID: {b64}")
```

---
### Local Volume Persistence
Path: `D:/EC/`
This includes:
* Kafka: `D:/EC/kafka-data`
* Redis: `D:/EC/redisdata`
* Postgres: `D:/EC/Data`
* Grafana: `D:/EC/grafana-storage`
* Kowl: `D:/EC/kowl-storage`

---
### 🚫 Special Port Issue

``` bash= 

Error response from daemon: Ports are not available: exposing port TCP 0.0.0.0:6380 -> 127.0.0.1:0: listen tcp 0.0.0.0:6380: bind: An attempt was made to access a socket in a way forbidden by its access permissions.
```
for redis use `6379` is special port 
To check reserved port ranges, run:
```bash=
netsh int ipv4 show excludedportrange protocol=tcp

```

