# Async Await
## Task-based Asynchronous Pattern (TAP)
<sup> **Keyword :** Task-based Asynchronous Pattern, CPU-bound Operations, I/O-bound Operations, User Experience, Long-running operation</sup>

__Apa itu Task-based Asynchronous Pattern?__ Task-based Asynchronous Pattern merupakan pola design yang direkomendasikan untuk membuat program asinkron. Program asinkron diperkenalkan pada c# versi 5, dan didukung pada _.NET Framework_ versi 4.5 ke atas dan juga _.NET Core_. Penamaan method asinkron diakhiri dengan Async -> `GetDataAsync`, `SendDataAsync` 

Operasi jangka panjang (_long-running operation_) membuat pengalaman pengguna yang buruk. Dengan mengimplementasikan program asinkron, itu dapat memberikan pengalaman pengguna (_User Experience_) menjadi lebih baik. Lalu bagaimana bisa _long-running operation_ membuat pengalaman pengguna yang buruk?

Kita ambil contoh pada mengeklik sebuah tombol. Tombol itu akan menjalankan operasi yang membutuhkan waktu lama dan dijalankan secara sinkron. Ketika tombol itu diklik, maka pengguna (user) tidak akan bisa melakukan hal yang lain pada aplikasi (seperti mengeklik tombol yang lain) dan menjadi tidak responsif, karena eksekusi yang menjalankan operasi yang memakan waktu akan terboklir sebelum operasi sinkron selesai dijalankan. Ini membuat pengalaman pengguna (UX) yang buruk dan tidak disarankan.
<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/longrun.png" width="500" />
</p>

2 jenis pemblokiran operasi :
- CPU-bound Operations
- I/O-bound Operations

__CPU-bound Operations__ terjadi ketika komputasi intensif perlu dilakukan pada CPU (seperti bermain game berat yang perlu melakukan banyak perhitungan komputer, ataupun pada bidang finansial dan _scientific_).

__I/O-bound Operations__ terjadi saat meminta data dari jaringan yang mengakses database atau pada saat membaca atau menulis file. Efek blokir dari operasi input output menyebabkan CPU untuk menunggu hingga operasi bersangkutan telah selesai. Saat I/O-bound operations berjalan, maka CPU akan terblokir dari menjalankan operasi yang lain. Performa aplikasi akan kurang optimal ketika kode untuk operasi yang berjalan relatif lama ini ditangani secara sinkron.

>__I/O-bound Operations__ prosesnya jauh lebih lambat daripada __CPU-bound Operations__

Penanganan asinkron pada __CPU-bound Operations__ dan __I/O-bound Operations__ diimplementasikan dengan cara yang berbeda :
<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/asinkronus handling.png" width="1000" />
</p>

## Keyword `async`
<sup> **Keyword :** async, await, `Task`, `Task<TReturnType>`</sup>

Keyword __async__ digunakan untuk menandakan bahwa method akan dijalankan secara asinkron. Method yang asinkron harus mengembalikan/me-return nilai `Task` jika method tidak me-return nilai apapun (alias `void`). Apabila sebuah method asinkron ingin mengembalikan suatu nilai, gunakan generic `Task` -> `Task<TReturnType>` :
```csharp
public async Task DisplayContent(string fileLocation){...} // method asinkron yang mengembalikan tipe data void
public async Task<string> GetFileContentAsStringAsync(string fileLocation){...} // method asinkron yang mengembalikan tipe data string
```
> Modifier `async` digunakan pada sebuah method untuk memanggil method async yang lain dan menggunakan keyword `await` di depan pemanggilan method

2 kegunaan method asinkron :
- Menandakan pada c# compiler bahwa method ini bisa menggunakan operator await di dalamnya
- Menandakan pada c# compiler bahwa method ini bisa di-awaited oleh method lain yang memanggilnya

## Keyword `await`
<sup> **Keyword :** async, await</sup>

Keyword __await__ digunakan untuk memanggil method asinkron dan berada di depan pada saat pemanggilan method :
```csharp
string content = await GetFileContentAsStringAsync(fileLocation);
```
> Method yang mengandung keyword `await` harus method asinkron

kode yang berada di bawah operator `await` tidak akan dieksekusi sampai method asinkron yang dipanggil dengan operator `await` telah selesai

## Contoh penggunaan async dan await dalam kode
```csharp
private async void button_click(object sender, EventArgs e)
{
  string content = await GetDocumentContentAsync("HugeFile.txt");
  DisplayContent(content);
}

private async Task<string> GetDocumentContentAsync(string fileName)
{
  
  string content = await GetDocumentContentAsStringAsync(filename);
  SaveDocumentLocally(content);
  return content;
}
```
> Pada contoh kode di atas, dapat dilihat bahwa method asinkron `GetDocumentContentAsync()` akan me-return objek `Task`. Tetapi tidak dengan method `button_click()`, karena method `button_click()` merupakan _high level event handler_ (penanganan event tingkat tinggi) jadi, tidak perlu mengganti `void` dengan `Task`. Semua asinkron method yang bukan _high level event handler_ akan me-return nilai `Task` apabila method yang bersangkutan tidak me-return nilai apapun (alias `void`) atau me-return generic `Task<T>` apabila method yang bersangkutan me-return sebuah nilai.

Pada contoh kode di atas, method `GetDocumentContentAsync()` akan me-return nilai string ketika method sudah selesai dijalankan. Karena methodnya merupakan method async yang me-return nilai string, maka harus menggunakan object `Task<string>` sebagai pengganti nilai returnnya.

Ketika menjalankan method asinkron dengan operator `await`, kontrol segera dikembalikan ke kode pemanggil. Artinya bisa menjalankan eksekusi lain ketika method asinkron sedang berjalan. sehingga CPU tidak dibiarkan menganggur saat _I/O-bound Operations_ sedang berlangsung

Hasil result dari method asinkron yang menggunakan operator `await` akan dikembalikan ketika method asinkron selesai atau melempar pengecualian (throws an exception) ketika terjadi error di dalam method asinkron
```csharp
private async Task<string> GetDocumentContentAsync(string fileName)
{
  try
  {
    string content = await GetDocumentContentAsStringAsync(filename);
    SaveDocumentLocally(content);
  }
  catch (Exception ex)
  {
    // handle the exception here
  }
  return content;
}
```
<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/asinkronus handling.png" width="1000" />
</p>

## Task
__Apa itu `Task`?__ Dalam pemrograman asinkron di C#, Task adalah objek yang merepresentasikan pekerjaan yang sedang berjalan atau akan berjalan di masa depan. Ini adalah cara C# untuk menangani operasi asinkron secara efisien dan memungkinkan aplikasi untuk tetap responsif dengan menjalankan pekerjaan di latar belakang tanpa mengunci thread utama (misalnya, _user interface_).

> Object `Task` berada pada namespace `System.Threading.Tasks`

Penggunaan `Task` pada async dan await di C# :
```csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        // Memulai operasi asinkron untuk mengunduh data dari dua URL
        Task<string> downloadTask1 = DownloadDataAsync("https://example.com/data1");
        Task<string> downloadTask2 = DownloadDataAsync("https://example.com/data2");

        // Menunggu kedua tugas selesai
        string[] results = await Task.WhenAll(downloadTask1, downloadTask2);

        // Menampilkan hasil unduhan
        Console.WriteLine("Data dari URL 1: " + results[0]);
        Console.WriteLine("Data dari URL 2: " + results[1]);
    }

    public static async Task<string> DownloadDataAsync(string url)
    {
        using HttpClient client = new HttpClient(); // namespace System.Net.Http
          string data = await client.GetStringAsync(url);
        return data;
    }
}
```
Ada beberapa method yang terdapat pada object `Task` :
- __`Run(Action action)`__ -> Menjalankan `Task` pada thread pool, sehingga tidak mengganggu thread utama aplikasi (misalnya, thread UI).
- __`WhenAll(params Task[] tasks)`__ -> Memblokir thread main sebelum semua task terdafter selesai dijalankan. Yang berarti kode yang dibawah method ini tidak akan dijalankan sebelum semua `Task` yang berada di dalam method `WhenAll()` telah selesai
