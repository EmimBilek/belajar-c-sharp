# LINQ
## Apa itu LINQ?
<sup> **Keyword :** LINQ, SQL Server database, IEnumerable, Intellisense`</sup>

__LINQ__ merupakan singkatan dari _Language Intregrated Query_. LINQ adalah nama untuk sekumpulan teknologi yang didasarkan pada integrasi kemampuan query secara langsung ke dalam bahasa C#(Secara singkat, LINQ itu digunakan untuk ber-query di C#). Secara tradisional, query terhadap data dinyatakan sebagai string sederhana tanpa pemeriksaan tipe pada waktu kompilasi atau dukungan _IntelliSense_.

Kamu bisa mengetik query LINQ di C# untuk _SQL Server database_, Dokumen XML, ADO.NET Dataset, dan segala objek koleksi yang mendukung antarmuka (interface) `IEnumerable` atau generik `IEnumerable<T>` (seperti `Array`, `List<T>`, `Dictionary<K, V>`, dan semua kelas yang mengimplementasikan `IEnumerable`). LINQ biasa digunakan untuk mengolah objek koleksi
seperti mengurutkan, menyaring/filtering, pengelompokkan, dan masih banyak lagi (selengkapnya tanya _jipiti_).

> LINQ ada di namespace `System.Linq`, jangan lupa untuk menambahkan namespace-nya jika ingin menggunakan LINQ

## Cara menggunakan LINQ
Ada dua cara untuk menggunakan LINQ, yaitu dengan menggunakan extension method (method LINQ) dan dengan menggunakan query LINQ :

- Menggunakan Method LINQ :
```csharp
var filteredEmployee = employees.Where((employee) => !employee.IsManager);
```
Method `Where()` merupakan extension method dari IEnumerable milik LINQ (tidak bisa digunakan jika namespace LINQ tidak ditambahkan). Selain dari method `Where()` ada banyak method yang bisa digunakan dari LINQ, seperti `First()`, `OrderBy()`, `GroupBy()`, dan masih banyak lagi.
> IEnumerable dan IQueryable merupakan anggota dari namespace `System.Linq`.

- Menggunakan Query LINQ :
```csharp
var selectEmpAndDept = from emp in employees
                       join dep in departments
                       on emp.DepartmentId equals dep.Id
                       select new 
                       {
                           EmployeeId = emp.Id,
                           FirstName = emp.FirstName,
                           LastName = emp.LastName,
                           DepartmentShortName = dep.ShortName,
                           DepartmentLongName = dep.LongName,
                           AnnualSalary = emp.AnnualSalary,
                           IsManager = emp.IsManager
                       };
```
Pada query `select` di atas, itu akan menghasilkan tipe baru yang anonim (Anonym type/tipe yang tidak diketahui). Dengan menggunakan `var`, maka otomatis akan mengidentifikasi tipe dari hasil query di atas.
<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/tipe anonimus.png" width="100%" />
</p>

Query LINQ di atas merupakan implementasi/menghasilkan hasil yang sama dari Query SQL di bawah ini :
```SQL
SELECT e.Id, e.FirstName, e.LastName, d.ShortName, d.LongName, e.AnnualSalary, e.IsManager FROM Employee e JOIN Department d ON e.DepartmentId = d.Id
```
Perbedaan dari Query LINQ dan umumnya Query SQL yaitu keyword `from` di LINQ terletak pada awal Query sebelum keyword `select`, sedangkan `from` pada umumnya Query SQL terletak pada akhir Query/setelah keyword `select`

> Catat bahwa Microsoft menyarankan untuk menggunakan Query jika memungkinkan dibandingkan menggunakan extension method yang relevan untuk tujuan yang sama. Ini karena keuntungan keterbacaan yang disediakan dalam sintaks query yang relevan. Tetapi ada beberapa waktu ketika kamu perlu menggunakan extension method, karena ada method yang hanya disediakan khusus dan tidak bisa diimplementasikan menggunakan Query, seperti `Average()`, `Max()`, `Min()`, DLL.

## Query LINQ


Materi yang dibahas pada segmen ini yaitu :
- Query LINQ Select, Where, Join, GroupJoin
- _Method Chaining_
- _Deferred Execution of LINQ Queries_ dan _Immediate Execution of LINQ Queries_
- keyword `yield`

### Query LINQ Select, Where, Join, GroupJoin
Penggabungan `Select` dan `Where` dengan menggunakan method syntax :
```csharp
List<Department> departments = Data.GenerateDepartments();
List<Employee> employees = Data.GenerateEmployees();

var results = employees.Select(e => new
{
    FullName = e.FirstName + " " + e.LastName,
    AnnualSalary = e.AnnualSalary
}).Where(e => e.AnnualSalary < 50000m);

foreach (var item in results)
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");

Console.ReadKey();
```
Pada kode diatas, kita telah mengimplementasikan _Method Chaining_. Apa itu _Method Chaining_? _Method Chaining_ adalah teknik pemrograman untuk memanggil beberapa metode secara berurutan pada satu objek dalam satu pernyataan (menggunakan method setelah method). Setiap metode dalam rantai (chain) mengembalikan objek, biasanya objek yang sama (dengan menggunakan keyword `this`), yang kemudian digunakan untuk memanggil metode berikutnya.
```csharp
var results = employees.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.AnnualSalary
            }).Where(e => e.AnnualSalary < 50000m);
```
```csharp
//chaining method Select()
IEnumerable<'a> IEnumerable<Employee>.Select<Employee, 'a> (Func<Employee, 'a> selector)
```
```csharp
//chaining method Where()
IEnumerable<'a> IEnumerable<'a>.Where<'a> (Func<'a, bool> predicate)
```

Menggunakan query syntax :
```csharp
List<Department> departments = Data.GenerateDepartments();
List<Employee> employees = Data.GenerateEmployees();

var results = from emp in employees
              where emp.AnnualSalary < 50000
              select new
              {
                  FullName = emp.FirstName + " " + emp.LastName,
                  AnnualSalary = emp.AnnualSalary
              };

foreach (var item in results)
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");

Console.ReadKey();
```
### Deferred Execution & Immediate Execution

__Deferred Execution__ :
Query hanya dieksekusi saat hasilnya dibutuhkan, yang memungkinkan untuk operasi yang lebih efisien dan konsisten dengan data terbaru.
```csharp
var results = from emp in employees
              where emp.AnnualSalary < 50000
              select new
              {
                  FullName = emp.FirstName + " " + emp.LastName,
                  AnnualSalary = emp.AnnualSalary
              }; // query hanya akan disimpan, tidak akan dieksekusi karena belum dibutuhkan

//Menambahkan kelas 'Employee' baru
employees.Add(new Employee{Id = 5, FirstName = "Awik", LastName = "Wok", AnnualSalary = 32000m, IsManager = true, DepartmentId = 3});

foreach (var item in results) // query akan dieksekusi di sini, karena akan dibutuhkan
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
```
kelas `Employee` baru yang ditambahkan ke dalam `employees` akan terdaftar ke dalam variable 'results'

__Immediate Execution__ :
Query dieksekusi segera, dan hasilnya disimpan dalam memori, memberikan hasil yang prediktif tetapi bisa mengonsumsi lebih banyak resource.
```csharp
var results = (from emp in employees
              where emp.AnnualSalary < 50000
              select new
              {
                  FullName = emp.FirstName + " " + emp.LastName,
                  AnnualSalary = emp.AnnualSalary
              }).ToList(); // query akan dieksekusi langsung, kemudian hasil query disimpan ke dalam variable 'results'

//Menambahkan kelas 'Employee' baru
employees.Add(new Employee{Id = 5, FirstName = "Awik", LastName = "Wok", AnnualSalary = 32000m, IsManager = true,
DepartmentId = 3}); /* kelas baru akan ditambahkan ke dalam list 'employees',
tetapi tidak terdaftar/bertambah pada variable 'results' */

foreach (var item in results) // kelas yang baru ditambahkan tidak akan ke-print disini
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}");
```
kelas `Employee` baru yang ditambahkan ke dalam `employees` tidak terdaftar ke dalam variable `results`
