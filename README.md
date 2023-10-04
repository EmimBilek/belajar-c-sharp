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


