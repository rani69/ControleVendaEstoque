using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VendasEstoque;

// Viewmodel para o Picker de Produtos em Clientes
namespace VendasEstoque.ViewModel
{
    public class Clientes
    {
        public string Cli_Nome { get; set; }
    }
}

public class ClienteModel : INotifyPropertyChanged
{

    List<Cliente> clienteList;
    public List<Cliente> ClienteList
    {
        get { return clienteList; }
        set
        {
            if (clienteList != value)
            {
                clienteList = value;
                OnPropertyChanged();
            }
        }
    }

    Cliente selectedCliente;
    public Cliente SelectedCliente
    {
        get { return selectedCliente; }
        set
        {
            if (selectedCliente != value)
            {
                selectedCliente = value;
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
