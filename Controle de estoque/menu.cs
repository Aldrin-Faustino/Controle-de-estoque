
using System.ComponentModel.Design;
using System.Text;

class InterfaceDeControle
{

    Galpao[] galpaos = new Galpao[0];

    public void Novo(Galpao novoProduto)
    {

        Galpao[] AdicionarProduto = new Galpao[galpaos.Length + 1];


        for (int i = 0; i < galpaos.Length; i++)
        {
            AdicionarProduto[i] = galpaos[i];
        }

        AdicionarProduto[AdicionarProduto.Length - 1] = novoProduto;

        galpaos = AdicionarProduto;
    }

    public void Listar()
    {

        Console.WriteLine("\n ====GALPÃO BEBIDAS JÁ!=====\n");
        for (int i = 0; i < galpaos.Length; i++)
        {
            Galpao item = galpaos[i];
            Console.WriteLine($"{i + 1}. {item.Produto}, Valor R$ {item.Valor}, Estoque:({item.Estoque}),Categoria: {item.Categoria}, Grupo: '{item.Grupo}', Código: {item.CodigoProduto}");

        }
    }

    public void RemoverProdutos(int produtoRemover)
    {
        Galpao[] RemoverProduto = new Galpao[galpaos.Length - 1];



        for (int i = 0; i < RemoverProduto.Length; i++)
        {
            if (i >= produtoRemover)
            {
                RemoverProduto[i] = galpaos[produtoRemover + 1];
            }
            else
            {
                RemoverProduto[i] = galpaos[i];
            }
        }

        galpaos = RemoverProduto;
    }

    public void EntradaEstoque(int posicao, int qntd)
    {

        galpaos[posicao].Estoque += qntd;

    }

    public void SaidaEstoque(int posicao, int qntd)
    {
        galpaos[posicao].Estoque -= qntd;
    }

    public void QntdDeProdutos()
    {
        for (int i = 0; i < galpaos.Length; i++)
        {
            Galpao item = galpaos[i];
            Console.WriteLine($"{i + 1}. {item.Produto}");
        }

    }


    public void MostrarProdutos()
    {
        Console.Clear();
        Listar();
        Console.WriteLine("\nSelecione uma opção: \n[1]Acrescentar quantidade \n[2]Diminuir quantidade \n[3]Voltar");
        int opcaoLista = Convert.ToInt16(Console.ReadLine());
        if (opcaoLista == 1)
        {
            AcrescentarQuantidade();
        }
        else if (opcaoLista == 2)
        {
            TirarQuantidade();
        }
        else if (opcaoLista == 3)
        {
            Menu();
        }
        else
        {
            Console.WriteLine("**ERRO** Seleciona uma das opções.");
        }
    }

    public int TirarProdutos(int ProdRemover)
    {
        int remover = 0;
        bool Sair = false;
        Console.Clear();
        while (Sair == false) 
        {
            Console.WriteLine("Digite qual item deseja remover ou Digite [0] Para sair");
            QntdDeProdutos();

            if (int.TryParse(Console.ReadLine(), out remover) && remover >= 1 && remover <= galpaos.Length)
            {

                RemoverProdutos(remover);
                Console.Clear();
                Console.WriteLine("Item removido com sucesso.\n");
                Sair = true;

            }

            else if (remover == 0)
            {
                Console.Clear();
                Sair = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("**ERROR** \n Selecione um número válido, por favor. \n\n");
            }
        
        }
        return remover;
    }

    public void AcrescentarQuantidade()
    {
        {
            int Entrada = 0;
            bool Sair = false;
            Console.Clear();
            while (Sair == false)
            {
                Console.WriteLine("Digite qual item deseja adicionar a quantidade ou [0] para sair");
                QntdDeProdutos();
                Entrada = int.Parse(Console.ReadLine());
                if (Entrada >= 1 && Entrada <= galpaos.Length)
                {

                    Console.WriteLine("Informe a quantidade");
                    int quantidade = 0;
                    int.TryParse(Console.ReadLine(), out quantidade);
                    EntradaEstoque(Entrada - 1, quantidade);
                    Console.Clear();
                    Console.WriteLine("Quantidade atualizada!");
                    Sair = true;
                }

                else if (Entrada == 0)
                {
                    Console.Clear();
                    Sair = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("**ERROR** \n Selecione um número válido, por favor. \n\n");

                }
                
            }
        } 

    }

    public void TirarQuantidade()
    {
        {
            int Entrada = 0;
            bool Sair = false;
            Console.Clear();
            while (Sair == false)
            {
                Console.WriteLine("Digite qual item deseja retirar a quantidade ou [0] para sair");
                QntdDeProdutos();
                Entrada = int.Parse(Console.ReadLine());

                if (Entrada >= 1 && Entrada <= galpaos.Length)
                {

                    Console.WriteLine("Informe a quantidade");
                    int quantidade = 0;
                    int.TryParse(Console.ReadLine(), out quantidade);
                    SaidaEstoque(Entrada - 1, quantidade);
                    Console.Clear();
                    Console.WriteLine("Quantidade atualizada!");
                    Sair = true;
                }

                else if (Entrada == 0)
                {
                    Console.Clear();
                    Sair = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("**ERROR** \n Selecione um número válido, por favor. \n\n");

                }

            }
        }

    }

    public void EscolhaMenu()
    {
        Galpao Adicionar = new Galpao();
        int LeitorNumerico = 0;
        string EscolhaOpcao = "";
        Console.WriteLine("Digite o nome da bebida");
        Adicionar.Produto = Console.ReadLine();


        int codigoProduto = 0;
        Console.WriteLine("Digite o valor"); //Para adicionar valor
        int.TryParse(Console.ReadLine(), out codigoProduto);
        Adicionar.Valor = codigoProduto;

        Console.WriteLine("Digite a quantidade"); //Para acrescentar no estoque
        int.TryParse(Console.ReadLine(), out codigoProduto);
        Adicionar.Estoque = codigoProduto;

        Console.WriteLine("Digite um código para este produto"); //Para identificar o código do produto
        int.TryParse(Console.ReadLine(), out codigoProduto);
        Adicionar.CodigoProduto = codigoProduto;

        Console.WriteLine("Escolha a categoria \n[1] Destilados \n[2] Alcoolicos \n[3] Não Alcoolicos \n[4] Petiscos "); //Mudar para escolher categoria
        EscolhaOpcao = Convert.ToString(Console.ReadLine());
        if (EscolhaOpcao == "1")
        {
            Adicionar.Categoria = "Destilados";
        }
        else if (EscolhaOpcao == "2")
        {
            Adicionar.Categoria = "Alcoolicos";
        }
        else if (EscolhaOpcao== "3")
        {
            Adicionar.Categoria = "Não Alcoolico";
        }
        else if (EscolhaOpcao== "4")
        {
            Adicionar.Categoria = "Petisco";
        }

        else
        {
            Console.WriteLine("**ERROR** \n Selecione uma das opções por favor. \n\n ");
        }


        Console.WriteLine("Escolha o grupo \n[1] Vodka \n[2] Whisky \n[3] Cachaça \n[4] Cerveja \n[5] Vinho \n[6] Gin \n[7] Saquê \n[8] Água \n[9] Snack \n[10] Outros  "); //corrigir
        Adicionar.Grupo = Console.ReadLine();

        if (EscolhaOpcao == "1")
        {
            Adicionar.Grupo = "Vodka";
        }
        else if (EscolhaOpcao == "2")
        {
            Adicionar.Grupo = "Whisky";
        }
        else if (EscolhaOpcao == "3")
        {
            Adicionar.Grupo = "Cachaça";
        }
        else if (EscolhaOpcao == "4")
        {
            Adicionar.Grupo = "Cerveja";
        }

        else if (EscolhaOpcao == "5")
        {
            Adicionar.Grupo = "Vinho ";
        }
        else if (EscolhaOpcao == "6")
        {
            Adicionar.Grupo = "Gin";
        }
        else if (EscolhaOpcao == "7")
        {
            Adicionar.Grupo = "Saquê";
        }
        else if (EscolhaOpcao == "8")
        {
            Adicionar.Grupo = "Água";
        }
        else if (EscolhaOpcao == "9")
        {
            Adicionar.Grupo = "Snack";
        }
        else if (EscolhaOpcao == "10")
        {
            Adicionar.Grupo = "Outros";
        }

        else
        {
            Console.WriteLine("**ERROR** \n Selecione uma das opções por favor. \n\n ");
        }




        Novo(Adicionar);

        Console.Clear();

        Console.WriteLine($"Bebida adicionada com sucesso! \n");
    }

    public void Menu()
    {
        Console.Clear();
        string opcao = "";

        while (opcao != "0")
        {

            string[,] opc = new string[4, 2];

            opc[0, 0] = "[1] Novo            ";
            opc[0, 1] = "[2] Listar Produtos ";
            opc[1, 0] = "[3] Remover Produtos";
            opc[1, 1] = "[4] Entrada Estoque ";
            opc[2, 0] = "[5] Saída Estoque   ";
            opc[2, 1] = "[0] Sair            ";
            opc[3, 0] = "-----BEBIDAS JÁ - CONTROLE DE ESTOQUE----";
            opc[3, 1] = "-----------------------------------------";
            Console.WriteLine($" {opc[3, 0]} \n {opc[0, 0]} {opc[1, 1]}\n {opc[0, 1]} {opc[2, 0]}\n {opc[1, 0]} {opc[2, 1]} \n {opc[3, 1]} ");



            opcao = Convert.ToString(Console.ReadLine());

            if ( opcao == "1" ) // Novo (Acrescentar produtos)
             {

                EscolhaMenu();

             }
             else if ( opcao == "2" ) //Listar produtos
             {
                 MostrarProdutos();
             }

             else if ( opcao == "3" ) //Remover produtos
             {
                int Prodremove = 0;
                TirarProdutos(Prodremove);
             }

             else if ( opcao == "4") //Entrada Estoque
             {
                 AcrescentarQuantidade();
             }

             else if (opcao == "5") //Entrada Estoque
             {
                 TirarQuantidade();
             }


             else if (opcao == "0")
             {
                 Console.WriteLine("Encerrando o Programa...");
                 Environment.Exit(0);
             }

             else
             {
                 Console.Clear();
                 Console.WriteLine("**ERROR** \n Selecione uma das opções por favor. \n\n ");
             } 

        }
    }

}




