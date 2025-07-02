# Mapster Benchmark

Este projeto demonstra o uso da biblioteca [Mapster](https://github.com/MapsterMapper/Mapster) para mapeamento de objetos complexos com foco em performance. Utiliza também a biblioteca [Bogus](https://github.com/bchavez/Bogus) para gerar dados realistas e o [BenchmarkDotNet](https://benchmarkdotnet.org/) para medir o desempenho de diferentes abordagens de mapeamento.

---

## 🔧 Tecnologias Utilizadas

- .NET 8
- Mapster
- BenchmarkDotNet
- Bogus

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

## 👤 Autor

Desenvolvido por [Roberto Alves Camara](https://www.linkedin.com/in/robertoalvescamara/)