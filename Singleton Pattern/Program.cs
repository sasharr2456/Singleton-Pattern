using Singleton_Pattern;

class Program
{
    static void Main()
    {
        //Lazy<Servers> server = new Lazy<Servers>();
        Servers server = Servers.Instance;
        Servers_eager server_eager = Servers_eager.Instance;
        string s1 = "http://sdaf.com";
        string s2 = "https://dsfdwfwfwfwd.com";

         Console.WriteLine(server.Add(s1));
         Console.WriteLine(server.Add(s2));
         Console.WriteLine(server.Add(s1));

        Console.WriteLine(server_eager.Add(s1));
        Console.WriteLine(server_eager.Add(s2));
        Console.WriteLine(server_eager.Add(s1));

        Parallel.Invoke(
            () => server.Add("http://fssff//af/faafaf/"),
            () => server.Add("http://dsdbdbdbdbdv.com")
        );
        Parallel.Invoke(
            () => server_eager.Add("http://dsfwfwwfwffwfwv"),
            () => server_eager.Add("http://dbddbdbdbdbdbdbd.com")
        );
        //server.print("http");
        server_eager.print("http");
    }
}