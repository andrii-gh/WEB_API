using _01.Models;
using Microsoft.EntityFrameworkCore;

namespace _01.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (await context.Products.AnyAsync()) return;

            var smartphones = new Category { Name = "Смартфони" };
            var laptops = new Category { Name = "Ноутбуки" };
            var headphones = new Category { Name = "Навушники" };

            context.Categories.AddRange(smartphones, laptops, headphones);
            await context.SaveChangesAsync();

            var phones = new List<Product>
            {
                new() { Name = "iPhone 15 Pro",     Description = "Флагман Apple 2023",           Price = 45999, Amount = 10, Image = "/images/products/iphone15.jpg",  CategoryId = smartphones.Id },
                new() { Name = "Samsung S24 Ultra", Description = "Топовий Android зі стилусом",  Price = 42999, Amount = 8,  Image = "/images/products/s24ultra.jpg", CategoryId = smartphones.Id },
                new() { Name = "Xiaomi 14",         Description = "Компактний флагман",           Price = 28999, Amount = 15, Image = "/images/products/xiaomi14.jpg", CategoryId = smartphones.Id },
                new() { Name = "Google Pixel 8",    Description = "Найчистіший Android",          Price = 31999, Amount = 12, Image = "/images/products/pixel8.jpg",   CategoryId = smartphones.Id },
                new() { Name = "OnePlus 12",        Description = "Швидка зарядка 100W",          Price = 27999, Amount = 7,  Image = "/images/products/oneplus12.jpg",CategoryId = smartphones.Id },
            };

            var laptopsList = new List<Product>
            {
                new() { Name = "MacBook Pro 14",    Description = "M3 Pro, 18GB RAM",            Price = 89999, Amount = 5,  Image = "/images/products/macbook14.jpg", CategoryId = laptops.Id },
                new() { Name = "Dell XPS 15",       Description = "OLED, i7, RTX 4060",          Price = 74999, Amount = 6,  Image = "/images/products/dellxps.jpg",   CategoryId = laptops.Id },
                new() { Name = "Lenovo ThinkPad X1",Description = "Бізнес-клас, легкий",         Price = 65999, Amount = 9,  Image = "/images/products/thinkpad.jpg",  CategoryId = laptops.Id },
                new() { Name = "Asus ROG Zephyrus", Description = "Ігровий, RTX 4070",           Price = 79999, Amount = 4,  Image = "/images/products/rog.jpg",       CategoryId = laptops.Id },
                new() { Name = "HP Spectre x360",   Description = "Трансформер, сенсорний",      Price = 58999, Amount = 11, Image = "/images/products/spectre.jpg",   CategoryId = laptops.Id },
            };

            var headphonesList = new List<Product>
            {
                new() { Name = "AirPods Pro 2",     Description = "Активне шумозаглушення",      Price = 9499,  Amount = 25, Image = "/images/products/airpods.jpg",   CategoryId = headphones.Id },
                new() { Name = "Sony WH-1000XM5",   Description = "Найкращий ANC на ринку",      Price = 13999, Amount = 18, Image = "/images/products/sonyxm5.jpg",   CategoryId = headphones.Id },
                new() { Name = "Bose QC Ultra",     Description = "Преміум звук і комфорт",      Price = 16999, Amount = 12, Image = "/images/products/bose.jpg",      CategoryId = headphones.Id },
                new() { Name = "Sennheiser HD 660S",Description = "Аудіофільські, відкриті",    Price = 18999, Amount = 6,  Image = "/images/products/sennheiser.jpg",CategoryId = headphones.Id },
                new() { Name = "JBL Tune 770NC",    Description = "Бюджетні з ANC",              Price = 3299,  Amount = 40, Image = "/images/products/jbl.jpg",       CategoryId = headphones.Id },
            };

            context.Products.AddRange(phones);
            context.Products.AddRange(laptopsList);
            context.Products.AddRange(headphonesList);

            await context.SaveChangesAsync();
        }
    }
}