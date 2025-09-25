using EFCore_CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_CRUD
{
    public class EFCoreHelper
    {
        public void ReadData()
        {
            AppDbContext db = new AppDbContext();
            List<BlogDataModel> list = db.Blogs.Where(x => x.DeleteFlag == false).ToList();
            foreach (BlogDataModel item in list)
            {
                Console.WriteLine($"Id: {item.BlogId}, Title: {item.BlogTitle}, Author: {item.BlogAuthor}, Content: {item.BlogContent}");
            }
        }

        public void InsertData(BlogDataModel blog)
        {
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Insert Successful." : "Insert Failed.");
        }

        public void UpdateData(BlogDataModel blog)
        {
            AppDbContext db = new AppDbContext();
            BlogDataModel? item = db.Blogs.FirstOrDefault(x => x.BlogId == blog.BlogId);

            if (item is null) {
                Console.WriteLine("No data found.");
                return;
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Update Successful." : "Update Failed.");
        }
        public void DeleteData(BlogDataModel blog)
        {
            AppDbContext db = new AppDbContext();
            BlogDataModel? item = db.Blogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == blog.BlogId);

            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }           
                
            item.DeleteFlag = true;
           
            db.Entry(item).State = EntityState.Modified;

            int result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Delete Successful." : "Delete Failed.");
        }
    }
}