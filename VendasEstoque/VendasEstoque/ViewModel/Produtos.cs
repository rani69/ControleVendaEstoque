using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using VendasEstoque.Produtos;

// Viewmodel para o Picker de Produtos em Vendas
namespace VendasEstoque.ViewModel
{
    public class Produtos
    {
        public string ProdNome { get; set; }
        public int ProdQtde { get; set; }
    }
}

public class ProdModel : INotifyPropertyChanged
{

    List<Produto> produtoList;
    public List<Produto> ProdutoList
    {
        get { return produtoList; }
        set
        {
            if (produtoList != value)
            {
                produtoList = value;
                OnPropertyChanged();
            }
        }
    }

    Produto selectedProduto;
    public Produto SelectedProduto
    {
        get { return selectedProduto; }
        set
        {
            if (selectedProduto != value)
            {
                selectedProduto = value;
                OnPropertyChanged();
            }
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
