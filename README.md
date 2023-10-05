# Learn C# (Source: Sololearn)
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
By reference copies the argument's memory address into a formal parameter. In this method, the address is used to access the actual arguments used in the call. This means that changes made to the parameters affect the argument.
To pass values ​​by reference, the `ref` keyword is used in method calls and definitions :
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
Output parameters are similar to reference parameters, except that they transfer data out of the method, rather than receiving incoming data. These parameters are defined using the `out` keyword
Variables provided for output parameters do not need to be initialized because those values ​​will not be used. Output parameters are very useful when you need to return multiple values ​​from a method. Example :
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
> Note: Unlike reference parameters, output parameters get values ​​from the method

## Verbatim Strings
The verbatim string allows special characters and linebreaks in strings. It can be created by prefixing `@` symbol before double quotes (`"`). examples :
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
Methods with the same name, but with different parameters (type and number of parameters). Overloading methods cannot use the return data type as a distinction, for example :
```csharp
//Error result
int PrintName(int a) { }
float PrintName(int b) { }
double PrintName(int c) { }
//Must have different parameter(s) so that are not Errors
```
## Recursif/recursion
re-calling a method within the same method :
```csharp
static int Fact(int num) {
  if (num == 1) {
    return 1;
  }
  return num * Fact(num - 1);
}
```
## Object declaration from a class
```csharp
class Person {
  int age;
  string name;
  public void SayHi() {
    Console.WriteLine("Hi");
  }
}
static void Main(string[] args)
{
  Person p1 = new Person();
  p1.SayHi();
}
```
## Encapsulation
In short, the benefits of encapsulation are:
- Control how data is accessed or modified.
- Code is more flexible and easy to change to new requirements.
- Change one part of the code without affecting other parts of the code.

## Constructor
A constructor has exactly the same name as its class, is public, and does not have any return type.

## Class property
A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. Properties can be used as if they are public data members, but they actually include special methods called accessors.
The accessor of a property contains the executable statements that help in getting (reading or computing) or setting (writing) a corresponding field. Accessor declarations can include a get accessor, a set accessor, or both. For example :
```csharp
class Person
{
  private string name; //field

  public string Name //property
  {
    get { return name; }
    set { name = value; }
  }
}
```
> Note: value (`set { name = value; })`) is a special keyword, which represents the value we assign to a property using the set accessor (`p.Name = "Bob";`).
The name of the property can be anything you want, but coding conventions dictate properties have the same name as the private field with a capital letter.

So, why use properties? Why not just declare the member variable public and access it directly?
With properties you have the option to control the logic of accessing the variable.
For example, you can check if the value of age is greater than 0, before assigning it to the variable:
```csharp
class Person
{
  private int age=0;
  public int Age
  {
    get { return age; }
    set {
      if (value > 0)
        age = value;
    }
  }
}
```
### Auto-Implemented Properties
When you do not need any custom logic, C# provides a fast and effective mechanism for declaring private members through their properties.
For example, to create a private member that can only be accessed through the Name property's get and set accessors, use the following syntax:
```csharp
public string Name { get; set; }
```
As you can see, you do not need to declare the private field name separately - it is created by the property automatically. Name is called an auto-implemented property. Also called auto-properties, they allow for easy and short declaration of private members.

## Array
Since arrays are objects, we need to instantiate them with the new keyword:
```csharp
int[ ] myArray = new int[5];
```
We can provide initial values to the array when it is declared by using curly brackets:
```csharp
string[ ] names = new string[3] {"John", "Mary", "Jessica"};
double[ ] prices = new double[4] {3.6, 9.8, 6.4, 5.9};
```
omit 👇:
```csharp
string[ ] names = new string[] {"John", "Mary", "Jessica"};
double[ ] prices = new double[] {3.6, 9.8, 6.4, 5.9};
```
omit again 👇:
```csharp
string[ ] names = {"John", "Mary", "Jessica"};
double[ ] prices = {3.6, 9.8, 6.4, 5.9};
```
## Multidimensional Arrays
An array can have multiple dimensions. A multidimensional array is declared as follows:
```csharp
type[, , … ,] arrayName = new type[size1, size2, …, sizeN];
```
For example, let's define a two-dimensional 3x4 integer array:
```csharp
int[ , ] x = new int[3,4];
```
## Jagged Array
A jagged array is an array whose elements are arrays. So it is basically an array of arrays.
The following is a declaration of a single-dimensional array that has three elements, each of which is a single-dimensional array of integers:
```csharp
int[ ][ ] jaggedArr = new int[3][ ];
```

## Strings Methods
String objects support a number of useful properties and methods:
- `.Length` returns the length of the string.
- `.IndexOf(value)` returns the index of the first occurrence of the value within the string.
- `.Insert(index, value)` inserts the value into the string starting from the specified index.
- `.Remove(index)` removes all characters in the string from the specified index.
- `.Replace(oldValue, newValue)` replaces the specified value in the string.
- `.Substring(index, length)` returns a substring of the specified length, starting from the specified index. If length is not specified, the operation continues to the end of the string.
- `.Contains(value)` returns true if the string contains the specified value.

## Class Destructor
As constructors are used when a class is instantiated, destructors are automatically invoked when an object is destroyed or deleted.
Destructors have the following attributes:
- A class can only have one destructor.
- Destructors cannot be called. They are invoked automatically.
- A destructor does not take modifiers or have parameters.
- The name of a destructor is exactly the same as the class prefixed with a tilde (~).

For Example :
```csharp
class Dog
{
  ~Dog() 
  {
    // code statements
  }
}
```

## Static
Class members (`variables`, `properties`, `methods`) can also be declared as static. This makes those members belong to the class itself, instead of belonging to individual objects. No matter how many objects of the class are created, there is only one copy of the static member. For example:
```csharp
class Cat {
  public static int count=0;
  public Cat() {
    count++;
  }
}
```
In this case, we declared a public member variable `count`, which is static. The constructor of the class increments the `count` variable by one.

No matter how many Cat objects are instantiated, there is always only one `count` variable that belongs to the Cat class because it was declared static.

You must access static members using the class name. If you try to access them via an object of that class, you will generate an error.
```csharp
static void Main(string[] args) {
  Cat a = new Cat();
  Cat b = new Cat();
  Console.WriteLine(Cat.count); //OK
  Console.WriteLine(a.count); //Error
}
```

Static methods can access only static members.

Constructors can be declared static to initialize static members of the class.
The static constructor is automatically called once when we access a static member of the class.

For example:
```csharp
class SomeClass {
  public static int X { get; set; }
  public static int Y { get; set; }
 
  static SomeClass() {
    X = 10;
    Y = 20;
  }
}
```
The constructor will get called once when we try to access SomeClass.X or SomeClass.Y.

## Static Classes
An entire class can be declared as static.
A static class can contain only static members.
You cannot instantiate an object of a static class, as only one instance of the static class can exist in a program.
Static classes are useful for combining logical properties and methods. A good example of this is the Math class.
It contains various useful properties and methods for mathematical operations.

## The readonly Modifier
The readonly modifier prevents a member of a class from being modified after construction. It means that the field declared as readonly can be modified only when you declare it or from within a constructor. For example:
```csharp
class Person {
  private readonly string name = "John"; 
  public Person(string name) {
    this.name = name; 
  }
}
```

If we try to modify the name field anywhere else, we will get an error.
There are three major differences between readonly and const fields.

- First, a constant field must be initialized when it is declared, whereas a readonly field can be declared without initialization, as in:
```csharp
readonly string name; // OK
const double PI; // Error
```

- Second, a readonly field value can be changed in a constructor, but a constant value cannot.

- Third, the readonly field can be assigned a value that is a result of a calculation, but constants cannot, as in:
```csharp
readonly double a = Math.Sin(60); // OK
const double b = Math.Sin(60); // Error!
```

The readonly modifier prevents a member of a class from being modified after construction.

## Indexers
Declaration of an indexer is to some extent similar to a property. The difference is that indexer accessors require an index.
Like a property, you use get and set accessors for defining an indexer. However, where properties return or set a specific data member, indexers return or set a particular value from the object instance.
Indexers are defined with the this keyword. For example:
```csharp
class Clients {
  private string[] names = new string[10];

  public string this[int index] {
    get {
      return names[index];
    }
    set {
      names[index] = value;
    }
  }
}
```
As you can see, the indexer definition includes the `this` keyword and an `index`, which is used to get and set the appropriate value.
Now, when we declare an object of class Clients, we use an index to refer to specific objects like the elements of an array:
```csharp
Clients c = new Clients();
c[0] = "Dave";
c[1] = "Bob";

Console.WriteLine(c[1]);
```

You typically use an indexer if the class represents a list, collection, or array of objects.

## Operator Overloading
Overloaded operators are methods with special names, where the keyword operator is followed by the symbol for the operator being defined.
Similar to any other method, an overloaded operator has a return type and a parameter list.
For example, for our Box class, we overload the + operator:
```csharp
public static Box operator+ (Box a, Box b) {
  int h = a.Height + b.Height;
  int w = a.Width + b.Width;
  Box res = new Box(h, w);
  return res;
}
```
The method above defines an overloaded operator + with two Box object parameters and returning a new Box object whose Height and Width properties equal the sum of its parameter's corresponding properties.
Additionally, the overloaded operator must be static.

**Putting it all together:**
```csharp
class Box {
  public int Height { get; set; }
  public int Width { get; set; }
  public Box(int h, int w) {
    Height = h;
    Width = w;
  }
  public static Box operator+(Box a, Box b) {
    int h = a.Height + b.Height;
    int w = a.Width + b.Width;
    Box res = new Box(h, w);
    return res;
  }
}
static void Main(string[] args) {
  Box b1 = new Box(14, 3);
  Box b2 = new Box(5, 7);
  Box b3 = b1 + b2;

  Console.WriteLine(b3.Height); 
  Console.WriteLine(b3.Width); 
}
```
> All arithmetic and comparison operators can be overloaded. For instance, you could define greater than and less than operators for the boxes that would compare the Boxes and return a **boolean** result. Just keep in mind that when overloading the greater than operator, the less than operator should also be defined.

## Inheritance
**Inheritance** allows us to define a class based on another class. This makes creating and maintaining an application easy.
The class whose properties are inherited by another class is called the **Base** class. The class which inherits the properties is called the __Derived__ class.
For example, base class **Animal** can be used to derive **Cat** and **Dog** classes.
The derived class inherits all the features from the base class, and can have its own additional features.

<p align="center">
  <img src="https://github.com/EmimBilek/belajar-c-sharp/blob/main/inherit.jpg" />
</p>

> Inheritance allows us to define a class based on another class.

Let's define our base class Animal:
```csharp
class Animal {
  public int Legs {get; set;}
  public int Age {get; set;}
}
```
Now we can derive class Dog from it:
```csharp
class Dog : Animal {
  public Dog() {
    Legs = 4;
  }
  public void Bark() {
    Console.Write("Woof");
  }
}
```
Note the syntax for a derived class. A **colon** (`:`) and the name of the **base** class follow the name of the **derived** class.
All public members of **Animal** become public members of **Dog**. That is why we can access the `Legs` member in the **Dog** constructor (`public Dog()`).
Now we can instantiate an object of type **Dog** and access the inherited members as well as call its own **Bark** method.

> Inheritance allows the derived class to reuse the code in the base class without having to rewrite it. And the derived class can be customized by adding more members. In this manner, the derived class extends the functionality of the base class.

A derived class inherits all the members of the base class, including its methods. For example:
```csharp
class Person {
  public void Speak() {
    Console.WriteLine("Hi there");
  }
}
class Student : Person {
  int number;
}
static void Main(string[] args) {
  Student s = new Student();
  s.Speak();
}
```
We created a Student object and called the Speak method, which was declared in the base class Person.

> C# does not support multiple inheritance, so you cannot inherit from multiple classes.
However, you can use interfaces to implement multiple inheritance. You will learn more about interfaces in the coming lessons.

## Protected modifier
The **protected** access modifier is very similar to **private** with one difference; it can be accessed in the **derived** classes. So, a **protected** member is accessible only from **derived** classes. For example:
```csharp
class Person {
  protected int Age {get; set;}
  protected string Name {get; set;}
}
class Student : Person {
  public Student(string nm) {
    Name = nm;
  }
  public void Speak() {
    Console.Write("Name: "+Name);
  }
}
static void Main(string[] args) {
  Student s = new Student("David");
  s.Speak();
}
```
As you can see, we can access and modify the `Name` property of the base class from the derived class.
But, if we try to access it from outside code, we will get an error:
```csharp
static void Main(string[] args) {
  Student s = new Student("David");
  s.Name = "Bob"; //Error
}
```

### Sealed
A class can prevent other classes from inheriting it, or any of its members, by using the `sealed` modifier. For example:
```csharp
sealed class Animal {
  //some code
}
class Dog : Animal { } //Error
```
In this case, we cannot derive the Dog class from the Animal class because Animal is sealed.
> The sealed keyword provides a level of protection to your class so that other classes cannot inherit from it.

## Base and Derived class constructor and destructor
Constructors are called when objects of a class are created. With inheritance, the base class constructor and destructor are not inherited, so you should define constructors for the derived classes.
However, the base class constructor and destructor are being invoked automatically when an object of the derived class is created or deleted.

Consider the following example:
```csharp
class Animal {
  public Animal() {
    Console.WriteLine("Animal created");
  }
  ~Animal() {
    Console.WriteLine("Animal deleted");
  }
}
class Dog: Animal {
  public Dog() {
    Console.WriteLine("Dog created");
  }
  ~Dog() {
    Console.WriteLine("Dog deleted");
  }
}
```
We have defined the `Animal` class with a constructor and destructor and a derived `Dog` class with its own constructor and destructor.

Let's create a Dog object:
```csharp
static void Main(string[] args) {
  Dog d = new Dog();
}
```
Note that **the base class constructor is called first** and **the derived class constructor is called next**.
When the object is destroyed, **the derived class destructor is invoked** and then **the base class destructor is invoked**.

> You can think of it as the following: The derived class needs its base class in order to work, which is why the base class constructor is called first.

## Polymorphism
The word **polymorphism** means "having many forms".
Typically, polymorphism occurs when there is a hierarchy of classes and they are related through inheritance from a common base class.
Polymorphism means that a call to a member method will cause a different implementation to be executed depending on the **type** of object that invokes the method.

> Simply, polymorphism means that a single method can have a number of different implementations.

Now, we can derive different `Shape` classes that define their own `Draw` methods using the `override` keyword:
```csharp
class Circle : Shape {
  public override void Draw() {
    // draw a circle...
    Console.WriteLine("Circle Draw");
  }
}
class Rectangle : Shape {
  public override void Draw() {
    // draw a rectangle...
    Console.WriteLine("Rect Draw");
  }
}
```
The virtual `Draw` method in the `Shape` base class can be **overridden** in the derived classes. In this case, `Circle` and `Rectangle` have their own `Draw` methods.
Now, we can create separate `Shape` objects for each derived type and then call their `Draw` methods:
```csharp
static void Main(string[] args) {
  Shape c = new Circle();
  c.Draw();

  Shape r = new Rectangle();
  r.Draw();
}
```
> As you can see, each object invoked its own `Draw` method, thanks to polymorphism.

To summarize, polymorphism is a way to call the same method for different objects and generate different results based on the object type. This behavior is achieved through virtual methods in the base class. To implement this, we create objects of the base type, but instantiate them as the derived type:
```csharp
Shape c = new Circle();
```
Shape is the base class. Circle is the derived class. So why use polymorphism? We could just instantiate each object of its type and call its method, as in:
```csharp
Circle c = new Circle();
c.Draw();
```
The polymorphic approach allows us to treat each object the same way. As all objects are of type `Shape`, it is easier to maintain and work with them. You could, for example, have a list (or array) of objects of that type and work with them dynamically, without knowing the actual derived type of each object.

> Polymorphism can be useful in many cases. For example, we could create a game where we would have different Player types with each Player having a separate behavior for the Attack method. In this case, Attack would be a virtual method of the base class Player and each derived class would override it.

## Abstract classes
In some situations there is no meaningful need for the virtual method to have a separate definition in the base class. These methods are defined using the `abstract` keyword and specify that the derived classes must define that method on their own. **You cannot create objects of a class containing an abstract method**, which is why the class itself should be abstract.

We could use an abstract method in the Shape class:
```csharp
abstract class Shape {
   public abstract void Draw();
}
```
As you can see, the `Draw` method is **abstract** and thus has no body. You do not even need the curly brackets(`{}`) just end the statement with a semicolon(`;`).
The Shape class itself must be declared **abstract** because it contains an **abstract method**. **Abstract method** declarations are only permitted in **abstract classes**.

> Remember, **abstract method** declarations are only permitted in **abstract classes**. Members marked as `abstract`, or included in an **abstract class**, must be implemented by classes that derive from the **abstract class**. **An abstract class can have multiple abstract members**.

An **abstract class** is intended to be a base class of other classes. It acts like a **template** for its derived classes.
Now, having the **abstract class**, we can derive the other classes and define their own `Draw()` methods:
```csharp
abstract class Shape {
  public abstract void Draw();
}
class Circle : Shape {
  public override void Draw() {
    Console.WriteLine("Circle Draw");
  }
}
class Rectangle : Shape {
  public override void Draw() {
    Console.WriteLine("Rect Draw");
  }
}
static void Main(string[] args) {
  Shape c = new Circle();
  c.Draw();
}
```

**Abstract classes** have the following features:
- An abstract class cannot be instantiated.
- An abstract class may contain abstract methods and accessors.
- A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

> It is not possible to modify an abstract class with the sealed modifier because the two modifiers have opposite meanings. The sealed modifier prevents a class from being inherited and the abstract modifier requires a class to be inherited.

## Interfaces
An interface is a completely abstract class, which contains only abstract members.
It is declared using the `interface` keyword:
```csharp
public interface IShape
{
  void Draw();
}
```
All members of the interface are **by default abstract**, so no need to use the abstract keyword.

Interfaces can have public (by default), private and protected members.

> It is common to use the capital letter **I** as the starting letter for an interface name.
Interfaces can contain properties, methods, etc. but **cannot** contain fields (variables).

When a class implements an interface, **it must also implement, or define, all of its methods**.
The term implementing an interface is used (opposed to the term "inheriting from") to describe the process of creating a class based on an interface. The interface simply describes what a class should do. The class implementing the interface must define how to accomplish the behaviors.
The syntax to implement an interface is the same as that to derive a class:
```csharp
public interface IShape {
  void Draw();
}
class Circle : IShape {
  public void Draw() {
    Console.WriteLine("Circle Draw");
  }
}
static void Main(string[] args) {
  IShape c = new Circle();
  c.Draw();
}
```
Note, that the `override` keyword is not needed when you implement an interface.

> But why use interfaces rather than abstract classes? A class can inherit from just one base class, but it can implement **multiple interfaces**! Therefore, by using interfaces you can include behavior from multiple sources in a class. To implement multiple interfaces, use a comma separated list of interfaces when creating the class: `class A: IShape, IAnimal, etc.`

### Default Implementation
Default implementation in interfaces allows to write an implementation of any method. This is useful when there is a need to provide a single implementation for common functionality.

Let's suppose we need to add new common functionality to our already existing interface, which is implemented by many classes. Without default implementation (before C# 8), this operation would create errors, because the method we have added isn't implemented in the classes, and we would need to implement the same operation one by one in each class. Default implementation in interface solves this problem.

For example:
```csharp
public interface IShape {
  void Draw();
  void Finish(){
    Console.WriteLine("Done!");
  }
}
class Circle : IShape {
  public void Draw() {
    Console.WriteLine("Circle Draw");
  }
}
static void Main(string[] args) {
  IShape c = new Circle();
  c.Draw();
  c.Finish();
}
```
We added the `Finish()` method with default implementation to our IShape interface and called it without implementing it inside the Circle class.

> Methods with default implementation can be freely overridden inside the class which implements that interface.

## Nested classes 
C# supports nested classes: a class that is a member of another class.

For example:
```csharp
class Car {
  string name;
  public Car(string nm) {
    name = nm;
    Motor m = new Motor();
  }
  public class Motor {
    // some code
  }
}
```
The `Motor` class is nested in the `Car` class and can be used similar to other members of the class. A nested class acts as a member of the class, so it can have the same access modifiers as other members (public, private, protected).

> Just as in real life, objects can contain other objects. For example, a car, which has its own attributes (color, brand, etc.) contains a motor, which as a separate object, has its own attributes (volume, horsepower, etc.). Here, the Car class can have a nested Motor class as one of its members.

## Namespaces
Namespaces declare a scope that contains a set of related objects. You can use a namespace to organize code elements. You can define your own namespaces and use them in your program.
The using keyword states that the program is using a given namespace.
For example, we are using the `System` namespace in our programs, which is where the class `Console` is defined:
```csharp
using System;
...
Console.WriteLine("Hi");
```
Without the `using` statement, we would have to specify the namespace wherever it is used:
```csharp
System.Console.WriteLine("Hi");
```
> The .NET Framework uses namespaces to organize its many classes. System is one example of a .NET Framework namespace.
Declaring your own namespaces can help you group your class and method names in larger programming projects.

## Structs
A struct type is a value type that is typically used to encapsulate small groups of related variables, such as the coordinates of a rectangle or the characteristics of an item in an inventory. The following example shows a simple struct declaration:
```csharp
struct Book {
  public string title;  
  public double price;
  public string author;
}
```
Structs share most of the same syntax as classes, but are more limited than classes.
Unlike classes, structs can be instantiated without using a `new` operator.
```csharp
static void Main(string[] args) {
  Book b;
  b.title = "Test";
  b.price = 5.99;
  b.author = "David";

  Console.WriteLine(b.title);
}
```
> Structs do not support inheritance and cannot contain virtual methods.

Structs can contain methods, properties, indexers, and so on. Structs cannot contain default constructors (a constructor without parameters), but they can have constructors that take parameters. In that case the new keyword is used to instantiate a struct object, similar to class objects.

For example:
```csharp
struct Point {
  public int x;
  public int y;
  public Point(int x, int y) {
    this.x = x;
    this.y = y;
  }
}
static void Main(string[] args) {
  Point p = new Point(10, 15);
  Console.WriteLine(p.x);
 }
```
### Structs vs Classes
In general, classes are used to model more complex behavior, or data, that is intended to be modified after a class object is created. Structs are best suited for small data structures that contain primarily data that is not intended to be modified after the struct is created. Consider defining a struct instead of a class if you are trying to represent a simple set of data.

> All standard C# types (int, double, bool, char, etc.) are actually structs.

## Enums
The `enum` keyword is used to declare an enumeration: a type that consists of a set of named constants called the enumerator list.
By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1.
For example, in the following enumeration, Sun is 0, Mon is 1, Tue is 2, and so on:
```csharp
enum Days {Sun, Mon, Tue, Wed, Thu, Fri, Sat};
```
You can also assign your own enumerator values:
```csharp
enum Days {Sun, Mon, Tue=4, Wed, Thu, Fri, Sat};
```
In the example above, the enumeration will start from 0, then `Mon` is 1, `Tue` is 4, `Wed` is 5, and so on. The value of the next item in an Enum is one increment of the previous value.
Note that the values are comma separated.
You can refer to the values in the Enum with the dot (`.`) syntax.
In order to assign Enum values to int variables, you have to specify the type in parentheses:
```csharp
enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat }; 

static void Main(string[] args) {
  int x = (int)Days.Tue;
  Console.WriteLine(x);
}
```
> Basically, Enums define variables that represent members of a fixed set.
Some sample Enum uses include month names, days of the week, cards in a deck, etc.

Enums are often used with switch statements.

For example:
```csharp
enum TrafficLights { Green, Red, Yellow };

static void Main(string[] args) {
  TrafficLights x = TrafficLights.Red;
  switch (x) {
    case TrafficLights.Green:
      Console.WriteLine("Go!");
      break;
    case TrafficLights.Red:
      Console.WriteLine("Stop!");
      break;
    case TrafficLights.Yellow:
      Console.WriteLine("Caution!");
      break;
  }
}
```

## Exceptions handling
An exception is a problem that occurs during program execution. Exceptions cause abnormal termination of the program.
An exception can occur for many different reasons. Some examples:
- A user has entered invalid data.
- A file that needs to be opened cannot be found.
- A network connection has been lost in the middle of communications.
- Insufficient memory and other issues related to physical resources.

For example, the following code will produce an exception when run because we request an index which does not exist:
```csharp
int[] arr = new int[] { 4, 5, 8 };
Console.Write(arr[8]);
```
> As you can see, exceptions are caused by user error, programmer error, or physical resource issues. However, a well-written program should handle all possible exceptions.

C# provides a flexible mechanism called the try-catch statement to handle exceptions so that a program won't crash when an error occurs.
The try and catch blocks are used similar to:
```csharp
try {
  int[] arr = new int[] { 4, 5, 8 };
  Console.Write(arr[8]);
}
catch(Exception e) {
  Console.WriteLine("An error occurred");
}
```
The code that might generate an exception is placed in the try block. If an exception occurs, the catch blocks is executed without stopping the program.
The type of exception you want to catch appears in parentheses following the keyword catch.
We use the general Exception type to handle all kinds of exceptions. We can also use the exception object e to access the exception details, such as the original error message (e.Message):
```csharp
try {
  int[] arr = new int[] { 4, 5, 8 };
  Console.Write(arr[8]);
}
catch(Exception e) {
  Console.WriteLine(e.Message);
}
// Index was outside the bounds of the array.
```
> You can also catch and handle different exceptions separately.

### Handling Multiple Exceptions
A single try block can contain multiple catch blocks that handle different exceptions separately.
Exception handling is particularly useful when dealing with user input.
For example, for a program that requests user input of two numbers and then outputs their quotient, be sure that you handle division by zero, in case your user enters 0 as the second number.
```csharp
int x, y;
try {
  x = Convert.ToInt32(Console.Read());
  y = Convert.ToInt32(Console.Read());
  Console.WriteLine(x / y);
}
catch (DivideByZeroException e) {
  Console.WriteLine("Cannot divide by 0");
}
catch(Exception e) {
  Console.WriteLine("An error occurred");
}
```
The above code handles the DivideByZeroException separately. The last catch handles all the other exceptions that might occur. If multiple exceptions are handled, the Exception type must be defined last.
Now, if the user enters 0 for the second number, "Cannot divide by 0" will be displayed.
If, for example, the user enters non-integer values, "An error occurred" will be displayed.

> The following exception types are some of the most commonly used: FileNotFoundException, FormatException, IndexOutOfRangeException, InvalidOperationException, OutOfMemoryException.

### finally
An optional finally block can be used after the catch blocks. The finally block is used to execute a given set of statements, whether an exception is thrown or not.

For example:
```csharp
int result=0;
int num1 = 8;
int num2 = 4;
try {
  result = num1 / num2;
}
catch (DivideByZeroException e) {
  Console.WriteLine("Error");
}
finally {
  Console.WriteLine(result);
}
```
> The finally block can be used, for example, when you work with files or other resources. These should be closed or released in the finally block, whether an exception is raised or not.

## Files
The System.IO namespace has various classes that are used for performing numerous operations with files, such as creating and deleting files, reading from or writing to a file, closing a file, and more. The File class is one of them.

For example:
```csharp
string str = "Some text";
File.WriteAllText("test.txt", str);
```
The WriteAllText() method creates a file with the specified path and writes the content to it. If the file already exists, it is overwritten.
The code above creates a file test.txt and writes the contents of the str string into it.

> To use the File class you need to use the System.IO namespace: using System.IO;

### Reading from Files
You can read the content of a file using the ReadAllText method of the File class:
```csharp
string txt = File.ReadAllText("test.txt");
Console.WriteLine(txt);
```
The following methods are available in the File class:
- AppendAllText() - appends text to the end of the file.
- Create() - creates a file in the specified location.
- Delete() - deletes the specified file.
- Exists() - determines whether the specified file exists.
- Copy() - copies a file to a new location.
- Move() - moves a specified file to a new location

> All methods automatically close the file after performing the operation.

## Generic Methods
```csharp
static void Swap<T>(ref T a, ref T b) {
  T temp = a;
  a = b;
  b = temp;
}
```
In the code above, `T` is the name of our generic type. We can name it anything we want, but `T` is a commonly used name. Our Swap method now takes two parameters of type `T`. We also use the `T` type for our temp variable that is used to swap the values.

> Note the brackets in the syntax `<T>`, which are used to define a generic type.

Now, we can use our Swap method with different types, as in:
```csharp
static void Swap<T>(ref T a, ref T b) {
  T temp = a;
  a = b;
  b = temp;
}
static void Main(string[] args) {
  int a = 4, b = 9;
  Swap<int>(ref a, ref b);
  //Now b is 4, a is 9

  string x = "Hello";
  string y = "World";
  Swap<string>(ref x, ref y);
  //Now x is "World", y is "Hello"
}
```
When calling a generic method, we need to specify the type it will work with by using brackets. So, when Swap<int> is called, the T type is replaced by int. For Swap<string>, T is replaced by string. If you omit specifying the type when calling a generic method, the compiler will use the type based on the arguments passed to the method.

> Multiple generic parameters can be used with a single method. For example: `Func<T, U>` takes two different generic types.

## Generic Classes












