class Galpao
{
    public string Produto { get; set; } 

    public double Valor { get; set; }

    public int Estoque { get; set; }

    public string Categoria { get; set; } //A categoria define se é destilado, alcoolico ou não alcoolico

    public string Grupo { get; set; } //de qual grupo faz parte vinho, cerveja, whisky, vodka etc..

    public int CodigoProduto { get; set; }//Código do produto define qual é o código de cada item para a busca no banco de dados sem a necessidade do nome.

}