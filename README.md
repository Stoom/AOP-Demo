# AOP-Demo
This is a demo of how Aspect Oriented Programing can be used to clean up and simpify your code.  In this demo I have used the [Castle Dynamic Proxy](https://github.com/castleproject/Core) and [LinFo.AOP](https://github.com/philiplaureano/LinFu) frameworks.
## Methods (github branches)
#### [DynamicProxy](https://github.com/StummeJ/AOP-Demo/tree/DynamicProxy)
A dynamic proxy is generated at runtime through inheritance.  This require any method or property that will be crosscut to be declared as virtual.  Take extra care that you do not leak ```csharp this``` from your original object (Castle has a documented ways to prevent this situation.)
#### [ILWeaving](https://github.com/StummeJ/AOP-Demo/tree/ILWeaving)
There are two different flavors of this: runtime weaving (LinFo.AOP), and compile time weaving (PostSharp.)  With runtime weaving a conditional branch is added to the IL of each method call, method body, constructor, and fields in a given assembly (per configuration.)  This allows for different crosscuts and aspects to be applied dynamically at runtime.  

## Differences
The main difference between IL weaving, both runtime and compile time, and a dynamic proxy stems from how the object is created.  With runtime weaving the object really is the object, just with a few extra branch statements, whereas the dynamic poxy is just another object sitting in front of your real object.  Another major benefit of IL weaving comes in what you can crosscut.  With a dynamic proxy you are limited to only things that are declared virtual, where on the other hand IL weaving allows crosscutting of static, sealed, private, and any object virutal or not.

## Choosing the right tool for the job
Although it is great to not be restricted on what you can and cannot crosscut there are some drawbacks, and benefits, from choosing a AOP framework.
#### Debugging
With many IL weaving frameworks debugging an AOP application can be almost impossible.  This is due the rewriting process after compilation.  If the framework does not rewrite the debugging symbols then the debugger will no longer associate your source code with the running code.  This is a major reason to choose the right tool as dynamic proxy framworks are immuned from this pitfull.Some commercial IL weaving framworks do support debugging, however most are costly unless the company supports open source or has an academic programs.
#### Speed
Inherently the dynamic proxy will be ever so slightly, and I mean ever, slower than a compile time IL weaver.  This is due to the extra calls preformed, first calling the proxy followed by the proxy calling the actual object.  Runtime IL weavers are somwhere in the middle.  LinFu inserts a condition branch (if statement) and two method calls either before, after, or before and after the call to the object.
#### IoC vs Factory Pattern
Depending on your situation most dynamic proxy and runtime IL weaving AOP frameworks also come with a IoC framework.  You can use either DI or a factory pattern to build your object as both require a little bit of setup to facilitate crosscutting to the correct aspect.  In this demo the factory pattern was used.

## Uses for AOP
It should be stated that AOP is not the silver bullet that will put holes in OOD.  It is another tool in the toolbox increase both the SRP and DRY principles.  Some other uses for AOP include:
1. Logging
2. Auditing
3. Validation
4. INotifyProperyChanged implementation
5. Undo/redo
6. Singleton pattern
7. Transaction management
8. Exception handling
9. Instrumentation
10. Read/write locks
11. Thread safety
13. Caching

## Helpful links
* [AOP Framework Tutorials](http://www.codeproject.com/Articles/140042/Aspect-Examples-INotifyPropertyChanged-via-Aspects)
* [Castle Dynamic Proxy (Slightly out of date but has the basics)](http://kozmic.net/dynamic-proxy-tutorial/)
* [Castle Dynamic Proxy Documentation](https://github.com/castleproject/Core/blob/master/docs/dynamicproxy.md)
* [LinFu.AOP Podcast](http://hanselminutes.com/213/aspect-oriented-programming-aop-and-linfu-with-philip-laureano)
* [LinFu.AOP Tutorial](http://bartwullems.blogspot.com/2010/06/introducing-linfu-framework.html)
* [LinFu.AOP Sample (Sligtly out of date but has the basics)](https://github.com/philiplaureano/LinFu.AOP.Examples)
