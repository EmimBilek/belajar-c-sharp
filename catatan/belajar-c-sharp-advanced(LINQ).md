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

> Catat bahwa Microsoft menyarankan untuk menggunakan Query jika memungkinkan dibandingkan menggunakan extension method yang relevan untuk tujuan yang sama. Ini karena sintaks query yang lebih mudah dibaca. Tetapi ada beberapa waktu ketika kamu perlu menggunakan extension method, karena ada method yang hanya disediakan khusus dan tidak bisa diimplementasikan menggunakan Query, seperti `Average()`, `Max()`, `Min()`, DLL.

## Query LINQ


Materi yang dibahas pada segmen ini yaitu :
- Query LINQ Select, Where, Join, GroupJoin
- _Method Chaining_
- _Deferred Execution of LINQ Queries_ dan _Immediate Execution of LINQ Queries_
- keyword `yield`

### Query LINQ Select, Where, Join, GroupJoin - Method Chaining
#### Penggabungan `Select` dan `Where` dengan menggunakan method syntax :
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
#### Implementasi sintaks menggunakan method join dan groupjoin
__Join (sintaks method):__
```csharp
var results = departmentList.Join(employeeList,
        department => department.Id,
        employee => employee.DepartmentId,
        (department, employee) => new
        {
            FullName = employee.FirstName + " " + employee.LastName,
            AnnualSalary = employee.AnnualSalary,
            DepartmentName = department.LongName
        }
    );

foreach (var item in results)
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
```

__Join (sintaks query) :__
```csharp
var results = from departments in departmentList
              join employees in employeeList on
              departments.Id equals employees.DepartmentId
              where employees.AnnualSalary > 50000
              select new
              {
                  FullName = employees.FirstName + " " + employees.LastName,
                  AnnualSalary = employees.AnnualSalary,
                  DepartmentName = departments.LongName
              };

foreach (var item in results)
    Console.WriteLine($"{item.FullName,-20} {item.AnnualSalary,10}\t{item.DepartmentName}");
```

__Group Join (sintaks method) :__
```csharp
var results = departmentList.GroupJoin(employeeList,
        dept => dept.Id,
        emp => emp.DepartmentId,
        (depart, employeesGroup) => new
        {
            Employees = employeesGroup,
            DepartmentName = depart.LongName
        });

foreach (var item in results)
{
    Console.WriteLine($" Department Name : {item.DepartmentName}");
    foreach (var emp in item.Employees)
    {
        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
    }
}
```
__Group Join (sintaks query) :__
```csharp
var results = from dep in departmentList
              join emp in employeeList
              on dep.Id equals emp.DepartmentId
              into employeesGroup
              select new
              {
                  Employees = employeesGroup,
                  DepartmentName = dep.LongName
              };

foreach (var item in results)
{
    Console.WriteLine($" Department Name : {item.DepartmentName}");
    foreach (var emp in item.Employees)
    {
        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
    }
}
```
Dilihat dari sintaks join di atas, fungsi dari sintaks join yaitu memungkinkan kita untuk menggabungkan dua objek koleksi berdasarkan suatu kunci (dalam konteks ini, yang menjadi kuncinya adalah id departemen). Method join hanya mendukung inner join, jadi hanya bisa mendapatkan data yang memiliki relasi dari kedua objek koleksi. Sedangkan method group join mendukung left join/right join, sehingga memungkinkan untuk memanggil data yang terelasi dan juga tidak terelasi dengan objek koleksi lain.

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

### Keyword `yield`
Keyword `yield` digunakan untuk mengembalikan nilai satu per satu pada method yang membutuhkan return banyak nilai (koleksi seperti array, list, dll). Biasanya keyword `yield` ini berada di dalam perulangan.

Contoh penggunaan yield :
```csharp
public List<Employee> GetFilteredEmployee(List<Employee> employees, Predicate<Employee> predicate)
{
  foreach (Employee employee in employees)
  {
    if (predicate(employee))
      yield return employee;
  }
}
```

## LINQ Operators
### Sorting
- __Sintaks method : `OrderBy()`, `OrderByDescending()`, `ThenBy()`, `ThenByDescending()`__

__OrderBy()__ digunakan untuk mengurutkan sebuah koleksi dari kecil ke besar, sedangkan __OrderByDescending()__ adalah kebalikannya. Lalu __ThenBy()__ digunakan untuk ketentuan pengurutan yang selanjutnya setelah OrderBy atau OrderBy descending, sedangkan __ThenByDescending()__ adalah kebalikan dari ThenBy. Contoh penggunaan :
```csharp
var results = departmentList.Join(employeeList,
        department => department.Id,
        employee => employee.DepartmentId,
        (department, employee) => new
        {
            FullName = employee.FirstName + " " + employee.LastName,
            AnnualSalary = employee.AnnualSalary,
            DepartmentName = department.LongName
        }
    ).OrderBy(o => o.DepartmentName).ThenByDescending(o => o.AnnualSalary);
```

- __Sintaks query__
  
Penggunaan sorting dengan menggunakan Sintaks query lebih ringkas dibanding dengan sintaks method. Cara sorting menggunakan sintaks query hanya perlu menggunakan operator `orderby` di akhir query sebelum `select`. Jika ingin mendapatkan hasil yang sama dengan contoh sorting diatas dengan menggunakan `ThenBy()`, maka hanya perlu menambahkan koma setelah ketentuan sorting pertama :
```csharp
var results = from departments in departmentList
              join employees in employeeList on
              departments.Id equals employees.DepartmentId
              where employees.AnnualSalary > 50000
              orderby employees.FirstName + " " + employees.LastName, employees.AnnualSalary descending
              select new
              {
                  FullName = employees.FirstName + " " + employees.LastName,
                  AnnualSalary = employees.AnnualSalary,
                  DepartmentName = departments.LongName
              };
```
### Grouping
Digunakan untuk mengelompokkan data berdasarkan kunci tertentu (pada konteks kali ini, kuncinya adalah departemen id)
- __Sintaks method : `GroupBy(), ToLookup()`__
```csharp
var results = employeeList.GroupBy(emp => emp.DepartmentId);
var results2 = employeeList.ToLookup(emp => emp.DepartmentId);

foreach (var result in results)
{
    Console.WriteLine("Department Id : " + result.Key);
    foreach (var emp in result)
    {
        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
    }
}

foreach (var result in results2)
{
    Console.WriteLine("Department Id : " + result.Key);
    foreach (var emp in result)
    {
        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
    }
}
```
Perbedaan antara method `GroupBy()` dengan `ToLookup()` adalah __GroupBy()__ dijalankan secara _deferred execution_, sedangkan __ToLookup()__ dijalankan secara _immediate execution_
- __Sintaks query (operator `group` & `by`)__
```csharp
var results = from emp in employeeList
              group emp by emp.DepartmentId;

foreach(var result in results)
{
    Console.WriteLine("Department Id : " + result.Key);
    foreach(var emp in result)
    {
        Console.WriteLine($"\t{emp.FirstName + " " + emp.LastName}");
    }
}
```
> Menggunakan LINQ dengan cara sintaks query harus diakhiri dengan operator `select` atau operator `group`. Pada contoh di atas, dapat dilihat bahwa sintaks query tidak diakhiri dengan operator `select`, melainkan operator `group`.

### Quantifier (Penghitung)
Digunakan untuk mengecek apakah suatu koleksi memenuhi suatu kriteria

- __Sintaks method : `All()`, `Any()`, `Contains()`__
```csharp
var salary = 50000m;
bool result = employeeList.All(emp => emp.AnnualSalary > salary);
bool result2 = employeeList.Any(emp => emp.AnnualSalary > salary);

if (result)
    Console.WriteLine($"All employee has salary more than " + salary);
else
    Console.WriteLine($"Not all employee has salary more than " + salary);

if (result2)
    Console.WriteLine($"There is employee that has salary more than " + salary);
else
    Console.WriteLine($"Not any employee has salary more than " + salary);
```
- `All()` : mengecek apakah semua elemen memenuhi kriteria dari suatu koleksi (return bool)
- `Any()` : mengecek apakah ada elemen yang memenuhi kriteria dari suatu koleksi (return bool)

__Contains()__ : Ada dua cara untuk menggunakan method ini jika digunakan pada tipe yang didefinisikan user (user-defined type)
1. meng-override-kan method `Equals()` pada tipe nya :
```csharp
class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }
        Employee emp = (Employee)obj;
        return (this.FirstName == emp.FirstName) && (this.LastName == emp.LastName);
    }
}
```
```csharp
var checkEmp = new Employee { Id = 1, FirstName = "Momog", LastName = "Gus", AnnualSalary = 45000.2m, IsManager = true, DepartmentId = 2 };
bool result = employeeList.Contains(checkEmp);

if (result)
    Console.WriteLine($"There is an employee with name  : {checkEmp.FirstName} {checkEmp.LastName}");
else
    Console.WriteLine($"There is not enployee with name : {checkEmp.FirstName} {checkEmp.LastName}");
```
2. Mengimplementasikan interface generik `IEqualityComparer<T>`, kemudian override method `Equals()` dan `GetHashCode()` :
```csharp
public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee x, Employee y)
    {
        return (x.FirstName == y.FirstName) && (x.LastName == y.LastName);
    }

    public int GetHashCode(Employee obj)
    {
        return obj.Id.GetHashCode();
    }
}
```
```csharp
var checkEmp = new Employee { Id = 1, FirstName = "Momog", LastName = "Gus", AnnualSalary = 45000.2m, IsManager = true, DepartmentId = 2 };
bool result = employeeList.Contains(checkEmp, new EmployeeComparer());

if (result)
    Console.WriteLine($"There is an employee with name  : {checkEmp.FirstName} {checkEmp.LastName}");
else
    Console.WriteLine($"There is not enployee with name : {checkEmp.FirstName} {checkEmp.LastName}");
```
### Filter (Penyaring)
Digunakan untuk menyaring sebuah koleksi. Berbeda dengan operasi quantifier, operasi filter tidak mengembalikan nilai boolean, tetapi mengembalikan nilai itu sendiri (nilai yang difilter).

- __Sintaks Gabungan : `OnType()`__
```csharp
ArrayList arr = new ArrayList();

arr.Add(2000);
arr.Add("Kucing");
arr.Add(new Employee { Id = 5, AnnualSalary = 3000, DepartmentId = 2, FirstName = "iteng", LastName = "hitam", IsManager = false });
arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });
arr.Add(800);
arr.Add("ase omagat asi deway yu sain");
arr.Add(new Employee { Id = 7, AnnualSalary = 9000, DepartmentId = 2, FirstName = "jarwo", LastName = "dontol", IsManager = true });
arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });
arr.Add(7800);
arr.Add("selaluuu, selagi jang ganggu");
arr.Add(new Employee { Id = 6, AnnualSalary = 8230, DepartmentId = 2, FirstName = "harung", LastName = "hideung", IsManager = true });
arr.Add(new Department { Id=2, LongName="kominfo", ShortName="kmnf" });

var results = from ar in arr.OfType<string>()
              select ar;

foreach(var result in results)
{
    Console.WriteLine(result);
}
```
```csharp
var results1 = from ar in arr.OfType<int>()
               select ar;
var results2 = from ar in arr.OfType<Employee>()
               select ar;
var results3 = from ar in arr.OfType<Department>()
               select ar;
```
Dapat diketahui dari kode diatas, fungsi dari operasi `OfType()` ialah untuk mengambil data dengan tipe data tertentu pada koleksi yang memiliki banyak tipe seperti arraylist yang menyimpan data berupa objek.

- __Sintaks Method dan Query : `Where()`, `where`__
```csharp
var results = employeeList.Where(e => e.IsManager);

var results2 = from emp in employeeList
              where emp.IsManager
              select emp;

foreach (var result in results2)
    Console.WriteLine($"{result.Id} : {result.FirstName} {result.LastName} {(result.IsManager ? "is Manager" : "is not Manager")}");
```

### Elemen (Element Operator) :
- __`ElementAt(int index)`__ -> Mengambil data pada element tertentu pada koleksi, jika ElementAt melebihi index koleksi maka akan melemparkan eksepsi `System.IndexOutOfRangeException`.
- __`ElementAtOrDefault(int index)`__ -> Mengambil data pada element tertentu pada koleksi, jika ElementAt melebihi index koleksi maka akan me-return nilai null
- __`First()` +1 overload__ -> Mengambil data pertama pada koleksi. Bila tidak ada data yang diambil (tidak ada data pertama/tidak ada data sama sekali) maka akan melemparkan eksepsi `System.InvalidOperationException`.
- __`FirstOrDefault()` +1 overload__ -> Mengambil data pertama pada koleksi. Bila tidak ada data yang didapat, maka akan mengembalikan nilai null.
- __`Last()` +1 overload__ -> Mengambil data terakhir pada koleksi. Bila tidak ada daya yang didapat, maka akan melemparkan eksepsi `System.InvalidOperationException`.
- __`LastOrDefault()` +1 overload__ -> Mengambil data terakhir pada koleksi. Bila tidak ada data yang didapat, maka akan mengembalikan nilai null.
- __`Single()` +1 overload__ -> Mengambil satu data dari suatu koleksi apabila di dalam koleksi hanya terdapat satu data. Selain itu, maka akan melemparkan eksepsi `System.InvalidOperationException`.
- __`SingleOrDefault()` +1 overload__ -> Mengambil satu data dari suatu koleksi apabila di dalam koleksi hanya terdapat satu data. Jika, tidak ada data di dalam koleksi, maka akan mengembalikan nilai null. Jika ada lebih dari satu data yang ada di dalam koleksi, maka akan melemparkan eksepsi `System.InvalidOperationException`.

### Equality (Operasi persamaan) :
- __`SequenceEqual()`__ -> Digunakan untuk menyamakan sebuah koleksi. Bila urutan serta isi datanya sama maka akan mengembalikan nilai true, selain itu maka false.
Apabila menggunakan SequenceEqual untuk membandingkan tipe yang didefinisikan user (user-defined type), maka method `Equals()` harus di override di dalam tipe nya atau menggunakan kelas yang mengimplementasikan `IEqualityComparer<T>`.
```csharp
var list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
var list2 = new List<int> { 1, 2, 3, 4, 5, 6 };

bool result = list1.SequenceEqual(list2); //result = true
```
```csharp
var list1 = new List<int> { 1, 2, 3, 4, 5, 6 };
var list2 = new List<int> { 1, 2, 3, 4, 6, 5 };

bool result = list1.SequenceEqual(list2); //result = false
```
User-defined type 1 :
```csharp
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
  
    public override bool Equals(object obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
            return false;
  
        Employee emp = (Employee)obj;
  
        return (this.FirstName.ToLower() == emp.FirstName.ToLower()) && (this.LastName.ToLower() == emp.LastName.ToLower());
    }
}
```
```csharp
List<Employee> employeeList = Data.GenerateEmployees();
List<Employee> employeeList2 = Data.GenerateEmployees();

bool result = employeeList.SequenceEqual(employeeList2);
```
User-defined type 2 :
```csharp
public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal AnnualSalary { get; set; }
    public bool IsManager { get; set; }
    public int DepartmentId { get; set; }
}
```
```csharp
public class EmployeeComparer : IEqualityComparer<Employee>
{
    public bool Equals(Employee x, Employee y)
    {
        return (x.FirstName.ToLower() == y.FirstName.ToLower()) && (x.LastName.ToLower() == y.LastName.ToLower());
    }

    public int GetHashCode(Employee obj)
    {
        return obj.Id.GetHashCode();
    }
}
```
```csharp
List<Employee> employeeList = Data.GenerateEmployees();
List<Employee> employeeList2 = Data.GenerateEmployees();

bool result = employeeList.SequenceEqual(employeeList2, new EmployeeComparer());
```
