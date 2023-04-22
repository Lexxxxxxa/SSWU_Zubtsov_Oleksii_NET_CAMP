using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_2
{// тільки початкові сутності. Немає алгоритму розв'язку. Ця задача є складною. Найкраще її розв'язувати, використавши паттерн компонувальник.
    
    public class Store
    {
        public string Name { get; set; }
        public List<Section> Sections { get; set; }

        public Store(string name)
        {
            Name = name;
            Sections = new List<Section>();
        }

        public void AddSection(string sectionName)
        {
            Sections.Add(new Section { Name = sectionName, Products = new List<Product>(), Subsections = new List<Section>() });
        }

        public void AddProduct(string sectionName, string productName, int width, int height, int depth)
        {
            var section = Sections.FirstOrDefault(s => s.Name == sectionName);
            if (section != null)
            {
                section.Products.Add(new Product { Name = productName, Width = width, Height = height, Depth = depth });
            }
        }

        public class Section
        {
            public string Name { get; set; }
            public List<Product> Products { get; set; }
            public List<Section> Subsections { get; set; }
        }

        public class Department
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public List<Product> Items { get; set; }
            public List<Department> Departments { get; set; }

            public bool ContainsItem(Product item)
            {
                return Items.Contains(item) || Departments.Any(d => d.ContainsItem(item));
            }

            public List<Product> GetAllItems()
            {
                var products = new List<Product>();

                foreach (var product in Items)
                {
                    products.Add(product);
                }

                foreach (var department in Departments)
                {
                    products.AddRange(department.GetAllItems());
                }
                return products;
            }

        }

        public class Box
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
            public List<Box> Items { get; set; }
            public Box ParentBox { get; set; }

            public void AddItem(Box box)
            {
                if (Items == null)
                {
                    Items = new List<Box>();
                }

                box.ParentBox = this;
                Items.Add(box);
            }
            public List<Department> Departments { get; set; }

            public void PackItemsIntoBoxes()
            {
                var allItems = GetAllItems();
                var boxes = new List<Box>();

                foreach (var Product in allItems)
                {
                    var box = boxes.FirstOrDefault(b => b.Name == Product.Name);

                    if (box == null)
                    {
                        box = new Box { Name = Product.Name, Width = Product.Width, Height = Product.Height, Depth = Product.Depth };
                        boxes.Add(box);
                    }

                    var department = Departments.FirstOrDefault(d => d.ContainsItem(Product));
                    if (department != null)
                    {
                        var departmentBox = boxes.FirstOrDefault(b => b.Name == department.Name);
                        if (departmentBox == null)
                        {
                            departmentBox = new Box { Name = department.Name, Width = department.Width, Height = department.Height, Depth = department.Depth };
                            boxes.Add(departmentBox);
                        }

                        departmentBox.AddItem(box);
                    }
                    else
                    {
                        box.ParentBox = boxes.FirstOrDefault(b => b.Name == Name);
                        if (box.ParentBox == null)
                        {
                            box.ParentBox = new Box { Name = Name, Width = box.Width, Height = box.Height, Depth = box.Depth };
                            boxes.Add(box.ParentBox);
                        }

                        box.ParentBox.AddItem(box);
                    }
                }

                foreach (var box in boxes)
                {
                    Console.WriteLine($"Box Name: {box.Name}, Width: {box.Width}, Height: {box.Height}, Depth: {box.Depth}, Parent Box: {box.ParentBox?.Name ?? "None"}");
                }
            }

            private List<Product> GetAllItems()
            {
                var items = new List<Product>();

                foreach (var department in Departments)
                {
                    items.AddRange(department.GetAllItems());
                }

                return items;
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }
        }
    }
}
