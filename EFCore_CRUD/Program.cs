using EFCore_CRUD;
using EFCore_CRUD.Models;

Console.WriteLine("Press Key - 'R' : To Read Data , 'C' : To Insert , 'U' : To Update , 'D' : To Delete , Others : To Exit Program");
string input = Console.ReadLine().ToUpper();

while (input == "R" || input == "C" || input == "U" || input == "D")
{ 
    EFCoreHelper eFCoreHelper = new EFCoreHelper();

    switch (input) 
    {
        case "R":
            eFCoreHelper.ReadData();
            break;
        case "C":
            Console.WriteLine("Enter Blog Title:");
            string title = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Blog Author:");
            string author = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Enter Blog Content:");
            string content = Console.ReadLine() ?? string.Empty;
            var newBlog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            eFCoreHelper.InsertData(newBlog);
            break;
        case "U":
            Console.WriteLine("Enter Blog ID to Update:");
            if (int.TryParse(Console.ReadLine(), out int blogId))
            {
                Console.WriteLine("Enter New Blog Title:");
                string newTitle = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter New Blog Author:");
                string newAuthor = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("Enter New Blog Content:");
                string newContent = Console.ReadLine() ?? string.Empty;
                var updatedBlog = new BlogDataModel
                {
                    BlogId = blogId,
                    BlogTitle = newTitle,
                    BlogAuthor = newAuthor,
                    BlogContent = newContent
                };
                eFCoreHelper.UpdateData(updatedBlog);
            }
            else
            {
                Console.WriteLine("Invalid Blog ID.");
            }
            break;
        case "D":
            Console.WriteLine("Enter Blog ID to Delete:");
            if (int.TryParse(Console.ReadLine(), out int deleteBlogId))
            {
                var deleteBlog = new BlogDataModel
                {
                    BlogId = deleteBlogId
                };
                eFCoreHelper.DeleteData(deleteBlog);
            }
            else
            {
                Console.WriteLine("Invalid Blog ID.");
            }
            break;
        default:
            break;
    }   

    Console.WriteLine("Press Key - 'R' : To Read Data , 'C' : To Insert , 'U' : To Update , 'D' : To Delete , Others : To Exit Program");
    input = Console.ReadLine().ToUpper();
}