# Delegate
## Definisi
<sup> **Keyword :** Delegate, Delegate Multicast</sup>

**Delegate** adalah tipe data yang merepresentasikan sebuah method dengan tanda tangan / nama tertentu

contoh penggunaan delegate :
```csharp
public delegate void PrintText(string Message);
```

Delegate di atas merupakan delegate yang digunakan untuk mengeprint sebuah text, dia tidak mereturn data apapun (void) dan memiliki 1 parameter string. Delegate di atas dapat merepresentasikan method di bawah:
```csharp
void PrintMessage(string text){
	Console.WriteLine(text);
}
```
nah, cara untuk menggunakan delegate nya adalah:

- cara 1:
```csharp
PrintText printdel = PrintMessage;
printdel("Amogus sus banget coooyyy");
```
- cara 2:
```csharp
PrintText printdel = new PrintText(PrintMessage);
printdel("Amogus jelekkk");
```

Poin penting menggunakan delegate:
- Tipe data delegate menggunakan 'delegate' sebagai kata kunci
```csharp
public delegate void PrintText(string Message);
```
- Delegate dapat digunakan untuk mendeklarasikan variable, parameter, dan nilai return pada sebuah method dengan nama
	tertentu
- Untuk merepresentasikan sebuah method dengan delegate, method nya harus memiliki tipe return dan parameter yang sama
	dengan delegate-nya
- **Delegate Multicast**, delegate yang bisa menjalankan lebih dari 1 method
```csharp
SomeDelegate += AnotherMethod;
```
- **Delegate Multicast** ini disarankan untuk method yang tidak mereturn sebuah nilai, namun apabila ada sebuah skenario
	yang membuat sebuah delegate yang mereturn sebuah nilai menggunakan metode multicast, maka gunakan method
	GetInvocationList() pada delegate nya (ini memungkinkan untuk mengambil nilai return pada setiap method yang
	terdaftar dalam delegate multicast) -> delegate.GetInvocationList() - _Lebih lengkapnya belajar aja sama mbahGPT_

## Kofarians & Kontrafarians
<sup> **Keyword :** Covariance, Contravariance</sup>

2 jenis konsep delegate:
- kofarians
- kontrafarians

### Kofarians 
**Delegate Kofarians** menggunakan tipe yang lebih turunan (_More Devired_) daripada yang ditetapkan pada awalnya. Anda dapat menetapkan contoh -> `IEnumerable<Derived>` ke variabel bertipe `IEnumerable<Base>`. Contoh : 
```csharp
public class Animal { }
public class Dog : Animal { }

public delegate Animal AnimalHandler();

public class Program
{
    public static Dog GetDog()
    {
        return new Dog();
    }

    public static void Main()
    {
        AnimalHandler handler = GetDog; // Kofarians: Dog adalah subtipe dari Animal
        Animal animal = handler();
    }
}
```

### Kontrafarians 
**Delegate Kontrafarians** menggunakan tipe yang lebih generik (kurang turunan) daripada yang ditetapkan pada awalnya. Anda dapat menetapkan contoh -> `Action<Base>` ke variabel bertipe `Action<Derived>`. Contoh :
```csharp
delegate void LogCatBody(Cat cat);
delegate void LogDogBody(Dog dog);

static void LogAnimalBody(Animal animal)
{
   ...
}

public static void Main()
{
       LogCatBody catBodyLog = LogAnimalBody; // Kontrafarians: Animal adalah supertipe dari Cat
       catBodyLog(new Cat());
       LogDogBody dogBodyLog = LogAnimalBody; // Kontrafarians: Animal adalah supertipe dari Dog
       dogBodyLog(new Dog());
}
```

## Func, Action, & Predicate (Generics Delegate)
<sup> **Keyword :** `Func`, `Action`, `Predicate` </sup>

### Func
**Func** merupakan generics delegate built-in system, Kode `Func` pada _metadata_ : 
```csharp
public delegate TResult Func<in T, out TResult>(T arg);
```
`Func` memiliki 1 nilai return, dan bisa memiliki 0 hingga 16 parameter (yang artinya memiliki 1 hingga 17 generik `<>`). 
> Pada kode diatas, `in` yang dimaksud adalah parameter, dan generik terakhir atau keyword `out` yang dimaksud adalah tipe data return


`Func` ini bisa digunakan sebagai pengganti method yang mereturn sebuah value dengan sintaks yang lebih ringkas
	
Contoh penggunaan Func:
```csharp
Func<decimal, decimal, decimal> gajiDenganBonus = (gajiSekarang, bonusDalamPersen) => gajiSekarang + (gajiSekarang * (bonusDalamPersen / 100));
```
> Kode di atas merupakan contoh penggunaan Func untuk menghitung total gaji setelah ditambahkan bonus (dengan menggunakan _lambda expression_)


### Action 
**Action** merupakan genereic delegate built-in system. Kode `Action` pada _metadata_ :
```csharp
public delegate void Action<in T>(T obj);
```
`Action` mirip seperti Func, tetapi tidak bisa me-return nilai. `Action` bisa memiliki 0 hingga 16 parameter. 
> Pada kode diatas, `in` yang dimaksud adalah parameter, dan bisa menampung hingga 16 parameter


`Action` ini bisa digunakan sebagai pengganti method void dengan sintaks yang lebih ringkas

Contoh penggunaan `Action` :
```csharp
Action<int, string, decimal, bool> displayEmployee = delegate (int id, string name, decimal salary, bool isManager)
{
	Console.WriteLine($"ID : {id}{Environment.NewLine}Name : {name}{Environment.NewLine} Salary : {salary}{Environment.NewLine}Position : {(isManager ? "Manager" : "Not Manager")}");
};
```
> Kode di atas merupakan contoh penggunaan `Action` untuk men-display employee (menggunakan _anonymous method_)


### Predicate 
**Predicate** merupakan generic delegate bulit-in system. Kode `Predicate` pada _metadata_ :
```csharp
public delegate bool Predicate<in T>(T obj);
```
`Predicate` memiliki nilai return boolean, dan hanya boleh memiliki 1 parameter, tidak kurang dan tidak lebih.
	
`Predicate` biasanya digunakan untuk mencari data atau seleksi data dari sebuah _list_ / _array_ atau bisa juga untuk mengecek suatu kriteria pada objek generik `T`.

Contoh penggunan `Predicate` :
```csharp
List<Employee> employeeFiltered = FilterEmployees(listemp, e => e.annualSalary > 50000);
static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate){ ... }
```
> Kode di atas merupakan contoh penggunaan `Predicate` untuk mencari employee yang gajinya di atas 50000

## Extension Method
**Extension Method** merupakan method yang dibuat sendiri oleh user/developer. Ini sangat berguna untuk meningkatkan mobilitas pada saat ngoding

Cara membuat **Extension method** :
- Di dalam kelas `public static` apapun, buat lah sebuah method `public static` yang ingin kalian buat
- Method yang dibuat harus memiliki parameter dengan tambahan keyword `this`. Contoh :
```csharp
public static string ReverseText(this string text){ ... }
```
- Kemudian method di atas akan bisa digunakan pada variabel dengan tipe data `string` dengan menambahkan titik setelah nama variable-nya :
```csharp
string originalText = "awikwok";
string reversedText = originalText.ReverseText();
```
- Parameter berikutnya pada method extension (setelah param dengan keyword 'this') akan menjadi param argumen method extension, contoh :
```csharp
// variable textToCompare dibawah akan menjadi argumen pertama pada saat method di panggil
public static bool Compare(this string text, string textToCompare){ ... } 
```

## RINGKASAN
- Delegasi adalah tipe referensi dalam C# yang mereferensikan metode yang berisi daftar parameter tertentu dan return.
- Konsep yang disebut 'varians', definisi delegasi tidak harus sama persis dengan tipe parameter atau tipe kembalian dari metode yang dienkapsulasi. Contravariance berarti delegasi misalnya. dapat mereferensikan metode di mana parameter tertentu dalam definisi delegasi lebih diturunkan daripada bagian penghitung parameter yang terdapat dalam metode yang dienkapsulasi. Kovarian berarti bahwa tipe pengembalian dalam definisi delegasi dapat diturunkan lebih sedikit dibandingkan tipe pengembalian dari metode yang dienkapsulasinya.
- Tiga delegasi generik bawaan yaitu Func, Action, dan Predicate. Tiga delegasi umum ini dapat digunakan dalam kode untuk penggunaan kembali kode yang lebih baik, keamanan mengetik, dan untuk meningkatkan kinerja.
- Keyword baru : anonymous method, lambda expression, extension method.
- Delegasi dapat digunakan untuk merangkum metode CallBack yang dapat dipanggil setelah tugas asinkron selesai.
