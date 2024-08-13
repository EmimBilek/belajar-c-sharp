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

Query LINQ di atas merupakan implementasi/menghasilkan hasil yang sama dari Query SQL di bawah ini :
```SQL
SELECT e.Id, e.FirstName, e.LastName, d.ShortName, d.LongName, e.AnnualSalary, e.IsManager FROM Employee e JOIN Department d ON e.DepartmentId = d.Id
```
Perbedaan dari Query LINQ dan umumnya Query SQL yaitu keyword `from` di LINQ terletak pada awal Query sebelum keyword `select`, sedangkan `from` pada umumnya Query SQL terletak pada akhir Query/setelah keyword `select`

> Catat bahwa Microsoft menyarankan untuk menggunakan Query jika memungkinkan dibandingkan menggunakan extension method yang relevan untuk tujuan yang sama. Ini karena keuntungan keterbacaan yang disediakan dalam sintaks query yang relevan. Tetapi ada beberapa waktu ketika kamu perlu menggunakan extension method, karena ada method yang hanya disediakan khusus dan tidak bisa diimplementasikan menggunakan Query, seperti `Average()`, `Max()`, `Min()`, DLL.
