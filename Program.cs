using LibraryApp;

internal class Program
{
    private static void Main(string[] args)
    {
      Library library = new Library(Helper.GetAvailableBooks());

      while (true)
      {
        Console.WriteLine("Library Menu:");
        Console.WriteLine("1. View All Books");
        Console.WriteLine("2. Add a Book");
        Console.WriteLine("3. Check Out a Book");
        Console.WriteLine("4. Return a Book");
        Console.WriteLine("5. Exit");
        string choice = GetResponse("Enter your choice: ");

        Console.WriteLine();
        switch (choice)
        {
          case "1":
            ViewBooks(library);
            break;
          case "2":
            AddBook(library);
            break;
          case "3":
            CheckOutBook(library);
            break;
          case "4":
            ReturnBook(library);
            break;
          case "5":
            Console.WriteLine("Goodbye.");
            return;
          default:
            Console.WriteLine("Invalid choice. Please try again.\n");
            break;
        }
      }
    }

    static string GetResponse (string request) 
    {
      string? response = null;

      while (string.IsNullOrWhiteSpace(response))
      {
        Console.Write(request);
        response = Console.ReadLine();
      }

      return response;
    }

    static void ViewBooks(Library library)
    {
       library.ListBooks();
    }

    static void AddBook(Library library)
    {
      string title = GetResponse("Enter title: ");
      string author = GetResponse("Enter author: ");

      bool isValid = false;
      int year = 0;

      while (!isValid) {
        isValid = int.TryParse(GetResponse("Enter year: "), out year);
      }

      Book book = new Book(title, author, year);
      try 
      {
        library.AddBook(book);
        Console.WriteLine("\nBook added successfully!\n");
      }
      catch (Exception e)
      {
        Console.WriteLine($"\n{e.Message}\n");
      } 
    }

    static void CheckOutBook(Library library)
    {
        string title = GetResponse("Enter title to check out: ");
        try 
        {
          library.CheckOutBook(title);
          Console.WriteLine($"\n{title} was successfully checked out.\n");
        }
        catch (NullReferenceException e)
        {
          Console.WriteLine($"\nCheck out failed: {e.Message}\n");
        }
        catch (Exception e)
        {
          Console.WriteLine($"\nCheck out failed: {e.Message}\n");
        }
    }

    static void ReturnBook(Library library)
    {
        string title = GetResponse("Enter title to return: ");

        try 
        {
          library.ReturnBook(title);
          Console.WriteLine($"\n{title} was returned successfully!\n");
        }
        catch (NullReferenceException e)
        {
          Console.WriteLine($"\nReturn failed: {e.Message}\n");
        }
        catch (Exception e)
        {
          Console.WriteLine($"\nReturn failed: {e.Message}\n");
        }
    }
}