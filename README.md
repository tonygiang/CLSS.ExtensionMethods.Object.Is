# CLSS.ExtensionMethods.Object.Is

### Problem

In order to make a type check during a functional-style call chain, you can do it in this way:

```csharp
using Newtonsoft.Json.Linq;

var resultText = (JToken.Parse(rawJSON).SelectToken(jsonPath) is JObject)
  .ToString().ToUpper(); // resultText: TRUE/FALSE
```

This syntax breaks the flow of reading code from left to right and makes logical errors from one missing or one extra parenthesis easy to miss. Typical C# programmers are not used to parse parenthesis pairs as Lisp programmers are.

### Solution

This package provides `Is<T>` extension method as a functional equivalence to the `is` syntax to maintain consistent LTR reading flow and be friendly to the functional syntax. The above first example can be rewritten as follows:

```csharp
using CLSS.
using Newtonsoft.Json.Linq;

var resultText = JToken.Parse(rawJSON).SelectToken(jsonPath).Is<JObject>()
  .ToString().ToUpper(); // resultText: TRUE/FALSE
```

It also provides an equivalence to C# 7.0's convenient [declaration syntax](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/patterns#declaration-and-type-patterns):

```csharp
object greeting = "Hello, World!";
if (greeting.Is<string>(out string message))
{ ... }
```

Due to the limitation in the type system of C#, `Is<T>` is limited to using reference types. Passing a value type to the type parameter will cause a compilation error. Note that this limitation is strictly for the type parameter. You can still use value types as the caller of `Is<T>`.

```csharp
using CLSS;

int number = 5;
var numberIsConvertible = number.Is<IConvertible>(); // true
```

`Is<T>` has some boxing overhead. It should be used if said overhead is negligible in your code path and comprehensibility is your priority.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).