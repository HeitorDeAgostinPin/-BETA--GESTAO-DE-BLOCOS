﻿using System;
using System.Collections.Generic;

class Bloco
{
    public string codigo;
    public string numero;
    public string medidas;
    public string descricao;
    public string tipo_material;
    public double valor_compra;
    public double valor_venda;
    public string pedreira;
}

class Program
{
    static List<Bloco> blocos = new List<Bloco>();

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Cadastrar bloco");
            Console.WriteLine("2 - Listar blocos");
            Console.WriteLine("3 - Buscar bloco por código");
            Console.WriteLine("4 - Listar blocos por pedreira");
            Console.WriteLine("5 - Sair");
            Console.WriteLine("6 - SalvarBlocosEmArquivoTXT()");
            Console.WriteLine("7 - LerBlocosDeArquivoTXT()");
            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Digite novamente.");
                continue;
            }

            try
            {
                switch (opcao)
                {
                    case 1:
                        CadastrarBloco();
                        break;
                    case 2:
                        ListarBlocos();
                        break;
                    case 3:
                        BuscarBlocoPorCodigo();
                        break;
                    case 4:
                        ListarBlocosPorPedreira();
                        break;
                    case 5:
                        sair = true;
                        break;
                    case 6:
                        SalvarBlocosEmArquivoTXT();
                        break;
                    case 7:
                        LerBlocosDeArquivoTXT();
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Digite novamente.");
                       break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro No Programa: " + ex.Message);
            }

            Console.WriteLine();
        }
    }

    private static void LerBlocosDeArquivoTXT()
    {
        try
        {
            string pastaDestino = @"C:\temp"; // Caminho absoluto para a pasta de destino
            Console.WriteLine("Crie a pasta temp no Disco local (C): se ainda não tiver criado");
            Console.WriteLine("Digite o nome do arquivo para salvar os blocos: ");
            Console.Write("Digite o nome do arquivo para ler os blocos: ");
            string nomeArquivo = Console.ReadLine();
            string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

            if (File.Exists(caminhoCompleto))
            {
                using (StreamReader sr = new StreamReader(caminhoCompleto))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        Console.WriteLine(linha);
                    }
                }
            }
            else
            {
                Console.WriteLine("O arquivo especificado não foi encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao ler o arquivo: " + ex.Message);
        }
    }

    static void CadastrarBloco()
    {
        Bloco bloco = new Bloco();

        try
        {
            Console.Write("Digite o código do bloco: ");
            bloco.codigo = Console.ReadLine();

            Console.Write("Digite o número do bloco: ");
            bloco.numero = Console.ReadLine();

            Console.Write("Digite as medidas do bloco: ");
            bloco.medidas = Console.ReadLine();

            Console.Write("Digite a descrição do bloco: ");
            bloco.descricao = Console.ReadLine();

            Console.Write("Digite o tipo de material (mármore ou granito): ");
            bloco.tipo_material = Console.ReadLine();

            Console.Write("Digite o valor de compra do bloco: ");
            bloco.valor_compra = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor de venda do bloco: ");
            bloco.valor_venda = double.Parse(Console.ReadLine());

            Console.Write("Digite a pedreira de origem do bloco: ");
            bloco.pedreira = Console.ReadLine();

            blocos.Add(bloco);

            Console.WriteLine("Bloco cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao cadastrar bloco: " + ex.Message);
        }
    }

    static void ListarBlocos()
    {
        foreach (Bloco bloco in blocos)
        {
            Console.WriteLine($"Código: {bloco.codigo}");
            Console.WriteLine($"Número: {bloco.numero}");
            Console.WriteLine($"Medidas: {bloco.medidas}");
            Console.WriteLine($"Descrição: {bloco.descricao}");
            Console.WriteLine($"Tipo de material: {bloco.tipo_material}");
            Console.WriteLine($"Valor de compra: {bloco.valor_compra}");
            Console.WriteLine($"Valor de venda: {bloco.valor_venda}");
            Console.WriteLine($"Pedreira: {bloco.pedreira}");
            Console.WriteLine();
        }
    }

    static void BuscarBlocoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do bloco que deseja buscar: ");
            string codigo = Console.ReadLine();

            foreach (Bloco bloco in blocos)
            {
                if (bloco.codigo == codigo)
                {
                    Console.WriteLine($"Código: {bloco.codigo}");
                    Console.WriteLine($"Número: {bloco.numero}");
                    Console.WriteLine($"Medidas: {bloco.medidas}");
                    Console.WriteLine($"Descrição: {bloco.descricao}");
                    Console.WriteLine($"Tipo de material: {bloco.tipo_material}");
                    Console.WriteLine($"Valor de compra: {bloco.valor_compra}");
                    Console.WriteLine($"Valor de venda: {bloco.valor_venda}");
                    Console.WriteLine($"Pedreira: {bloco.pedreira}");
                    return;
                }
            }

            Console.WriteLine("Bloco não encontrado!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao buscar bloco por código: " + ex.Message);
        }
    }

    static void ListarBlocosPorPedreira()
    {
        try
        {
            Console.Write("Digite o nome da pedreira: ");
            string pedreira = Console.ReadLine();

            foreach (Bloco bloco in blocos)
            {
                if (bloco.pedreira == pedreira)
                {
                    Console.WriteLine($"Código: {bloco.codigo}");
                    Console.WriteLine($"Número: {bloco.numero}");
                    Console.WriteLine($"Medidas: {bloco.medidas}");
                    Console.WriteLine($"Descrição: {bloco.descricao}");
                    Console.WriteLine($"Tipo de material: {bloco.tipo_material}");
                    Console.WriteLine($"Valor de compra: {bloco.valor_compra}");
                    Console.WriteLine($"Valor de venda: {bloco.valor_venda}");
                    Console.WriteLine($"Pedreira: {bloco.pedreira}");
                    Console.WriteLine();
                }
            }

            if (blocos.Find(bloco => bloco.pedreira == pedreira) == null)
            {
                Console.WriteLine("Nenhum bloco encontrado para essa pedreira.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao listar blocos por pedreira: " + ex.Message);
        }
    }

    static void SalvarBlocosEmArquivoTXT()
    {
        try
        {
            string pastaDestino = @"C:\temp"; // Caminho  para a pasta de destino
            Console.WriteLine("Crie a pasta temp no Disco local (C): se ainda não tiver criado");
            Console.Write("Digite o nome do arquivo para salvar os blocos: ");
            string nomeArquivo = Console.ReadLine();
            string caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);

            using (StreamWriter sw = new StreamWriter(caminhoCompleto, true))
            {
                foreach (Bloco bloco in blocos)
                {
                    sw.WriteLine($"Código: {bloco.codigo}");
                    sw.WriteLine($"Número: {bloco.numero}");
                    sw.WriteLine($"Medidas: {bloco.medidas}");
                    sw.WriteLine($"Descrição: {bloco.descricao}");
                    sw.WriteLine($"Tipo de material: {bloco.tipo_material}");
                    sw.WriteLine($"Valor de compra: {bloco.valor_compra}");
                    sw.WriteLine($"Valor de venda: {bloco.valor_venda}");
                    sw.WriteLine($"Pedreira: {bloco.pedreira}");
                    sw.WriteLine();
                }

                Console.WriteLine("Blocos salvos com sucesso no arquivo em " + caminhoCompleto);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao salvar os blocos no arquivo: " + ex.Message);
        }

        static void LerBlocosDeArquivoTXT()
        {
           
        }

    }

}
