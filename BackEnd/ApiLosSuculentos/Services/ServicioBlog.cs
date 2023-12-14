using ApiLosSuculentos.Models;

namespace ApiLosSuculentos.Services;

public static class ServicioBlog
{
    static List<Blog> Blogs { get; }
    static int nextId = 3;
    static ServicioBlog()
    {
        Blogs = new List<Blog>
        {
            new Blog { Id = 1, InformacionBlog = "Informacion Generica" }
        };
    }

    public static List<Blog> GetAll() => Blogs;

    public static Blog? Get(int id) => Blogs.FirstOrDefault(p => p.Id == id);

    public static void Add(Blog blogs)
    {
        blogs.Id = nextId++;
        Blogs.Add(blogs);
    }

    public static void Delete(int id)
    {
        var blog = Get(id);
        if(blog is null)
            return;

        Blogs.Remove(blog);
    }

    public static void Update(Blog blog)
    {
        var index = Blogs.FindIndex(u => u.Id == blog.Id);
        if(index == -1)
            return;

        Blogs[index] = blog;
    }
}