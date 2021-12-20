using Caliburn.Micro;
using RMDesktopUI.Library.Api;
using RMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        // C# doesn't allow asynchronous calls in the constructor so this is the workaround
        // After the page has loaded, start loading the products (by calling the API)
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set 
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
            }
        }


        private BindingList<CartItemModel> _cart;

        public BindingList<CartItemModel> Cart
        {
            get { return _cart; }
            set 
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string SubTotal
        {
            // TODO: replace with calculation
            get { return "$0.00"; }  
        }

        public string Tax
        {
            // TODO: replace with calculation
            get { return "$0.00"; }
        }

        public string Total
        {
            // TODO: replace with calculation
            get { return "$0.00"; }
        }




        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set 
            {
                _itemQuantity = value; 
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;
                //logic to determine if it can be set to true

                // Make sure something is selected
                // Make sure there is an item quantity and not null
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;

            }
        }


        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // Make sure something is selected

                return output;

            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // Make sure there is something in the cart

                return output;

            }
        }

        public void CheckOut()
        {

        }
    }
}
