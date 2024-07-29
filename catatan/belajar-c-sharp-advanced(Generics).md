# Generics
## Definisi
<sup> **Keyword :** Generic </sup>

**Generic** merupakan fitur buatan C# yang memungkinkan pengguna untuk memanggil `class` ataupun method yang dapat bekerja dengan tipe data apapun. Generic sering digunakan pada koleksi seperti array, list, dll. Adapun sintaks generic yaitu -> `<T>`. Contoh kode penggunaan generic :
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
<sup> **Keyword :** `ArrayList`, `List<T>`, explicit cast </sup>

**ArrayList** merupakan sebuah koleksi non-generik milik c# (namespace `System.Collections`), sedangkan **List**<**T**> merupakan sebuah koleksi generic milik c# (namespace `System.Collections.Generics`). Keduanya sama2 digunakan untuk menyimpan banyak objek, tetapi untuk `List<T>` menuliskan tipe data yang spesifik di dalam `<T>`, contoh : `<int>`, `<float>`, `<string>`, `<Employee>`.

Contoh pendeklarasian `ArrayList` dan `List<T>` :
```csharp
ArrayList listProfit = new ArrayList();
```
```csharp
List<int> listProfit = new List<int>();
```

> *Microsoft* tidak menyarankan developer untuk menggunakan `ArrayList` pada pengembangan kodenya, pada dokumen dibawah akan menjelaskan mengapa ArrayList tidak disarankan untuk digunakan dan beralih untuk menggunakan generic list `List<T>`

### ArrayList
Pada contoh kode di bawah, kita akan menggunakan ArrayList sebagai koleksi yang akan kita gunakan. Kode simple di bawah ini, kita akan mengambil satu objek di dalam ArrayList kemudian di-print, pertama-tama kita membuat sebuah kelas bernama `Salaries` :
```csharp
class Salaries
{
  ArrayList _salaryList = new ArrayList();

  public Salaries()
  {
    _salaryList.Add(6000.03);
    _salaryList.Add(4230.80);
    _salaryList.Add(8510.43);
  }

  public ArrayList GetSalaryList()
  {
    return _salaryList;
  }
}
```
Kemudian kita akan menggunakan method main untuk memanggil kelas `Salaries` dan mengambil nilai ArrayList menggunakan method `GetSalaryList` :
```csharp
class Program
{
  static void Main(string[] args)
  {
    Salaries salaries = new Salaries();

    ArrayList salaryList = salaries.GetSalaryList();

    float salary = salaryList[1];

    Console.WriteLine($"Gaji : {salary}");
  }
}
```
Jika kamu mencoba untuk menyalin kode di atas, itu masih mengandung error pada `float salary = salaryList[1];`.

Error terjadi karena kamu mencoba mengambil nilai objek ke dalam tipe data float. Untuk mencegah terjadinya hal itu, kita harus menggunakan **explicit cast** (Konversi eksplisit menggunakan operator cast -> `(T) var`).
```csharp
float salary = (float) salaryList[1];
```
> Explicit cast (konversi eksplisit) di C# adalah proses konversi tipe data yang dilakukan secara eksplisit oleh programmer menggunakan operator cast. Ini digunakan ketika Anda ingin mengubah satu tipe data menjadi tipe data lain yang tidak bisa dilakukan secara otomatis oleh compiler C#. ~ Selengkapnya tanya jipiti
