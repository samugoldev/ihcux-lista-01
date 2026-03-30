using System;

int etapa = 1;
int codigoProduto = 0;
int quantidade = 0;
bool pedidoFinalizado = false;

Console.WriteLine("=== SISTEMA DE PEDIDOS - CANTINA UNA ===");
Console.WriteLine("Dica: Digite 'voltar' para corrigir ou 'cancelar' para sair.\n");

while (!pedidoFinalizado)
{
    switch (etapa)
    {
        case 1: // SELEÇÃO DO PRODUTO
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("[Passo 1 de 3] Seleção de Item");
            Console.Write("Digite o código do produto (1 a 10): ");
            string entradaCod = Console.ReadLine().ToLower();

            if (entradaCod == "cancelar") return;

            if (int.TryParse(entradaCod, out codigoProduto))
            {
                if (codigoProduto >= 1 && codigoProduto <= 10)
                {
                    etapa = 2; // Avança
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erro: Código {codigoProduto} não encontrado. Nossos códigos vão de 1 a 10. Tente novamente.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Entrada inválida! Por favor, digite um número entre 1 e 10.");
                Console.ResetColor();
            }
            break;

        case 2: // QUANTIDADE
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("[Passo 2 de 3] Quantidade");
            Console.Write($"Produto {codigoProduto} selecionado. Quantas unidades deseja? (ou digite 'voltar'): ");
            string entradaQtd = Console.ReadLine().ToLower();

            if (entradaQtd == "cancelar") return;
            if (entradaQtd == "voltar") { etapa = 1; break; }

            if (int.TryParse(entradaQtd, out quantidade) && quantidade > 0)
            {
                etapa = 3;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro: A quantidade deve ser um número inteiro maior que zero.");
                Console.ResetColor();
            }
            break;

        case 3: // CONFIRMAÇÃO
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("[Passo 3 de 3] Confirmação");
            Console.WriteLine($"RESUMO: {quantidade}x Produto Código {codigoProduto}.");
            Console.Write("Confirmar pedido? (S/N ou 'voltar'): ");
            string confirma = Console.ReadLine().ToLower();

            if (confirma == "cancelar") return;
            if (confirma == "voltar") { etapa = 2; break; }

            if (confirma == "s")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✅ Pedido realizado com sucesso! Bom apetite.");
                Console.ResetColor();
                pedidoFinalizado = true;
            }
            else if (confirma == "n")
            {
                Console.WriteLine("Pedido cancelado pelo usuário.");
                return;
            }
            break;
    }
}

Console.WriteLine("\nPressione qualquer tecla para fechar...");
Console.ReadKey();
