using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DemoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }
        private async void LoadProducts()
        {
            try
            {
                using (DemoDbContext db = new DemoDbContext())
                {
                    var products = await db.Products
                        .Include(p => p.Category)
                        .Include(p => p.Manufacturer)
                        .Include(p => p.StockItems)
                        .AsNoTracking()
                        .ToListAsync();
                    var result = products.Select(p => new
                    {
                        Image = LoadImage(p.Image),
                        Title = (p.Manufacturer?.Manufacturer1 ?? "") + " | " + (p.Name ?? ""),
                        Category = p.Category?.Category ?? "",
                        Quantity = p.StockItems.Sum(s => s.Count ?? 0),
                        Compound = p.Compound ?? "",
                        Price = p.Price ?? 0
                    }).ToList();
                    ProductList.ItemsSource = result;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки товаров: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private BitmapImage? LoadImage(string? imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;
            string path;
            if (System.IO.Path.IsPathRooted(imageName))
            {
                path = imageName;
            }
            else
            {
                path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageName.Replace('/', System.IO.Path.DirectorySeparatorChar));
                if (!System.IO.File.Exists(path))
                {
                    path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", System.IO.Path.GetFileName(imageName));
                }
            }
            if (!System.IO.File.Exists(path))
                return null;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = new Uri(path);
            image.EndInit();
            return image;
        }
    }
}