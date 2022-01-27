using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avanade.Ecommerce.WPF.Command;
using Avanade.Ecommerce.WPF.Models;

namespace Avanade.Ecommerce.WPF.ViewModels
{

    public class MainWindowViewModel : BaseViewModel
    {
        private IProductRepository _repoProducts;
        public IList<Product> Products => _repoProducts.GetAll();


        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                if (_selectedProduct == value)
                {
                    return;
                }
                _selectedProduct = value;
                NotifyPropertyChanged();
                UpdateChartCommand.RaiseCanExecuteChanged();
                ViewProductCommand.RaiseCanExecuteChanged();
            }
        }

        private bool viewChart = false;
        public bool ViewChart
        {
            get { return viewChart; }
            set { viewChart = value; NotifyPropertyChanged(); }
        }

        private string txtDetails;
        public string TextDetails
        {
            get { return txtDetails; }
            set
            {
                txtDetails = value;
                NotifyPropertyChanged();
            }
        }

        private string txtChart;
        public string TextChart
        {
            get { return txtChart; }
            set
            {
                txtChart = value;
                NotifyPropertyChanged();
            }
        }

        private double totalChart = 0.0;

        public RelayCommand UpdateChartCommand { get; private set; }
        public RelayCommand ViewProductCommand { get; private set; }

        public MainWindowViewModel(IProductRepository repo)
        {
            _repoProducts = repo;
            UpdateChartCommand = new RelayCommand(updateChartExecute, operationCanExecute);
            ViewProductCommand = new RelayCommand(viewProductExecute, operationCanExecute);
        }


        private bool operationCanExecute(object? param)
        {
            return SelectedProduct != null;
        }

        private void updateChartExecute(object? param)
        {
            if (SelectedProduct != null)
            {
                this.totalChart += SelectedProduct.Price;
                //Mostrare a video
                TextChart = $"Hai speso {totalChart} euro";
            }
        }

        private void viewProductExecute(object? param)
        {
            if (SelectedProduct != null)
            {
                //Mostrare a video
                TextDetails = $"{SelectedProduct}";
            }
        }
    }
}
