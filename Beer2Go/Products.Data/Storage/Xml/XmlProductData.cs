using Products.Data.Models;
using Products.Data.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Products.Data.Storage.Xml
{
    internal class XmlProductData : IProductData
    {
        String FilePath { get; set; }
        XmlSerializer Serializer { get; set; }

        internal XmlProductData(String filePath)
        {
            if (filePath == null) throw new ArgumentNullException("filePath");
            if (String.IsNullOrWhiteSpace(filePath)) throw new ArgumentException("filePath cannot be whitespace");

            Serializer = new XmlSerializer(typeof(List<Product>), new Type[] {  });
            FilePath = filePath;
            InitXmlFile();
        }

        protected void InitXmlFile()
        {
            try
            {
                if(AllProducts().Count == 0)
                {
                    using (FileStream stream = File.OpenWrite(FilePath))
                    {
                        List<Product> list = new List<Product>();
                        Serializer.Serialize(stream, list);
                    }
                }
            }
            catch (InvalidOperationException)
            {
                using (FileStream stream = File.OpenWrite(FilePath))
                {
                    List<Product> list = new List<Product>();
                    Serializer.Serialize(stream, list);
                }
            }
            catch(FileNotFoundException)
            {
                File.Create(FilePath).Dispose();
                InitXmlFile();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return AllProducts();
        }

        public Product GetProductById(int productId)
        {
            return GetAllProducts().Where(x => x.ProductID == productId).FirstOrDefault();
        }

        public int StoreProduct(Product product)
        {
            var products = AllProducts();
            product.ProductID = DateTime.Now.Millisecond;
            products.Add(product);
            using(FileStream stream = File.Open(FilePath,FileMode.Create))
            {
                Serializer.Serialize(stream, products);
            }
            return product.ProductID;
        }

        public void UpdateInventory(int productId, int diff)
        {
            List<Product> products = AllProducts();
            Product p = products.Where(x => x.ProductID == productId).FirstOrDefault();
            if (p != null)
            {
                p.Inventory += diff;
                using (FileStream stream = File.Open(FilePath, FileMode.Create))
                {
                    Serializer.Serialize(stream, products);
                }
            }
        }

        public void SetInventory(int productId, int quantity)
        {
            List<Product> products = AllProducts();
            Product p = products.Where(x => x.ProductID == productId).FirstOrDefault();
            if (p != null)
            {
                p.Inventory = quantity;
                using (FileStream stream = File.Open(FilePath, FileMode.Create))
                {
                    Serializer.Serialize(stream, products);
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            List<Product> products = AllProducts();
            Product p = products.Where(x => x.ProductID == productId).FirstOrDefault();
            if (p != null)
            {
                products.Remove(p);
                using (FileStream stream = File.Open(FilePath, FileMode.Create))
                {
                    Serializer.Serialize(stream, products);
                }
            }
        }

        private List<Product> AllProducts()
        {
            var products = new List<Product>();
            using (FileStream stream = File.OpenRead(FilePath))
            {
                products = (List<Product>)Serializer.Deserialize(stream);
            }
            return products;
        }

        public void Dispose()
        {
            return;
        }

        public override string ToString()
        {
            return "Xml Products Database";
        }
    }
}
