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
           Product[] products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 3),
                                                new Product("kiwis",4) };
            Assert.AreEqual(9, TotalCost(products));
            Assert.AreEqual("apples", Cheapest(products));

        }
        [TestMethod]
        public void EliminateMostExpensiveProduct()
        {
            Product[] products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };

            Product[] NewProducts=new Product[]{ new Product("apples", 2),
                                                new Product("kiwis",3) };
            Assert.AreEqual(10, TotalCost(products));
            Assert.AreEqual("apples", Cheapest(products));
            Assert.AreEqual(TotalCost(NewProducts), TotalCost(EliminateProduct(products,MostExpensive(products))));
            
        }
        [TestMethod]
        public void AddNewProduct()
        {
            Product[] products = new Product[] { new Product("apples", 2),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };
            Product NewProduct = new Product("apricots", 3);
            Product[] NewProducts = new Product[]{ new Product("apples", 2),
                                                   new Product("apricots",3),
                                                new Product("kiwis",3) };
            Assert.AreEqual(10, TotalCost(products));
            Assert.AreEqual("apples", Cheapest(products));
            Assert.AreEqual(TotalCost(NewProducts), TotalCost(AddProduct(products, MostExpensive(products),NewProduct)));
            Assert.IsTrue(VerifySameProducts(NewProducts, AddProduct(products, MostExpensive(products),NewProduct)));
            
        }

        [TestMethod]
        public void CalculateMediumPrice()
        {
            Product[] products = new Product[] { new Product("apples", 3),
                                                new Product("oranges", 5),
                                                new Product("kiwis",3) };
            Product NewProduct = new Product("apricots", 3);
            Product[] NewProducts = new Product[]{ new Product("apples", 3),
                                                   new Product("apricots",3),
                                                new Product("kiwis",3) };
            Assert.AreEqual(11, TotalCost(products));
            Assert.AreEqual("apples", Cheapest(products));
            Assert.AreEqual(TotalCost(NewProducts), TotalCost(AddProduct(products, MostExpensive(products),NewProduct)));
            Assert.IsTrue(VerifySameProducts(NewProducts, AddProduct(products, MostExpensive(products),NewProduct)));
            Assert.AreEqual(3, MediumPrice(NewProducts));

        }

        decimal TotalCost(Product[] product)
        {
            int cost = 0;
            
            for(int i=0; i<product.Length;i++)
            {
                cost += product[i].price;
            }

            return cost;
        }

        string Cheapest(Product[] products)
        {
            string ProductName = null;
            int k = products[0].price;
            int a = 0;
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].price < k)
                {
                    k = products[i].price;
                    a = i;
                }
            }
            return ProductName+=products[a].name;
        }

        int MostExpensive(Product[] products)
        {
            int k = products[0].price;
            int HighestPrice = 0;
            
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].price > k)
                {
                    HighestPrice = products[i].price;
                    k = products[i].price;
                    
                }

            }
            return HighestPrice;
        }

        Product[] EliminateProduct(Product[] products,int Price)
        {
            Product[] result = new Product[products.Length - 1];
            int k = 0;
            for (int j = 0; j < products.Length; j++)
            {
                if (products[j].price == Price)
                {
                    continue;
                }
                result[k] = new Product(products[j].name, products[j].price);
                k++;
            }
            return result;
        }

        Product[] AddProduct(Product[] products, int Price,Product NewProduct)
        {
            Product[] result=new Product[products.Length];
            int k = 0;
            for (int j = 0; j < products.Length; j++)
            {
                if (products[j].price == Price)
                {
                    result[k] = new Product(NewProduct.name, NewProduct.price);
                        k++;
                    continue;
                }
                result[k] = new Product(products[j].name, products[j].price);
                k++;
            }
            return result;
        }

        struct Product
        {
            public string name;
            public int price;
            public Product(string names,int prices)
            {
                this.name = names;
                this.price = prices;
            }
        }

        bool VerifySameProducts(Product[] InitialProducts,Product[] NewProducts)
        {
            for(int i=0;i<InitialProducts.Length;i++)
            {
                if (InitialProducts[i].name != NewProducts[i].name)
                    return false;
            }
            return true;
        }

        decimal MediumPrice(Product[] products)
        {
            decimal result = 0;
            for(int i = 0; i < products.Length; i++)
            {
                result += products[i].price;
            }
            return result/products.Length;
        }
    }
}
