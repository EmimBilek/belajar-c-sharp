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
