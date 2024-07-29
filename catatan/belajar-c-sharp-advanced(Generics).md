# Generics
## Definisi
<sup> **Keyword :** Generic </sup>

**Generic** merupakan fitur buatan C# yang memungkinkan pengguna untuk memanggil `class` ataupun method yang dapat bekerja dengan tipe data apapun. adapun sintaks generic yaitu -> `<T>`. Contoh kode penggunaan generic :
- Penggunaan Generic pada `class`
```csharp
public class Comparison<T>
{
  public bool IsEqual(T val1, T val2)
  {
    return val1.Equals(val1, val2);
  }
}
```
- Penggunaan Generic pada method
```cshap
public class Comparison
{
  public bool IsEqual<T>(T val1, T val2)
  {
    return val1.Equals(vals2)
  }
}
```
``` csharp
class Program
{
  static void Main(string[] args)
  {
    //Use Generic Class
    Comparison<int> compare = new Comparison<int>();
    int a = 2, b = 4;
    bool isEqual = compare.IsEqual(a, b);
    Console.WriteLine($"int a and b are " {(isEqual ? "Equals" : "Not Equals")});

    //Use Generic Method
    Comparison compare2 = new Comparison();
    a = 4;
    b = 4;
    isEqual = compare2.IsEqual<int>(a, b);
    Console.WriteLine($"int a and b are " {(isEqual ? "Equals" : "Not Equals")});
  }
}
```
## Non-Generic List (ArrayList) VS Generic List (List<T>)
<sup> **Keyword :** `ArrayList`, `List<T>` </sup>

