# belajar-c-sharp
## Named Arguments
```csharp
static void Main(string[] args)
{
  int res = Area(w: 5, h: 8);
  Console.WriteLine(res);
}
  static int Area(int h, int w)
{
  return h * w;
}
```
## Default Value Param
```csharp
static int Area(int h = 2, int w = 2)
{
  return h * w;
}
```
## Passing by Reference
Lewat referensi menyalin alamat memori argumen ke dalam parameter formal. Di dalam metode ini, alamat digunakan untuk mengakses argumen sebenarnya yang digunakan dalam panggilan. Artinya perubahan yang dilakukan pada parameter mempengaruhi argumen.
Untuk meneruskan nilai dengan referensi, kata kunci ref digunakan dalam panggilan dan definisi metode :
```csharp
static void Sqr(ref int x)
{
  x = x * x;
}
static void Main()
{
  int a = 3;
  Sqr(ref a);
  Console.WriteLine(a); // Outputs 9
}
```
> Note: jika parameter menggunakan `ref`, maka `ref` diperlukan ketika pemanggilan method.

Kode error:
```csharp
static void Sqr(ref int x)
{
  x = x * x;
}
static void Main()
{
  int a = 3;
  Sqr(a); //error karena tidak menggunakan ref
  Console.WriteLine(a); // Outputs 9
}
```
## Passing by Output
Parameter output mirip dengan parameter reference, hanya saja parameter tersebut mentransfer data keluar dari metode, bukan menerima data masuk. Parameter tersebut didefinisikan menggunakan kata kunci 'out'
Variabel yang disediakan untuk parameter output tidak perlu diinisialisasi karena nilai tersebut tidak akan digunakan. Parameter keluaran sangat berguna ketika Anda perlu mengembalikan beberapa nilai dari suatu metode. Contoh:
```csharp
static void GetValues(out int x, out int y)
{
  x = 5;
  y = 42;
}
static void Main(string[] args)
{
  int a, b;
  GetValues(out a, out b);
  //Now a equals 5, b equals 42
}
```
> Note: berbeda dengan parameter reference, parameter output mendapatkan nilai dari method

## Verbatim Strings
The verbatim string allows special characters and linebreaks in strings. It can be created by prefixing @ symbol before double quotes. examples :
```csharp
Console.WriteLine(@"Hey! I'm a verbatim string.");
```
## String Interpolation
Is it possible to use a variable inside a string? It is, using string interpolation!

Let's have a look at the following code 👇:
```csharp
string city = "London";
Console.WriteLine($"{city} is the capital of the United Kingdom.");
```

To create an interpolated string you need to prefix the $ symbol before the double quotes. To use a variable inside the string, you just need to enclose it in curly brackets: {variable name}.

## Overloading method
Method dengan nama yang sama, tetapi dengan parameter yang berbeda (jenis maupun jumlah parameter). Overloading method tidak bisa menggunakan tipe data return sebagai pembedanya, contoh :
```csharp
//hasil error
int PrintName(int a) { }
float PrintName(int b) { }
double PrintName(int c) { }
//harus parameter yang berbeda agar tidak error
```
## Recursif/recursion
memanggil ulang method di dalam method yang sama :
```csharp
static int Fact(int num) {
  if (num == 1) {
    return 1;
  }
  return num * Fact(num - 1);
}
```



















