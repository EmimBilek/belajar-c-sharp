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
<sup> **Keyword :** `ArrayList`, `List<T>`, explicit cast, implicit cast, boxing, unboxing </sup>

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
Penggunaan ArrayList di bawah hanya sebagai demonstrasi mengapa ArrayList tidak disarankan untuk penggunaan koleksi di c#.

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
Kemudian kita akan menggunakan method main untuk memanggil kelas `Salaries` dan mengambil nilai ArrayList menggunakan method `GetSalaryList()` :
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

Error terjadi karena kamu mencoba mengambil nilai objek ke dalam tipe data float (tidak bisa melakukan _implicit cast_ dari `object` ke `float`). Untuk mencegah terjadinya hal itu, kita harus menggunakan _explicit cast_ (Konversi eksplisit menggunakan operator cast -> `(T) obj`).
```csharp
float salary = (float) salaryList[1];
```
> Explicit cast (konversi eksplisit) di C# adalah proses konversi tipe data yang dilakukan secara eksplisit oleh programmer menggunakan operator cast. Ini digunakan ketika Anda ingin mengubah satu tipe data menjadi tipe data lain yang tidak bisa dilakukan secara otomatis oleh compiler C#. ~ Selengkapnya tanya jipiti

Oke, ketika kamu sudah melakukan _explicit cast_ kemudian akan menjalankan kodenya, error baru akan muncul pada saat _runtime code_ (Exception : `System.InvalidCastException`). Itu terjadi karena pada saat menambahkan value ke dalam ArrayList, kamu menambahkan tipe data `double` bukan `float` :
```csharp
public Salaries()
{
  _salaryList.Add(6000.03); //secara default, ini adalah tipe data double
  _salaryList.Add(4230.80); //secara default, ini adalah tipe data double
  _salaryList.Add(8510.43); //secara default, ini adalah tipe data double
}
```
Kita perlu merubahnya merubahnya menjadi literal `float` :
```csharp
public Salaries()
{
  _salaryList.Add(6000.03f); //f sebagai indikasi bahwa tipe ini adalah literal float
  _salaryList.Add(4230.80f); 
  _salaryList.Add(8510.43f); 
}
```
Kode di atas sudah bisa dieksekusi dengan aman.

> Mengapa ini bisa terjadi? Secara otomatis, nilai yang disimpan di dalam ArrayList akan menjadi _root data type_ (tipe data akar) yaitu `object` (semua tipe data yang ada di .NET mewarisi dari `System.Object`). Ketika sebuah variable disimpan di dalam ArrayList, tipe data variable akan dibungkus oleh tipe `object` dan disimpan dalam memori _Heap_. ini yang dikenal sebagai _boxing_. _Boxing_ merupakan proses konversi tipe nilai menjadi tipe objek

### Ringkasan _Boxing_ dan _Unboxing_
Object bisa menyimpan tipe nilai dan tipe referensi. Namun, ketika menyimpan tipe nilai dalam object, proses ini disebut boxing, dan ketika mengambil kembali tipe nilai dari object, proses ini disebut unboxing. Contoh:

```csharp
int number = 10;
object boxedNumber = number; // Boxing
int unboxedNumber = (int)boxedNumber; // Unboxing
```
### Generic List (`List<T>`)
Keuntungan dari menggunakan Generic List `List<T>` dibanding `ArrayList` adalah kita tidak perlu melakukan _explicit cast_/_unboxing_ ketika mengambil objek di dalam `List<T>`, karena tipe data sudah ditentukan di dalam `<T>` pada saat deklarasi/instansiasi `List<T>`
> `ArrayList` dan `List<T>`, keduanya tidak perlu mendefinisikan ukuran koleksi nya ketika dideklarasikan, tidak seperti array yang harus ditentukan ukurannya.

`T` pada `List<T>` berfungsi sebagai pengganti untuk tipe data. Jadi, Developer bisa memberikan tipe data sebagai argumen pada `List<T>` untuk mendeklarasikan bahwa hanya tipe data yang ditentukan dalam `T` yang bisa disimpan di dalam list yang bersangkutan.

Pada kode sebelumnya, ubah `ArrayList` menjadi 'List<float>' :
```csharp
class Salaries
{
    List<float> _salaryList = new List<float>();
    public Salaries()
    {
        _salaryList.Add(6000.03f);
        _salaryList.Add(4230.80f);
        _salaryList.Add(8510.43f);
    }

    public List<float> GetSalaryList()
    {
        return _salaryList;
    }
}
```
Pada method main, kita tidak membutuhkan _explicit cast_ lagi untuk mengambil objek yang ada di dalam list :
```csharp
class Program
{
    static void Main(string[] args)
    {
        Salaries salaries = new Salaries();

        List<float> salaryList = salaries.GetSalaryList();
            
        float salary = salaryList[1];

        Console.WriteLine($"Gaji : {salary}");

        Console.ReadKey();
    }
}
```
### Keuntungan `List<T>` dibanding dengan `ArrayList`
__1. Type Safety (Keamanan Tipe)__
- List<T> adalah generik, yang berarti Anda menentukan tipe elemen yang akan disimpan saat membuat daftar. Ini memberikan keamanan tipe yang lebih baik karena hanya tipe data tertentu yang diizinkan.
- ArrayList tidak generik dan menyimpan elemen sebagai object, yang berarti tipe data apa pun bisa dimasukkan, menyebabkan potensi kesalahan runtime jika jenis yang salah dimasukkan.

__2. Performansi__
- Karena List<T> adalah tipe kuat (strongly-typed), tidak ada biaya boxing dan unboxing untuk tipe nilai (value types). Dengan ArrayList, tipe nilai perlu diubah menjadi objek (boxing) ketika dimasukkan, dan dikembalikan ke tipe aslinya (unboxing) saat diambil, yang bisa mengurangi performansi.

__3. Ketersediaan Metode LINQ__
- List<T> mendukung LINQ (Language Integrated Query), memungkinkan Anda untuk menulis kueri kaya terhadap koleksi menggunakan sintaks LINQ.

__4. Ketersediaan Koleksi Metode__
- List<T> menyediakan metode generik seperti Find, FindAll, FindIndex, FindLastIndex, dan banyak lagi, yang tidak tersedia dalam ArrayList.

__5. Keamanan dan Pemeliharaan Kode__
- Karena List<T> adalah tipe kuat, kesalahan tipe dapat dideteksi pada waktu kompilasi, bukan waktu runtime, membuat kode lebih aman dan mudah dikelola.

__6. Casting Tidak Diperlukan__
- Dengan List<T>, Anda tidak perlu melakukan casting elemen saat mengambilnya dari daftar, mengurangi kemungkinan kesalahan runtime.

## IComparable
<sup> **Keyword :** `IComparable`, `IComparable<T>` </sup>

__Apa itu IComparable?__ IComparable merupakan interface built-in system yang digunakan untuk membandingkan sebuah object dengan object lainnya. Bagaimana perbandingan dengan `IComparable` dapat bekerja?

Di dalam interface `IComparable` terdapat 1 method bernama `CompareTo()`. method `CompareTo` mereturn nilai `int` dan memiliki 1 parameter dengan tipe data `object`

Kode pada metadata :
```csharp
public interface IComparable
{
    int CompareTo(object obj);
}
```

### Cara kerja method `CompareTo()` pada `IComparable`

Misalkan kita mempunyai dua object pada kode seperti dibawah ini :
```csharp
object a = 50;
object b = 80;

string strA = "amoguss";
string strB = "kocheng";
```
- Ketika objek yang dibandingkan lebih kecil daripada pembandingnya maka hasil return dari method `CompareTo()` adalah -1 :
```csharp
int compareResult = ((IComparable)a).CompareTo(b); // hasil : compareResult = -1
int compareResultString = ((IComparable)strA).CompareTo(strB); // hasil : compareResultString = -1
```
> `IComparable` juga mendukung perbandingan antar string

- Ketika objek yang dibandingkan lebih besar daripada pembandingnya maka hasil return dari method `CompareTo()` adalah 1 :
```csharp
object a = 100;
object b = 80;

string strA = "wawan";
string strB = "kocheng";
```
```csharp
int compareResult = ((IComparable)a).CompareTo(b); // hasil : compareResult = 1
int compareResultString = ((IComparable)strA).CompareTo(strB); // hasil : compareResult = 1
```

- Ketika objek yang dibandingkan sama dengan pembandingnya maka hasil return dari method `CompareTo()` adalah 0 :
```csharp
object a = 100;
object b = 100;

string strA = "wawan";
string strB = "wawan";
```
```csharp
int compareResult = ((IComparable)a).CompareTo(b); // hasil : compareResult = 0
int compareResultString = ((IComparable)strA).CompareTo(strB); // hasil : compareResult = 0
```
- Tetapi ketika objek yang dibandingkan berbeda tipe dengan pembandingnya maka akan menghasilkan error `System.ArgumentException` pada saat runtime :
```csharp
object a = 100;

string strA = "wawan";
```
```csharp
int compareResult = ((IComparable)a).CompareTo(strA); // error System.ArgumentException -> "Object must be type Int32"
```
`IComparable` juga bisa menampung generic untuk membuat method perbandingan pada tipe yang spesifik -> `IComparable<T>`.

Kode `IComparable<T>` pada metadata :
```csharp
public interface IComparable<in T>
{
    int CompareTo(T other);
}
```
ketika `IComparable<T>` diimplementasikan pada suatu kelas, maka implementasi method `CompareTo()` harus memiliki parameter yang diisi di dalam generic. Contoh :
```csharp
public class Employee : IComparable<Employee>
{
    public int id { get; set; }
    public string name { get; set; }

    public int CompareTo(Employee other)
    {
        return this.name.CompareTo(other.name);
    }
}
```
## Constraint
__Apa itu Constraint?__ Constraint adalah batasan untuk kelas generik. Constraint menggunakan keyword `where` pada kelasnya. Constraint digunakan untuk menentukan tipe apa yang harus ditetapkan pada generik pada suatu kelas. Bingung? coba lihat kode di bawah :
```csharp
public class SortArray<T> where T : IComparable<T> {...}
```
Dari contoh kode di atas, __ketika instansiasi kelas `SortArray` generik yang dioper pada kelas `SortArray` harus bertipe `IComparable<T>` atau kelas apapun yang mewarisi/mengimplementasi generik interface `IComparable<T>`__. seperti kelas di bawah :
```csharp
public class Employee : IComparable<Employee> {...}
```
```csharp
SortArray<Employee> sort = new SortArray<Employee>();
```
### Constraint Ganda
Constraint ganda memungkinkan developer untuk membatasi kelas generik pada banyak tipe tertentu. Cara menggunakan __Constraint Ganda__ yaitu dengan menambahkan tanda koma `,` setelah constraint pertama :
```csharp
public class SortArray<T> where T : IComparable<T>, Employee {...}
```
Dengan begitu, untuk inisialisasi kelas `SortArray` diperlukan kelas yang mewarisi `IComparable<T>` dan `Employee` sebagai argumen generiknya, seperti kode di bawah ini :
```csharp
public class Consultant : IComparable<Consultant>, Employee {...}
```
```csharp
SortArray<Consultant> sort = new SortArray<Consultant>();
```
### Constraint Generic Ganda
Berbeda dari Constraint ganda, __Constraint Generic Ganda__ memungkinkan developer untuk menentukan lebih dari 1 generik untuk dibatasi. Cara menggunakan __Constraint Generic Ganda__ yaitu dengan menambahkan keyword `where` baru setelah constraint pertama :
```csharp
public class SortArray<T, U> where U : T, new() where T : IComparable<Consultant> {...}
```
Dengan begitu, untuk inisialisasi kelas `SortArray` diperlukan kelas `IComparable<Consultant>`/turunannya sebagai argumen generik `T` dan kelas `T`/turunannya dan memiliki _constructor_ tanpa parameter sebagai argumen generik `U`, seperti kode di bawah ini :
```csharp
public class Boss : IComparable<Consultant> {...}
public class Employee {...}
```
```csharp
SortArray<Boss, Employee> sort = new SortArray<Boss, Employee>();
```
> constraint `new()` digunakan pada generik bahwa tipe generik harus memiliki constructor tanpa parameter, dan constraint `new()` harus ditetapkan pada akhir constraint -> `class Vehicle<T> where T : ComponentClass, EmployeeClass, new()`
