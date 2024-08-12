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
<sup> **Keyword :** thread, thread pool</sup>

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
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/iobon operation.png" width="1000" />
</p>

### Pengertian dari Thread dan Thread pool
__Thread__

Thread dalam ilmu komputer adalah kependekan dari thread eksekusi. Thread adalah cara suatu program membagi dirinya menjadi dua atau lebih tugas/task yang berjalan secara bersamaan (atau semu secara bersamaan).

__Thread Pool__

Thread Pool adalah sekelompok thread menganggur yang telah dibuat sebelumnya dan siap untuk diberikan pekerjaan. Jadi thread pool dibuat sehingga thread tersedia untuk suatu program yang berarti ketika suatu program memerlukan thread, program dapat memperoleh thread dari thread pool daripada mengeluarkan biaya overhead untuk membuat instance thread baru.

## Task
<sup> **Keyword :** `Task`, `Task<TResult>`</sup>

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
- __`WhenAll(params Task[] tasks)`__ -> Memberhentikan kode yang dibawah method ini sebelum semua `Task` yang berada di dalam method `WhenAll()` telah selesai. WhenAll bisa dijalankan secara asinkron dengan menggunakan operator `await`.
- __`WaitAll(params Task[] tasks)`__ -> Memblokir thread main sehingga kode yang berada di bawah method ini tidak akan dijalankan sebelum semua `Task` terdaftar telah selesai. WaitAll hanya bisa dijalankan secara sinkron, sehingga tidak bisa menggunakan operator `await` di depannya.
- __`ContinueWith(Action<T> action)`__ -> Membuat kelanjutan setelah task yang menggunakan method ini selesai (melanjutkan method).
- __`WhenAny(params Task[] tasks)`__ -> Memberhentikan kode yang dibawah method ini sebelum ada `Task` yang terdaftar telah selesai. Sama seperti WhenAll, WhenAny juga tidak memblokir thread main.
- __`Delay(Int32)`__ -> Memberikan waktu jeda dalam milisekon.
- __`ConfigureAwait(bool continueOnCapturedContext)`__ -> Mengontrol bagaimana konteks sinkronisasi (seperti UI thread atau konteks tertentu lainnya) diatur ketika sebuah await diselesaikan. Jika true maka operasi asinkron akan melanjutkan thread dimana operasi asinkron dijalankan, jika false maka operasi asinkron akan mengabaikan thread dimana operasi asinkron dijalankan. (_lebih jelasnya tanya jipiti_)
- DLL (_banyak di document microsoft_)

> Para pengembang/developer, seharusnya jangan menggunakan method `Task.Run()` pada method yang dapat digunakan kembali (_reusable method_), karena developer yang menentukan apakah _reusable method_ itu akan dijalankan secara sinkron atau asinkron

## Best Practice For Async Await
- Menjalankan method `Task.Run()` secara langsung pada _event handler method_ adalah cara terbaik dalam penggunaan async await.
- Jangan menjalankan _Main UI Thread_ kecuali memang harus dilakukan. Caranya yaitu bisa dengan menggunakan method `ConfigureAwait(bool continueOnCapturedContext)` pada objek task yang menggunakan operator `await` dengan argumen false, supaya eksekusi tidak dilanjutkan di main thread setelah await diselesaikan, tetapi dilanjutkan di thread lain.
- Hindari penggunaan method `Task.Run()` di dalam method yang diimplementasi di dalam komponen _server-side_
- CPU-bound operations seharusnya berjalan secara sinkron. Ambil contoh kita mempunyai 4 operasi yang dijalankan di server-side/web api (yang berarti akan menjalankan CPU-bound Operation). Jika keempat operasi tersebut dijalankan secara asinkron menggunakan `Task.Run()`, maka pada web api memerlukan 4 thread tambahan untuk melaksanakan 4 operasi tersebut secara bersamaan. Ini akan menyebabkan penggunaan berlebih pada sumber daya server yang tidak dapat diterima dan akan berdampak buruk pada performa server dan pengalaman pengguna (UX). Kita masih bisa memastikan UI client-side tetap responsive yaitu dengan memanggil kode dari server-side menggunakan async dan await.

## Best Practice For Async Await (Original text)
- Know the nature of your asynchronous code ask the question is the operation _CPU bound_ or _I/O bound_ and then apply the relevant asynchronous code appropriately
- Avoid writing _CPU-bound Operations_ within reusable Library components using the `Task.Run()` method
- Let the consumer of the library component choose whether to run the CPU bound operations synchronously or asynchronously
- Methods that run I/O-bound operations asynchronously included within reusable Library components should include the Async suffix as part of the relevant method's name this will let the consumer of your library know that the relevant method should be run asynchronously using async await
- On the client side run CPU-bound operations close to the relevant UI event handler method, for example using `Task.Run()` method directly within the relevant button click event handler method
- If for example a button-click event handler method needs to perform a CPU-bound operation asynchronously on a background thread and subsquently code within that method does not require a return to the UI thread, explicitly let the .net runtime know that it is unnecessary to return to the UI thread once the CPU bound operation has completed by appropiately calling the `ConfigureAwait()` method this can result in a performance boost.
- Avoid running CPU bound operation on the server side using the `Task.Run()` method

## Membatalkan Operasi Asinkron
<sup> **Keyword :** `CancellationTokenSource`, `CancellationToken`</sup>

Kamu bisa membatalkan aplikasi konsol async jika tidak ingin menunggnya hingga selesai. Dengan mengikuti contoh dalam topik ini, kamu dapat menambahkan pembatalan ke aplikasi yang mengunduh konten daftar situs web. Kamu dapat membatalkan banyak `Task` dengan mengaitkan instance `CancellationTokenSource` dengan setiap `Task`.

> `CancellationTokenSource` ada di namespace `System.Threading`

Cara menggunakan `CancellationTokenSource` pada pemrograman asinkron :
```csharp
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task task = SomeOperationAsync(token);

        // Batalkan operasi setelah 3 detik
        cts.CancelAfter(3000);

        try
        {
            await task;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operasi dibatalkan.");
        }
    }

    static async Task SomeOperationAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000); // Simulasi operasi
            Console.WriteLine($"Iteration {i}");
        }
    }
}
```

## Ringkasan
<sup> **Kode :** BelajarAsyncAwait</sup>


- Kita telah mengetahui pola yang direkomendasikan Microsoft untuk mengimplementasikan kode guna menjalankan suatu operasi atau beberapa operasi secara asinkron, yaitu “Pola Asinkron Berbasis Tugas”.

- Kita membahas bahwa menjalankan operasi pemblokiran CPU tertentu yang berjalan relatif lama dapat berdampak buruk pada kinerja aplikasi kita. Untuk mengurangi efek negatif pada pengalaman pengguna (UX), kita dapat menjalankan operasi pemblokiran CPU yang berjalan relatif lama ini secara asinkron.

- Untuk mengimplementasikan kode asinkron dengan benar, pertama-tama kita harus mengetahui sifat tugas atau operasi yang ingin kita jalankan secara asinkron. Pertama-tama kita perlu mengajukan pertanyaan; "Apakah operasi yang relevan merupakan operasi yang terikat CPU atau apakah operasi yang relevan merupakan operasi yang terikat I/O?"

- Di bagian pertama dokumen ini, kami berfokus pada menjalankan operasi terikat I/O secara asinkron menggunakan modifier `async`, operator `await`, dan objek `Task` atau `Task<TResult>`.

- Di bagian kedua dari dokumen ini kita melihat menjalankan operasi yang terikat CPU secara asinkron menggunakan method `Task.Run()` pada thread latar belakang. Kita juga telah melihat Method `Task.WaitAll()`.

- Di bagian ketiga seri video ini, kita melihat praktik terbaik saat mengimplementasikan operasi di C# agar berjalan secara asinkron. Kita juga melihat Method `Task.WhenAll()` dan perbedaannya dengan method `Task.WaitAll()`.

- Dalam dokumen ini, kita melihat bagaimana kami dapat memberikan pengguna kemampuan untuk membatalkan satu atau lebih operasi asinkron yang berjalan sebelum operasi terkait selesai, menggunakan objek `CancelationTokenSource`. Kita juga mendemonstrasikan bagaimana kita dapat mengotomatiskan pembatalan operasi asinkron yang berjalan setelah jangka waktu tertentu dengan memanggil metode `CancelAfter()` pada objek `CancellationTokenSource` yang relevan.
