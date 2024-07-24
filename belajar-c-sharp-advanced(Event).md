# Event
## Definisi (Keyword : Event)
Apa itu event? event itu seperti delegate multicast yang spesial yang hanya bisa dipanggil dari dalam kelas dimana event itu dideklarasi. event di C# ditandai dengan keyword `event` pada saat deklarasi

Sebuah event bisa dipicu melalui tindakan user seperti menekan keyboard, mengklik mouse, dll atau bisa juga melalui logika yang dibuat sendiri (==, <=, >=, ataupun hasil logika apapun yang menghasilkan true / false)

## EVENT HANDLER (Keyword : EventHandler, EventHandler<TCustomClass> )
Apa itu event handler? event handler atau EventHandler merupakan built-in system delegate milik c# yang digunakan untuk menangani sebuah event. Contoh penggunaan EventHandler :
```csharp
public event EventHandler<SomeClassEventArgs> AnEvent;
```
- untuk membuat sebuah event, gunakan kata kunci 'event'

- ada dua jenis built-in system EventHandler, yang pertama yaitu: 

public delegate void EventHandler (object? sender, EventArgs e);

public delegate void EventHandler<TEventArgs> (object? sender, TEventArgs e);

- event handler yang menggunakan generik digunakan apabila ada data tambahan yang dibutuhkan ketika menggunakan event, dan data tambahan harus menggunakan kelas yang menurunkan kelas EventArgs, contoh :

public class CustomEventArgs : EventArgs { props... }

public event EventHandler<CustomEventArgs> EventWithCustomArgs;

--- EVENT ACCESSOR --- (KEYWORD : add, remove, subscribe, unsubscribe)
- keyword 'event' digunakan untuk membuat sebuah event, ada dua jenis akses yang bisa digunakan dalam event, yaitu add dan remove.
- add : akses add akan dijalankan ketika ada kode klien / sebuah method yang ditambahkan (subscribe -> +=) ke dalam event. Contoh :
public event EventHandler<SomeClass> EventClassWithCustomClass{
	add {
		_listEvent.AddHandler(_temperatureReaches, value);
	}
}

- method AddHandler akan dijalankan ketika kode klien ditambahkan (subscribe) ke dalam event -> 
	EventClassWithCustomClass += SomeMethod;

- remove : akses remove akan dijalankan ketika ada kode klien / sebuah method yang dihapus (unsubscribe -> -=) dari event.
	Contoh :
public event EventHandler<SomeClass> EventClassWithCustomClass{
	remove {
		_listEvent.RemoveHandler(_temperatureReaches, value);
	}
}

- method AddHandler akan dijalankan ketika kode klien dihapus (unsubscribe) dari event -> 
	EventClassWithCustomClass -= SomeMethod;

--- EVENT HANDLER LIST --- (Keyword : EventHandlerList, readonly, static)
- apa itu event handler list? event handler list atau EventHandlerList merupakan built-in system class (ada di namespace system.ComponentModel) yang digunakan untuk menyimpan berbagai event dalam bentuk collection dan diidentifikasi dengan kunci / key untuk setiap event yang terdaftar dalam EventHandlerList

- key yang biasanya digunakan untuk mengakses event yang terdaftar dalam EventHandlerList yaitu menggunakan sebuah objek statis yang readonly, contohnya :
static readonly object _eventKey1 = new object();

- cara memanggil event yang terdaftar di dalam event handler list yaitu dipanggil dengan menggunakan object yang telah dibuat kemudian di convert menjadi event handler, contoh :
EventHandlerList EHList = new EventHandlerList();
static readonly object _eventKey1 = new object();
EventHandler<SomeClass> event = (EventHandler<SomeClass>) EHList[_eventKey1];

--- Observer Design Pattern ---
- Pola desain Observer (Observer Design Pattern) adalah salah satu dari pola desain perilaku yang mengatur bagaimana objek berinteraksi satu sama lain. Pola ini memungkinkan sebuah objek (disebut subject atau observable atau provider) untuk mengelola daftar dependensinya (disebut observer atau subscriber) dan memberitahukan mereka secara otomatis tentang perubahan status apa pun, biasanya dengan memanggil metode mereka. Ini memungkinkan loose coupling antara subject dan observer. (loose coupling adalah pengurangan ketergantungan, memungkinkan subject dan observer tidak saling bergantung secara langsung) ~jipiti

- dalam pola ini, object provider harus mengimplementasikan interface generik system IObservable<T>, dan subscriber haurs mengimplementasikan interface generik system IObserver<T>.

- saat object provider mengimplementasi interface IObservable<T>, ada satu method yang harus diimplementasi di dalam object provider nya, yaitu method Subscribe() :
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

- saat object subscriber mengimplementasi interface IObserver<T>, ada 3 method yang harus diimplementasi di dalam object subscriber nya, yaitu method OnNext(), OnCompleted(), OnError() :
public class Subscriber : IObserver<SomeClass>
{
	public void OnCompleted()
	{
		// Code gets executed when no further notification will be sent
	}

	public void OnNext(T value)
	{
		// Code to handle notification
	}

	public void OnError(Exception ex)
	{
		//exception handling code goes here
	}
}
