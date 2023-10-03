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
> Note: jika parameter menggunakan `ref`, maka `ref` diperlukan ketika pemanggilan method
