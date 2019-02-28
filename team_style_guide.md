# Team 06 Style Guide

The Team 06 Style Guide will allow any and all members of
Team 06 to maintain coherency amongst all elements of the Logic Circuit Game

See https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#code for markdown tips

## Naming conventions

Names under the Team 06 Style Guide will be clear, concise, and in camel case (if multiple words).
One should know the purpose of the element purely from the name.

### Examples
* interfaces
```c#
public interface ClassName 
{
   // code example
}
```
* classes
```c#
public class ClassName 
{
   // code example
}
```
* exception types
* fields
* methods
```c#
public void printCoordinates(int x, int y)
{
   // code example
}
```
* parameters
```c#
public void printCoordinates(int x, int y)
{
   // code example
}
```
* local variables
```c#
String str;
int i;
```
* instance constants
* class constants

## Commenting style for public and private members of a class or interface:

* **Functions:**
   * Will have a signature 
      * name : param1, param2, ... paramN -> return
   * Will have a purpose statment
* **Variables:**
   * Will be self-documenting (for the most part)
   * Will have a brief description in-line with the variable declaration

### Examples

* classes

```c#
public class ClassName 
{
   // code example
}
```

* fields
* constructors
```c#
public [class name]
{
   // enter code here
}
```
* methods
* coding style (brackets, horizontal, and vertical spacing) for:
  * if statements
  ```c#
  if (this == suffering)
  {
      // enter code here
  }
  else
  {
      // enter code here
  }
  ```
  * switch statement
  
  * while loops
  ```c#
  while (i > x)
  {
   // enter code here
  }
  ```
  
  * for loops
  ```c#
  for (int i = 0; i > x; i++)
  {
      // enter code here
  }
  ```
  * enhanced for loops
