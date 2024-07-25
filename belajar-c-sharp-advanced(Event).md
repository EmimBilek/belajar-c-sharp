# Event
## Definisi
<sup> **Keyword :** Event</sup>

**Apa itu event?** event itu seperti delegate multicast yang spesial yang hanya bisa dipanggil dari dalam kelas dimana event itu dideklarasi. event di C# ditandai dengan keyword `event` pada saat deklarasi

Sebuah event bisa dipicu melalui tindakan user seperti menekan keyboard, mengklik mouse, dll atau bisa juga melalui logika yang dibuat sendiri (`==`, `<=`, `>=`, ataupun hasil logika apapun yang menghasilkan true / false)

## Event Handler 
<sup> **Keyword :** `EventHandler`, `EventHandler<TCustomClass>` </sup>

**Apa itu event handler?** event handler atau `EventHandler` merupakan built-in system delegate milik C# yang digunakan untuk menangani sebuah event. Contoh penggunaan `EventHandler` di C# :
```csharp
public event EventHandler AnEvent;
```
Untuk membuat sebuah event, gunakan kata kunci `event`

Ada dua jenis built-in system EventHandler, yaitu: 
- EventHandler(object sender, EventArgs e);
```csharp
public delegate void EventHandler (object? sender, EventArgs e);
```
- EventHandler<TEventArgs>(object sender, TEventArgs e);
```csharp
public delegate void EventHandler<TEventArgs> (object? sender, TEventArgs e);
```
Event handler yang menggunakan generik (jenis kedua) digunakan apabila ada data tambahan yang dibutuhkan ketika menggunakan event, dan data tambahan harus menggunakan kelas yang menurunkan kelas EventArgs, contoh :
```csharp
public class CustomEventArgs : EventArgs { //props... }
public event EventHandler<CustomEventArgs> EventWithCustomArgs;
```
## Event Accessor 
<sup> **Keyword :** add, remove, subscribe, unsubscribe</sup>

Keyword `event` digunakan untuk membuat sebuah event, ada dua jenis akses yang bisa digunakan dalam event, yaitu `add` dan `remove`.
- `add` : Akses `add` akan dijalankan ketika ada kode klien / sebuah method yang ditambahkan (subscribe `+=`) ke dalam event. Contoh :
```csharp
public event EventHandler<SomeClass> EventClassWithCustomClass
{
	add
	{
		_listEvent.AddHandler(_temperatureReaches, value);
	}
}
```
Method AddHandler akan dijalankan ketika kode klien ditambahkan (subscribe) ke dalam event :
```csharp
EventClassWithCustomClass += SomeMethod;
```

- `remove` : Akses `remove` akan dijalankan ketika ada kode klien / sebuah method yang dihapus (unsubscribe `-=`) dari event. Contoh :
```csharp
public event EventHandler<SomeClass> EventClassWithCustomClass
{
	remove
	{
		_listEvent.RemoveHandler(_temperatureReaches, value);
	}
}
```
Method AddHandler akan dijalankan ketika kode klien dihapus (unsubscribe) dari event :
```csharp
EventClassWithCustomClass -= SomeMethod;
```

## Event Handler List 
<sup> **Keyword :** EventHandlerList, readonly, static </sup>

### Apa itu event handler list? 
event handler list atau `EventHandlerList` merupakan built-in system class (ada di namespace `system.ComponentModel`) yang digunakan untuk menyimpan berbagai event dalam bentuk collection dan diidentifikasi dengan **kunci / key** untuk setiap event yang terdaftar dalam `EventHandlerList`

**Key** yang biasanya digunakan untuk mengakses event yang terdaftar dalam `EventHandlerList` yaitu menggunakan sebuah objek statis yang `readonly`, contohnya :
```csharp
static readonly object _eventKey1 = new object();
```

Cara memanggil event yang terdaftar di dalam event handler list yaitu dipanggil dengan menggunakan object yang telah dibuat kemudian di convert menjadi event handler, contoh :
```csharp
EventHandlerList EHList = new EventHandlerList();
static readonly object _eventKey1 = new object();
EventHandler<SomeClass> event = (EventHandler<SomeClass>) EHList[_eventKey1];
```

## Observer Design Pattern
<sup> **Keyword:** Observer Design Pattern, SOLI**D** Acronym/Principles, DRY - Don't Repeat Youself </sup>

**Pola desain Observer (Observer Design Pattern)** adalah salah satu dari pola desain perilaku yang mengatur bagaimana objek berinteraksi satu sama lain. Pola ini memungkinkan sebuah objek (disebut subject atau observable atau provider) untuk mengelola daftar dependensinya (disebut observer atau subscriber) dan memberitahukan mereka secara otomatis tentang perubahan status apa pun, biasanya dengan memanggil metode mereka. Ini memungkinkan _loose coupling_ antara subject dan observer. _~jipiti_

> Dalam konteks pola desain Observer, loose coupling berarti bahwa subject (observable) dan observer tidak saling bergantung secara langsung pada implementasi masing-masing. Mereka hanya mengetahui antarmuka (interface) satu sama lain.

Dalam pola ini, object provider harus mengimplementasikan interface generik system `IObservable<T>`, dan subscriber haurs mengimplementasikan interface generik system `IObserver<T>`. 

Saat object provider mengimplementasi interface `IObservable<T>`, ada satu method yang harus diimplementasi di dalam object provider nya, yaitu method `Subscribe(IObserver<T> subscriber)` :
```csharp
public class Provider : IObservable<SomeClass>
{
	public IDisposable Subscribe(IObserver<SomeClass> subscriber)
	{
		// Code goes here to handle subscription
	}

	public void MethodThatSendNotification()
	{
		// Call each subscribers OnNext() Method
		foreach (var subscriber in _subscribers)
			subscriber.OnNext(SomeClass);
	}
}
```
Saat object subscriber mengimplementasi interface `IObserver<T>`, ada 3 method yang harus diimplementasi di dalam object subscriber nya, yaitu method `OnNext(T value)`, `OnCompleted()`, dan `OnError(Exception ex)` :
```csharp
public class Subscriber : IObserver<SomeClass>
{
	public void OnCompleted()
	{
		// Code gets executed when no further notification will be sent
	}

	public void OnNext(SomeClass value)
	{
		// Code to handle notification
	}

	public void OnError(Exception ex)
	{
		//exception handling code goes here
	}
}
```
