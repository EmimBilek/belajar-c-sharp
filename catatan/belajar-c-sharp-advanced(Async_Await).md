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

## Keyword `async`
<sup> **Keyword :** async, await</sup>

Keyword __async__ digunakan untuk menandakan bahwa method akan dijalankan secara asinkron. Method yang asinkron harus mengembalikan/me-return nilai `Task` jika method tidak me-return nilai apapun (alias `void`). Apabila sebuah method asinkron ingin mengembalikan suatu nilai, gunakan generic `Task` -> `Task<TReturnType>` :
```csharp
public async Task DisplayContent(string fileLocation){...} // method asinkron yang mengembalikan tipe data void
public async Task<string> GetFileContentAsStringAsync(string fileLocation){...} // method asinkron yang mengembalikan tipe data string
```
> Modifier `async` digunakan pada sebuah method untuk memanggil method async yang lain dan menggunakan keyword `await` di depan pemanggilan method

## Keyword `await`
<sup> **Keyword :** async, await</sup>

Keyword __await__ digunakan untuk memanggil method asinkron dan berada di depan pada saat pemanggilan method :
```csharp
string content = await GetFileContentAsStringAsync(fileLocation);
```
> Method yang mengandung keyword `await` harus method asinkron
