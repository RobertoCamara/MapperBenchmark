
# Análise Comparativa: Mapster vs Operator para Mapeamento de Objetos Complexos em .NET 8

Este projeto tem por finalidade apresentar os resultados de um benchmark detalhado entre dois métodos de mapeamento de objetos complexos no .NET 8: o uso de operators nativos da linguagem (manual mapping) e a biblioteca Mapster. A análise leva em consideração desempenho, legibilidade, manutenção, curva de aprendizado, complexidade e extensibilidade.

---

## 🔧 Tecnologias Utilizadas

- .NET 8  
- [Mapster](https://github.com/MapsterMapper/Mapster)  
- [BenchmarkDotNet](https://benchmarkdotnet.org/)  
- [Bogus](https://github.com/bchavez/Bogus)

---

## 📁 Estrutura do Projeto

- `BenchmarkTests`: Contém os benchmarks principais, como `ObjectMappingBenchmark.cs`, `ObjectMappingListBenchmark.cs` e `OrderMappingBenchmark.cs`. Cada arquivo mede cenários diferentes de mapeamento entre entidades e DTOs.
- `Config`: Contém a classe `BenchmarkConfig.cs`, responsável pela configuração do BenchmarkDotNet (ex: colunas, ordenação, warmups, etc).
- `Dtos`: Contém os modelos de transferência de dados (Data Transfer Objects), como `UserDto`, `OrderDto`, `CustomerDto`, entre outros.
- `Entities`: Contém os modelos de domínio utilizados como origem dos mapeamentos, incluindo `User`, `Order`, `Address`, etc.
- `Mapping`: Contém o arquivo `MapsterConfig.cs`, onde é feita a configuração global dos mapeamentos personalizados do Mapster.
- `Program.cs`: Ponto de entrada do projeto. Inicializa os benchmarks com base na configuração desejada.
- `BenchmarkDotNet.Artifacts/results`: Pasta gerada automaticamente com os resultados dos benchmarks executados.

---

## ▶️ Como Executar os Benchmarks

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) instalado  
- Terminal, PowerShell ou Bash

### Execução padrão

Execute o projeto no modo **Release** (requisito do BenchmarkDotNet):

```bash
dotnet run -c Release
```

### Executar benchmark específico

Use o parâmetro `--filter` para rodar apenas um benchmark:

```bash
dotnet run -c Release --filter *OrderMappingBenchmark*
```

### Listar todos os benchmarks disponíveis

```bash
dotnet run -c Release --list
```

---

## 📊 Saída dos Resultados

Ao final da execução, o BenchmarkDotNet gera uma tabela contendo:

- **Method**: Nome do benchmark
- **Mean**: Tempo médio
- **Error / StdDev**: Erro padrão e desvio padrão
- **Allocated**: Quantidade de memória alocada
- **Ops/sec**: Operações por segundo

Os arquivos de resultado também ficam salvos em `BenchmarkDotNet.Artifacts/results`.

---

## 🧠 Análise Qualitativa

### 1. Performance

- **Mapster** é mais rápido tanto para mapeamento de entidades quanto DTOs, mesmo em estruturas complexas.
- **Operators** têm desempenho consistente, mas não tão otimizado quanto os geradores de código do Mapster.

### 2. Manutenção

- **Operator** exige código duplicado e detalhado, tornando-se custoso conforme o modelo cresce.
- **Mapster** reduz boilerplate com configurações globais e expressivas.

### 3. Curva de Aprendizado

- **Operators**: trivial para qualquer desenvolvedor C#.
- **Mapster**: requer compreensão da API, configuração estática/dinâmica e uso de source generators.

### 4. Legibilidade

- **Operator** é mais explícito e claro.
- **Mapster** favorece concisão, mas pode ocultar lógica de transformação.

### 5. Testabilidade

- **Operator**: fácil de isolar, sem dependências externas.
- **Mapster**: requer testes de configurações, especialmente quando definidas por perfil.

### 6. Extensibilidade / Reuso

- **Mapster** permite reutilizar configurações, suporta projeções LINQ, uso com EF Core e outros cenários.
- **Operator** pode ficar verboso e duplicado em várias camadas.

---

### ✅ Benefícios da Adoção do Mapster

- Melhor performance para grandes volumes.
- Redução significativa de boilerplate.
- Suporte a source generators.
- Configurações reutilizáveis e flexíveis.
- Integração com `IServiceCollection` para DI.

---

### ⚠️ Possíveis Prejuízos / Riscos

- Aumento da curva de aprendizado, especialmente para configurações mais complexas.
- Possível ocultamento de lógica, dificultando debugging.
- Dependência de uma biblioteca externa (risco de abandono, bugs, incompatibilidades futuras).

---

### 🧾 Recomendação Final

Com base no benchmark e na análise qualitativa:

> **Recomenda-se a adoção do Mapster** para projetos com alto volume de transformação de objetos, grande complexidade de modelos, ou necessidade de manutenção a longo prazo.  
> Para projetos pequenos ou que demandam extrema clareza no código, o uso de **operators** pode ser mantido.

---

## 📚 Referências

- [Mapster Documentation](https://github.com/MapsterMapper/Mapster)
- [.NET Object Initializers (Microsoft Docs)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers)
- [BenchmarkDotNet](https://benchmarkdotnet.org/)

---

## ✒️ Autor

**Roberto Camara**  
Software Architect & Senior Software Engineer  
.NET, C#, Kafka, RabbitMQ, Azure Service Bus, Docker, Cloud, Microservices  

🔗 [LinkedIn](https://www.linkedin.com/in/robertoalvescamara/)

