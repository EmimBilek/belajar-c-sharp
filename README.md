# Learn C#
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
> Note: berbeda dengan parameter reference, parameter output mendapatkan nilai dari method

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
//hasil error
int PrintName(int a) { }
float PrintName(int b) { }
double PrintName(int c) { }
//harus parameter yang berbeda agar tidak error
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
## Auto-Implemented Properties
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








