using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingTest
{
    [TestClass]
    public class ShoppingTest
    {
        [STAThread]
        static void Main()
        {
        }

        [TestMethod]
        public void TotalAmountOfMoney()
        {
            Product[] products=new Product[] {new Product("apples",2),new Product("oranges",3) };            
            Assert.AreEqual(5, TotalCost(products));

        }
        [TestMethod]
        public void CheapestProduct()
        {
           Product[] Products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 3),
                                                new Product("kiwis",4) };
            Assert.AreEqual(9, TotalCost(Products));
            Assert.AreEqual("apples", Cheapest(Products));

        }
        [TestMethod]
        public void EliminateMostExpensiveProduct()
        {
            Product[] Products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };

            Product[] NewProducts=new Product[]{ new Product("apples", 2),
                                                new Product("kiwis",3) };
            Assert.AreEqual(10, TotalCost(Products));
            Assert.AreEqual("apples", Cheapest(Products));
            Assert.AreEqual(TotalCost(NewProducts), TotalCost(EliminateProduct(Products,MostExpensive(Products))));
            
        }
        [TestMethod]
        public void AddNewProduct()
        {
            Product[] Products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };
            Product NewProduct = new Product("apricots", 3);
            Product[] NewListOfProducts = new Product[]{ new Product("apples", 2),
                                                   new Product("apricots",3),
                                                new Product("kiwis",3) };
            Assert.AreEqual(10, TotalCost(Products));
            Assert.AreEqual("apples", Cheapest(Products));
            Assert.AreEqual(TotalCost(NewListOfProducts), TotalCost(AddProduct(Products, MostExpensive(Products),NewProduct)));
            Assert.IsTrue(VerifySameProducts(NewListOfProducts, AddProduct(Products, MostExpensive(Products), NewProduct)));
            CollectionAssert.AreEqual(AddProduct(Products, MostExpensive(Products), NewProduct),NewListOfProducts);
        }

        [TestMethod]
        public void CalculateMediumPrice()
        {
            Product[] Products = new Product[] { new Product("apples", 3),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };
            Product NewProduct = new Product("apricots", 3);
            Product[] NewListOfProducts = new Product[]{ new Product("apples", 3),
                                                   new Product("apricots",3),
                                                new Product("kiwis",3) };
            Assert.AreEqual(11, TotalCost(Products));
            Assert.AreEqual("apples", Cheapest(Products));
            Assert.AreEqual(TotalCost(NewListOfProducts), TotalCost(AddProduct(Products, MostExpensive(Products),NewProduct)));
            Assert.IsTrue(VerifySameProducts(NewListOfProducts, AddProduct(Products, MostExpensive(Products),NewProduct)));
            Assert.AreEqual(3, MediumPrice(NewListOfProducts));
            CollectionAssert.AreEqual(AddProduct(Products, MostExpensive(Products), NewProduct), NewListOfProducts);
        }

        decimal TotalCost(Product[] Product)
        {
            int Cost = 0;
            
            for(int i=0; i<Product.Length;i++)
            {
                Cost += Product[i].Price;
            }

            return Cost;
        }

        string Cheapest(Product[] Products)
        {
            string ProductName = null;
            int k = Products[0].Price;
            int a = 0;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Price < k)
                {
                    k = Products[i].Price;
                    a = i;
                }
            }
            return ProductName+=Products[a].Name;
        }

        int MostExpensive(Product[] Products)
        {
            int k = Products[0].Price;
            int HighestPrice = 0;
            
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Price > k)
                {
                    HighestPrice = Products[i].Price;
                    k = Products[i].Price;
                    
                }

            }
            return HighestPrice;
        }

        Product[] EliminateProduct(Product[] Products,int Price)
        {
            Product[] result = new Product[Products.Length - 1];
            int k = 0;
            for (int j = 0; j < Products.Length; j++)
            {
                if (Products[j].Price == Price)
                {
                    continue;
                }
                result[k] = new Product(Products[j].Name, Products[j].Price);
                k++;
            }
            return result;
        }

        Product[] AddProduct(Product[] Products, int Price,Product NewProduct)
        {
            Product[] result=new Product[Products.Length];
            int k = 0;
            for (int j = 0; j < Products.Length; j++)
            {
                if (Products[j].Price == Price)
                {
                    result[k] = NewProduct;
                        k++;
                    continue;
                }
                result[k] = new Product(Products[j].Name, Products[j].Price);
                k++;
            }
            return result;
        }

        public struct Product
        {
            public string Name;
            public int Price;
            public Product(string names, int prices)
            {
                this.Name = names;
                this.Price = prices;
            }
        }

        bool VerifySameProducts(Product[] InitialProducts,Product[] NewProducts)
        {
            for(int i=0;i<InitialProducts.Length;i++)
            {
                if (InitialProducts[i].Name != NewProducts[i].Name)
                    return false;
            }
            return true;
        }

        decimal MediumPrice(Product[] products)
        {
            decimal result = 0;
            for(int i = 0; i < products.Length; i++)
            {
                result += products[i].Price;
            }
            return result/products.Length;
        }
    }
}
