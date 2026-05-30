# Dotnet e Apache Kafka

Projeto de estudo de Event-Driven Architecture (EDA) com Apache Kafka e .NET.

## Infraestrutura

| Serviço    | Imagem                            | Porta  | Descrição                                                                 |
|------------|-----------------------------------|--------|---------------------------------------------------------------------------|
| Zookeeper  | confluentinc/cp-zookeeper:7.3.3   | 2181   | Gerencia o cluster Kafka (metadados, eleição de líder). O Kafka depende dele pra funcionar. |
| Kafka      | confluentinc/cp-kafka:7.3.3       | 9092   | O broker de mensagens em si. Recebe mensagens do Producer e entrega pro Consumer. |
| Kafdrop    | obsidiandynamics/kafdrop:3.30.0   | 19000  | UI web pra visualizar tópicos e mensagens. Acessa em http://localhost:19000. |

> A versão do Kafka está fixada em **7.3.3** pois a partir da 7.4 o Confluent exige **KRaft** (modo sem Zookeeper).

### Subir a infraestrutura

```bash
docker-compose -f docker-config/kafka/docker-compose.yml up -d
```

## Aplicações .NET

| Projeto                        | Tipo           | Framework  | Porta  | Descrição                                              |
|-------------------------------|----------------|------------|--------|--------------------------------------------------------|
| `Kafka.Producer.Api`          | Web API        | .NET 10    | —      | Expõe endpoint `POST /` que envia mensagem ao Kafka.   |
| `Kafka.Consumer.WorkerService`| Worker Service | .NET 10    | —      | Consome mensagens do tópico Kafka em background.       |

Ambos utilizam o pacote **Confluent.Kafka 2.11.1**.

### Tópico

O tópico configurado é **`Livros`**, com `GroupId` **`Lib-1`** no Consumer. Ambas as aplicações apontam para `localhost:9092`.

### Producer — `Kafka.Producer.Api`

Web API Minimal com um único endpoint:

```
POST /?message={texto}
```

Internamente usa `ProducerServices`, que cria um `IProducer<Null, string>` via `ProducerBuilder` e chama `ProduceAsync` no tópico configurado.

### Consumer — `Kafka.Consumer.WorkerService`

Worker Service que sobe um `BackgroundService` (`Worker`). No `ExecuteAsync`:

- Subscreve no tópico `Livros`
- Consome mensagens em loop com `_consumer.Consume(stoppingToken)`
- Loga o conteúdo de cada mensagem recebida
- Aguarda 30 segundos entre cada iteração

No `StopAsync` fecha e descarta o consumer corretamente.

## Status

- [x] Infraestrutura Docker (Zookeeper + Kafka + Kafdrop)
- [x] Producer: Web API com endpoint de envio de mensagem
- [x] Consumer: Worker Service consumindo mensagens do tópico
- [x] Configuração via `appsettings.json` (`BootstrapServer`, `TopicName`, `GroupId`)
- [x] `ParameterModel` para tipagem forte das configurações do Consumer
