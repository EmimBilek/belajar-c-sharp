# Async Await
## Task-based Asynchronous Pattern (TAP)
<sup> **Keyword :** Task-based Asynchronous Pattern</sup>

__Apa itu Task-based Asynchronous Pattern?__ Task-based Asynchronous Pattern merupakan pola design yang direkomendasikan untuk membuat program asinkron. Program asinkron diperkenalkan pada c# versi 5, dan didukung pada _.NET Framework_ versi 4.5 ke atas dan juga _.NET Core_. Anggota asinkron mengandung keyword 'async'

Operasi jangka panjang (long-running operation) membuat pengalaman pengguna yang buruk. Dengan mengimplementasikan program asinkron, itu dapat memberikan pengalaman pengguna (user experience) menjadi lebih baik. Lalu bagaimana bisa operasi jangka panjang (long-running operation) membuat pengalaman pengguna yang buruk?

Kita ambil contoh pada mengeklik sebuah tombol. Tombol itu akan menjalankan operasi yang membutuhkan waktu lama dan dijalankan secara sinkron. Ketika tombol itu diklik, maka pengguna (user) tidak akan bisa melakukan hal yang lain pada aplikasi (seperti mengeklik tombol yang lain) dan menjadi tidak responsif, karena eksekusi yang menjalankan operasi yang memakan waktu akan terboklir sebelum operasi sinkron selesai dijalankan. Ini membuat pengalaman pengguna (UX) yang buruk dan tidak disarankan.
<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/catatan/longrun.png" width="500" />
</p>

